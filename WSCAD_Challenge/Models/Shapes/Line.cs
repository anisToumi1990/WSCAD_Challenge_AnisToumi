using System.Windows;
using System.Windows.Media;


namespace WSCAD_Challenge.Models.Shapes
{
    public class Line : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Color Color { get; set; }

        public Line(Point a, Point b, Color color)
        {
            A = a;
            B = b;
            Color = color;
        }
    }
}
