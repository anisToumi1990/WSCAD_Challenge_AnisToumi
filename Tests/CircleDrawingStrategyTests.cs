using Moq;
using System.Windows;
using System.Windows.Media;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Utilities.DrawingStrategies;

namespace WSCAD_Challenge.Tests
{
    public class CircleDrawingStrategyTests
    {
        private readonly CircleDrawingStrategy _circleDrawingStrategy;

        public CircleDrawingStrategyTests()
        {
            _circleDrawingStrategy = new CircleDrawingStrategy();
        }

        [Fact]
        public void GetBoundingBox_ValidCircle_ShouldReturnCorrectBoundingBox()
        {
            // Arrange
            var circle = new Circle
            (
                new Point(100, 100),
                50,
                true,
                Colors.Red
            );

            // Act
            var boundingBox = _circleDrawingStrategy.GetBoundingBox(circle);

            // Assert
            Assert.Equal(new Rect(50, 50, 100, 100), boundingBox);
        }

        [Fact]
        public void GetBoundingBox_InvalidShape_ShouldThrowException()
        {
            // Arrange
            var mockShape = new Mock<IShape>().Object;

            // Act & Assert
            var exception = Assert.Throws<InvalidCastException>(() =>
                _circleDrawingStrategy.GetBoundingBox(mockShape));
            Assert.Equal("Expected a Circle shape, but received IShapeProxy.", exception.Message);
        }
    }
}
