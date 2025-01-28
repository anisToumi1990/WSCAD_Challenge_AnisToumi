using System.Windows.Media;

namespace WSCAD_Challenge.Utilities.GeneralHelpers
{
    public static class ColorHelper
    {
        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            return Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
        }
    }
}
