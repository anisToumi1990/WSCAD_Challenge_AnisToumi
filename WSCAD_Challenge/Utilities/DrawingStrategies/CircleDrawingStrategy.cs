using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Utilities.Shapes;

namespace WSCAD_Challenge.Utilities.DrawingStrategies
{
    public class CircleDrawingStrategy : IDrawingStrategy
    {
        private const double DEFAULT_STROKE_THICKNESS = 1;

        /// <summary>
        /// Draws a circle using the provided shape's properties and zoom factor.
        /// </summary>
        /// <param name="shape">The circle to draw.</param>
        /// <param name="zoom">Zoom level for scaling the shape.</param>
        /// <returns>A UIElement representing the circle.</returns>
        public UIElement GetShapeToDraw(IShape shape, double zoom)
        {
            if (shape is not Circle circle)
                throw new InvalidCastException($"Expected a Circle shape, but received {shape.GetType().Name}.");

            // Scale the circle's center and radius based on the zoom factor
            circle.Center = TransformationHelper.ScalePoint(circle.Center, zoom);
            circle.Radius *= zoom;

            return CreateEllipse(circle);
        }

        /// <summary>
        /// Calculates the bounding box of the circle.
        /// </summary>
        /// <param name="shape">The circle to calculate the bounding box for.</param>
        /// <returns>A Rect representing the bounding box.</returns>
        public Rect GetBoundingBox(IShape shape)
        {
            if (shape is not Circle circle)
                throw new InvalidCastException($"Expected a Circle shape, but received {shape.GetType().Name}.");

            // Calculate the bounding box based on the circle's center and radius
            double left = circle.Center.X - circle.Radius;
            double top = circle.Center.Y - circle.Radius;
            double diameter = 2 * circle.Radius;

            return new Rect(left, top, diameter, diameter);
        }

        /// <summary>
        /// Creates a styled ellipse representing the circle.
        /// </summary>
        /// <param name="circle">The circle shape to create the ellipse from.</param>
        /// <returns>A styled Ellipse instance.</returns>
        public static Ellipse CreateEllipse(Circle circle)
        {
            return new Ellipse
            {
                Width = 2 * circle.Radius,
                Height = 2 * circle.Radius,
                Stroke = new SolidColorBrush(circle.Color),
                StrokeThickness = DEFAULT_STROKE_THICKNESS,
                Fill = circle.Filled ? new SolidColorBrush(circle.Color) : null
            };
        }
    }
}
