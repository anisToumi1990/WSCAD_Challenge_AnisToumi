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

        //[Fact]
        //[STAThread]  // Ensure that the test runs on a STA thread
        //public void Draw_ValidCircle_ShouldDrawOnCanvas()
        //{
        //    // Arrange
        //    Circle circle = new Circle
        //    (
        //        new Point(100, 100),
        //        50,
        //        true,
        //        Colors.Red
        //    );
        //    var zoom = 1.0;

        //    // Act
        //    _circleDrawingStrategy.Draw(_mockCanvas.Object, circle, zoom);

        //    // Assert
        //    _mockCanvas.Verify(c => c.Children.Add(It.IsAny<Ellipse>()), Times.Once); // Verifies ellipse is added
        //}

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
