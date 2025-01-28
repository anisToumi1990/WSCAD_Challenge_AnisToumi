using System.Windows;
using System.Windows.Media;

namespace WSCAD_Challenge.Models.Shapes
{
    public class Circle : IShape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }

        public Circle(Point center, double radius, bool filled, Color color)
        {
            Center = center;
            Radius = radius;
            Filled = filled;
            Color = color;
        }
    }
}
