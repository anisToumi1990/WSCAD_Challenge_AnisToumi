using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WSCAD_Challenge.Commands;
using WSCAD_Challenge.Services;

namespace WSCAD_Challenge.ViewModels
{
    public class GraphicViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly IShapeLoader _shapeLoader;
        private readonly IFileDialogService _fileDialogService;

        #endregion

        #region Public Properties

        public ObservableCollection<ShapeViewModel> ShapeViewModels { get; } = new ObservableCollection<ShapeViewModel>();

        public ICommand LoadJsonCommand { get; }

        #endregion

        #region Events

        public event EventHandler DataLoaded;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public GraphicViewModel(IShapeLoader shapeLoader, IFileDialogService fileDialogService)
        {
            _shapeLoader = shapeLoader ?? throw new ArgumentNullException(nameof(shapeLoader));
            _fileDialogService = fileDialogService ?? throw new ArgumentNullException(nameof(fileDialogService));

            LoadJsonCommand = new RelayCommand(async () => await LoadDataFromJsonAsync());
        }

        #endregion

        #region Methods

        private async Task LoadDataFromJsonAsync()
        {
            try
            {
                // Open file dialog and get file path
                var filePath = _fileDialogService.OpenFile("JSON Files (*.json)|*.json");

                if (string.IsNullOrEmpty(filePath))
                    return;

                // Load shapes asynchronously
                var shapes = await Task.Run(() => _shapeLoader.LoadShapes(filePath));
                if (shapes == null)
                    return;

                // Update the ObservableCollection with loaded shapes
                ShapeViewModels.Clear();
                foreach (var shape in shapes)
                {
                    ShapeViewModels.Add(new ShapeViewModel(shape));
                }

                // Notify subscribers that data has been loaded
                DataLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading shapes: {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while loading shapes.", ex);
            }
        }

        #endregion
    }
}
