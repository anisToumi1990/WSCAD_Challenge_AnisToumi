using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Services;
using WSCAD_Challenge.Utilities.Shapes;
using WSCAD_Challenge.ViewModels;

namespace WSCAD_Challenge.Views
{
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly GraphicViewModel _viewModel;

        #endregion

        #region Properties

        public double Zoom { get; private set; } = 1.0;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            // Dependency injection for ViewModel
            IShapeLoader shapeLoader = new ShapeLoader();
            IFileDialogService fileDialogService = new FileDialogService();

            _viewModel = new GraphicViewModel(shapeLoader, fileDialogService);
            _viewModel.DataLoaded += OnDataLoaded;

            // Set ViewModel as DataContext for binding
            DataContext = _viewModel;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the event triggered when data is loaded in the ViewModel.
        /// </summary>
        private void OnDataLoaded(object sender, EventArgs e) => RenderShapes();

        #endregion

        #region Methods

        /// <summary>
        /// Renders shapes onto the canvas.
        /// </summary>
        private void RenderShapes()
        {
            // Clear existing shapes
            ShapeCanvas.Children.Clear();

            // Calculate canvas dimensions
            double canvasWidth = ActualWidth/2;
            double canvasHeight = ActualHeight/2 - 50; //Adjusted to take into consideration other UI elements (like task bar ..)

            // Fit shapes to canvas and calculate zoom
            Zoom = FitShapesToCanvasHelper.FitShapesToCanvas(_viewModel.ShapeViewModels, canvasWidth, canvasHeight);

            // Render each shape with calculated zoom
            foreach (var shapeViewModel in _viewModel.ShapeViewModels)
            {
                var shape = shapeViewModel.GetShapeToBeDrawn(Zoom);

                if (shapeViewModel.Shape is Circle circle)
                    SetCirclePosition(shape, circle);

                // Add the shape to the canvas
                ShapeCanvas.Children.Add(shape);
            }

            // Invert the Y-axis to adjust for WPF's coordinate system
            ShapeCanvas.RenderTransform = new ScaleTransform(1, -1);
        }

        private void SetCirclePosition(UIElement shape, Circle circle)
        {
            double radius = circle.Radius;
            Point center = circle.Center;

            Canvas.SetLeft(shape, center.X - radius);
            Canvas.SetTop(shape, center.Y - radius);
        }
        #endregion
    }
}
