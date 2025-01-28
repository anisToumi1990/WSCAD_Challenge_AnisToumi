using System.Windows;

namespace WSCAD_Challenge.Utilities.GeneralHelpers
{
    public static class GeometryHelper
    {
        public static Point ParsePoint(string pointStr)
        {
            var coords = pointStr.Split(';');
            return new Point(double.Parse(coords[0]), double.Parse(coords[1]));
        }
    }
}
