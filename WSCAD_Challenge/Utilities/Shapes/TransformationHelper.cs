using System.Windows;

namespace WSCAD_Challenge.Utilities.Shapes
{
    public static class TransformationHelper
    {
        public static Point ScalePoint(Point point, double zoom)
        {
            return new Point(point.X * zoom, point.Y * zoom);
        }
    }
}
