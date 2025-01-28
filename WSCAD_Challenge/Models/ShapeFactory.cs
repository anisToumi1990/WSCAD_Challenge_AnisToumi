using System;
using System.Windows.Media;
using WSCAD_Challenge.Models.Data;
using WSCAD_Challenge.Models.Shapes;
using WSCAD_Challenge.Utilities.GeneralHelpers;

namespace WSCAD_Challenge.Models
{
    public static class ShapeFactory
    {
        public static IShape CreateShape(ShapeData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            // Get the color for the shape
            var color = GetColor(data);

            // Determine shape type and create the appropriate shape
            return data.Type.ToLower() switch
            {
                "line" => CreateLine(data, color),
                "circle" => CreateCircle(data, color),
                "triangle" => CreateTriangle(data, color),
                _ => throw new ArgumentException($"Unsupported shape type: {data.Type}", nameof(data.Type))
            };
        }

        private static IShape CreateLine(ShapeData data, Color color)
        {
            return new Line(
                GeometryHelper.ParsePoint(data.A),
                GeometryHelper.ParsePoint(data.B),
                color
            );
        }

        private static IShape CreateCircle(ShapeData data, Color color)
        {
            return new Circle(
                GeometryHelper.ParsePoint(data.Center),
                data.Radius,
                data.Filled,
                color
            );
        }

        private static IShape CreateTriangle(ShapeData data, Color color)
        {
            return new Triangle(
                GeometryHelper.ParsePoint(data.A),
                GeometryHelper.ParsePoint(data.B),
                GeometryHelper.ParsePoint(data.C),
                data.Filled,
                color
            );
        }

        private static Color GetColor(ShapeData data)
        {
            // Get and convert the color data
            var colorData = data.GetColor();
            return ColorHelper.FromArgb(colorData.A, colorData.R, colorData.G, colorData.B);
        }
    }
}
