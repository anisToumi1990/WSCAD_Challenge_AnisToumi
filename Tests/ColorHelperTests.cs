using WSCAD_Challenge.Utilities.GeneralHelpers;

namespace WSCAD_Challenge.Tests
{
    public class ColorHelperTests
    {
        [Fact]
        public void FromArgb_ValidColorValues_ShouldReturnCorrectColor()
        {
            // Arrange
            byte a = 255, r = 0, g = 255, b = 128;

            // Act
            var color = ColorHelper.FromArgb(a, r, g, b);

            // Assert
            Assert.Equal(a, color.A);
            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
        }
    }
}
