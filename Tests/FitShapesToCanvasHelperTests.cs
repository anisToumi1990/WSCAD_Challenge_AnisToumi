using System.Windows;
using System.Windows.Media;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Utilities.Shapes;
using WSCAD_Challenge.ViewModels;

namespace WSCAD_Challenge.Tests
{
    public class FitShapesToCanvasHelperTests
    {
        [Fact]
        public void FitShapesToCanvas_ValidShapes_ShouldReturnCorrectScale()
        {
            // Arrange
            var shapes = new List<ShapeViewModel>
            {
                new ShapeViewModel(new Line(new Point(0, 0), new Point(10, 10), Color.FromArgb(255, 255, 0, 0))),  // Red
                new ShapeViewModel(new Circle(new Point(5, 5), 10, true, Color.FromArgb(255, 0, 255, 0))),  // Green
                new ShapeViewModel(new Triangle(new Point(-5, -5), new Point(0, 0), new Point(5, 5), true, Color.FromArgb(255, 0, 0, 255)))  // Blue
            };

            double canvasWidth = 500;
            double canvasHeight = 500;

            // Act
            var scale = FitShapesToCanvasHelper.FitShapesToCanvas(shapes, canvasWidth, canvasHeight);

            // Assert
            // The bounding box for these shapes is expected to be width = 20, height = 20
            // So the scale should be the canvas size divided by the bounding box size.
            // Expected scale = min(500 / 20, 500 / 20) = 25
            Assert.Equal(25, scale);
        }

        [Fact]
        public void FitShapesToCanvas_LargerCanvas_ShouldReturnCorrectScale()
        {
            // Arrange
            var shapes = new List<ShapeViewModel>
            {
                new ShapeViewModel(new Line(new Point(0, 0), new Point(10, 10), Color.FromArgb(255, 255, 0, 0))),  // Red
                new ShapeViewModel(new Circle(new Point(5, 5), 10, true, Color.FromArgb(255, 0, 255, 0))),  // Green
                new ShapeViewModel(new Triangle(new Point(-5, -5), new Point(0, 0), new Point(5, 5), true, Color.FromArgb(255, 0, 0, 255)))  // Blue
            };

            double canvasWidth = 1000;
            double canvasHeight = 1000;

            // Act
            var scale = FitShapesToCanvasHelper.FitShapesToCanvas(shapes, canvasWidth, canvasHeight);

            // Assert
            // Expected scale = min(1000 / 20, 1000 / 20) = 50
            Assert.Equal(50, scale);
        }

        [Fact]
        public void FitShapesToCanvas_SmallerCanvas_ShouldReturnCorrectScale()
        {
            // Arrange
            var shapes = new List<ShapeViewModel>
            {
                new ShapeViewModel(new Line(new Point(0, 0), new Point(10, 10), Color.FromArgb(255, 255, 0, 0))),  // Red
                new ShapeViewModel(new Circle(new Point(5, 5), 10, true, Color.FromArgb(255, 0, 255, 0))),  // Green
                new ShapeViewModel(new Triangle(new Point(-5, -5), new Point(0, 0), new Point(5, 5), true, Color.FromArgb(255, 0, 0, 255)))  // Blue
            };

            double canvasWidth = 200;
            double canvasHeight = 200;

            // Act
            var scale = FitShapesToCanvasHelper.FitShapesToCanvas(shapes, canvasWidth, canvasHeight);

            // Assert
            // Expected scale = min(200 / 20, 200 / 20) = 10
            Assert.Equal(10, scale);
        }
    }
}
