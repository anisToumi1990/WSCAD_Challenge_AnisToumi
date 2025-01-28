using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD_Challenge.Utilities.Shapes;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.Utilities.DrawingStrategies
{
    public class TriangleDrawingStrategy : IDrawingStrategy
    {
        private const double DEFAULT_STROKE_THICKNESS = 1;
        /// <summary>
        /// Draws a triangle on the provided canvas using the shape's properties.
        /// </summary>
        /// <param name="shape">The triangle to draw.</param>
        /// <param name="zoom">Zoom level for scaling the shape.</param>
        /// <returns>A UIElement representing the triangle.</returns>
        public UIElement GetShapeToDraw(IShape shape, double zoom)
        {
            if (shape is not Triangle triangle)
                throw new InvalidCastException($"Expected a Triangle shape, but received {shape.GetType().Name}.");

            // Scale the triangle vertices
            Point a = TransformationHelper.ScalePoint(triangle.A, zoom);
            Point b = TransformationHelper.ScalePoint(triangle.B, zoom);
            Point c = TransformationHelper.ScalePoint(triangle.C, zoom);

            // Create and style the triangle as a polygon
            return CreatePolygon(new PointCollection { a, b, c }, triangle.Color, triangle.Filled);
        }

        /// <summary>
        /// Calculates the bounding box of the triangle.
        /// </summary>
        /// <param name="shape">The triangle to calculate the bounding box for.</param>
        /// <returns>A Rect representing the bounding box.</returns>
        public Rect GetBoundingBox(IShape shape)
        {
            if (shape is not Triangle triangle)
                throw new InvalidCastException($"Expected a Triangle shape, but received {shape.GetType().Name}.");

            // Calculate the bounding box by finding min and max coordinates
            double minX = Math.Min(Math.Min(triangle.A.X, triangle.B.X), triangle.C.X);
            double minY = Math.Min(Math.Min(triangle.A.Y, triangle.B.Y), triangle.C.Y);
            double maxX = Math.Max(Math.Max(triangle.A.X, triangle.B.X), triangle.C.X);
            double maxY = Math.Max(Math.Max(triangle.A.Y, triangle.B.Y), triangle.C.Y);

            return new Rect(minX, minY, maxX - minX, maxY - minY);
        }

        /// <summary>
        /// Creates a styled polygon representing the triangle.
        /// </summary>
        /// <param name="points">The collection of triangle vertices.</param>
        /// <param name="color">The color of the triangle.</param>
        /// <param name="isFilled">Indicates whether the triangle should be filled.</param>
        /// <returns>A styled Polygon instance.</returns>
        private static Polygon CreatePolygon(PointCollection points, Color color, bool isFilled)
        {
            var polygon = new Polygon
            {
                Points = points,
                Stroke = new SolidColorBrush(color),
                StrokeThickness = DEFAULT_STROKE_THICKNESS
            };

            if (isFilled)
            {
                polygon.Fill = new SolidColorBrush(color);
            }

            return polygon;
        }
    }
}
