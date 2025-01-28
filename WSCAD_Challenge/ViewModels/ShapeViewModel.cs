using System;
using System.Windows;
using WSCAD_Challenge.Utilities.DrawingStrategies;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.ViewModels
{
    public class ShapeViewModel
    {
        #region Properties

        public IShape Shape { get; }
        private readonly IDrawingStrategy _drawingStrategy;

        #endregion

        #region Constructor

        public ShapeViewModel(IShape shape)
        {
            Shape = shape ?? throw new ArgumentNullException(nameof(shape));

            // Select the drawing strategy based on the shape type
            _drawingStrategy = CreateDrawingStrategy(shape);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the shape on the provided canvas.
        /// </summary>
        /// <param name="canvas">The canvas where the shape will be drawn.</param>
        /// <param name="zoom">The zoom factor for scaling.</param>
        public UIElement GetShapeToBeDrawn(double zoom)
        {
            if (zoom <= 0)
                throw new ArgumentOutOfRangeException(nameof(zoom), "Zoom factor must be positive.");

            UIElement shapeToDraw = _drawingStrategy.GetShapeToDraw(Shape, zoom);
            return shapeToDraw;
        }

        /// <summary>
        /// Retrieves the bounding box of the shape.
        /// </summary>
        /// <returns>A <see cref="Rect"/> representing the shape's bounding box.</returns>
        public Rect GetBoundingBox()
        {
            return _drawingStrategy.GetBoundingBox(Shape);
        }

        private static IDrawingStrategy CreateDrawingStrategy(IShape shape)
        {
            return shape switch
            {
                Circle => new CircleDrawingStrategy(),
                Line => new LineDrawingStrategy(),
                Triangle => new TriangleDrawingStrategy(),
                _ => throw new NotSupportedException($"Drawing strategy not implemented for shape type: {shape.GetType().Name}")
            };
        }

        #endregion
    }
}
