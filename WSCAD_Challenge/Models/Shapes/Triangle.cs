using System.Windows;
using System.Windows.Media;

namespace WSCAD_Challenge.Models.Shapes
{
    public class Triangle : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }

        public Triangle(Point a, Point b, Point c, bool filled, Color color)
        {
            A = a;
            B = b;
            C = c;
            Filled = filled;
            Color = color;
        }
    }
}
