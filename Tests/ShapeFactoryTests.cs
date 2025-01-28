using WSCAD_Challenge.Models;
using WSCAD_Challenge.Models.Data;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.Tests
{
    public class ShapeFactoryTests
    {
        [Fact]
        public void CreateShape_Line_ShouldReturnLineShape()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                Type = "line",
                A = "0;0",
                B = "1;1",
                Color = "255; 0; 0; 255"
            };

            // Act
            var result = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsType<Line>(result);
        }

        [Fact]
        public void CreateShape_Circle_ShouldReturnCircleShape()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                Type = "circle",
                Center = "2;2",
                Radius = 5,
                Filled = true,
                Color = "255; 0; 255; 0"
            };

            // Act
            var result = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsType<Circle>(result);
        }

        [Fact]
        public void CreateShape_InvalidShape_ShouldThrowArgumentException()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                Type = "hexagon",
                A = "0;0",
                B = "1;1",
                Color = "255; 255; 0; 0"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(shapeData));
            Assert.Equal("Unsupported shape type: hexagon (Parameter 'Type')", exception.Message);
        }

        [Fact]
        public void CreateShape_NullShapeData_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ShapeFactory.CreateShape(null));
        }
    }
}
