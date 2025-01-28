using System.Windows;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.Utilities.DrawingStrategies
{
    public interface IDrawingStrategy
    {
        private const double DEFAULT_STROKE_THICKNESS = 1;

        UIElement GetShapeToDraw(IShape shape, double zoom);

        Rect GetBoundingBox(IShape shape);
    }
}
