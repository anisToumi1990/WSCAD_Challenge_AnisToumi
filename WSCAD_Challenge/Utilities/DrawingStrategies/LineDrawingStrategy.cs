using System;
using System.Windows;
using System.Windows.Media;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Utilities.Shapes;

namespace WSCAD_Challenge.Utilities.DrawingStrategies
{
    public class LineDrawingStrategy : IDrawingStrategy
    {
        private const double DEFAULT_STROKE_THICKNESS = 1;

        /// <summary>
        /// Draws a line using the provided shape's properties and zoom factor.
        /// </summary>
        /// <param name="shape">The line to draw.</param>
        /// <param name="zoom">Zoom level for scaling the shape.</param>
        /// <returns>A UIElement representing the line.</returns>
        public UIElement GetShapeToDraw(IShape shape, double zoom)
        {
            if (shape is not Line line)
                throw new InvalidCastException($"Expected a Line shape, but received {shape.GetType().Name}.");

            // Scale the start and end points of the line based on the zoom factor
            Point start = TransformationHelper.ScalePoint(line.A, zoom);
            Point end = TransformationHelper.ScalePoint(line.B, zoom);

            return CreateLineShape(start, end, line.Color);
        }

        /// <summary>
        /// Calculates the bounding box of the line.
        /// </summary>
        /// <param name="shape">The line to calculate the bounding box for.</param>
        /// <returns>A Rect representing the bounding box.</returns>
        public Rect GetBoundingBox(IShape shape)
        {
            if (shape is not Line line)
                throw new InvalidCastException($"Expected a Line shape, but received {shape.GetType().Name}.");

            // Calculate the bounding box by finding the min and max coordinates
            double minX = Math.Min(line.A.X, line.B.X);
            double minY = Math.Min(line.A.Y, line.B.Y);
            double maxX = Math.Max(line.A.X, line.B.X);
            double maxY = Math.Max(line.A.Y, line.B.Y);

            return new Rect(minX, minY, maxX - minX, maxY - minY);
        }

        /// <summary>
        /// Creates a styled Line element for rendering on the canvas.
        /// </summary>
        /// <param name="start">The starting point of the line.</param>
        /// <param name="end">The ending point of the line.</param>
        /// <param name="color">The color of the line.</param>
        /// <returns>A styled Line instance.</returns>
        private static System.Windows.Shapes.Line CreateLineShape(Point start, Point end, Color color)
        {
            return new System.Windows.Shapes.Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = end.X,
                Y2 = end.Y,
                Stroke = new SolidColorBrush(color),
                StrokeThickness = DEFAULT_STROKE_THICKNESS
            };
        }
    }
}
