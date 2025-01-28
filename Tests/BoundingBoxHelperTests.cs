using System.Windows;
using System.Windows.Media;
using WSCAD_Challenge.Utilities.Shapes;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.ViewModels;

namespace WSCAD_Challenge.Tests
{
    public class BoundingBoxHelperTests
    {
        [Fact]
        public void CalculateBoundingBox_ValidShapes_ShouldReturnCorrectBoundingBox()
        {
            // Arrange
            var shapes = new List<ShapeViewModel>
            {
                new ShapeViewModel(new Line(new Point(0, 0), new Point(10, 10), Color.FromArgb(255, 255, 0, 0))),  // Red
                new ShapeViewModel(new Circle(new Point(5, 5), 10, true, Color.FromArgb(255, 0, 255, 0))),  // Green
                new ShapeViewModel(new Triangle(new Point(-5, -5), new Point(0, 0), new Point(5, 5), true, Color.FromArgb(255, 0, 0, 255)))  // Blue
            };

            // Act
            var boundingBox = BoundingBoxHelper.CalculateBoundingBox(shapes);

            // Assert
            Assert.Equal(-5, boundingBox.Left);
            Assert.Equal(-5, boundingBox.Top);
            Assert.Equal(20, boundingBox.Width);
            Assert.Equal(20, boundingBox.Height);
        }

        [Fact]
        public void CalculateBoundingBox_EmptyShapes_ShouldReturnEmptyBoundingBox()
        {
            // Arrange
            var shapes = new List<ShapeViewModel>();

            // Act
            var boundingBox = BoundingBoxHelper.CalculateBoundingBox(shapes);

            // Assert
            Assert.Equal(double.MaxValue, boundingBox.Left);
            Assert.Equal(double.MaxValue, boundingBox.Top);
            Assert.Equal(double.MaxValue, boundingBox.Right);
            Assert.Equal(double.MaxValue, boundingBox.Bottom);
        }
    }
}
