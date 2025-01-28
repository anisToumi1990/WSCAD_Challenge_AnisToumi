using System;
using System.Collections.Generic;
using WSCAD_Challenge.ViewModels;

namespace WSCAD_Challenge.Utilities.Shapes
{
    public static class FitShapesToCanvasHelper
    {
        public static double FitShapesToCanvas(IEnumerable<ShapeViewModel> shapeViewModels, double canvasWidth, double canvasHeight)
        {
            var boundingBox = BoundingBoxHelper.CalculateBoundingBox(shapeViewModels);
            // Calculate zoom factors for width and height
            double scaleX = canvasWidth / boundingBox.Width;
            double scaleY = canvasHeight / boundingBox.Height;
            double scale = Math.Min(scaleX, scaleY); // To maintain aspect ratio

            // Set the zoom level
            return scale;
        }
    }
}