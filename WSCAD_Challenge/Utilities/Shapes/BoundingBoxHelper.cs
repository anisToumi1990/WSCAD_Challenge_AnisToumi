using System;
using System.Collections.Generic;
using System.Windows;
using WSCAD_Challenge.ViewModels;

namespace WSCAD_Challenge.Utilities.Shapes
{
    public static class BoundingBoxHelper
    {
        public static Rect CalculateBoundingBox(IEnumerable<ShapeViewModel> shapeViewModels)
        {
            double minX = double.MaxValue, minY = double.MaxValue;
            double maxX = double.MinValue, maxY = double.MinValue;

            foreach (var shapeViewModel in shapeViewModels)
            {
                var bounds = shapeViewModel.GetBoundingBox();
                minX = Math.Min(minX, bounds.Left);
                minY = Math.Min(minY, bounds.Top);
                maxX = Math.Max(maxX, bounds.Right);
                maxY = Math.Max(maxY, bounds.Bottom);
            }

            // Ensure the width and height are non-negative
            double width = Math.Max(0, maxX - minX);
            double height = Math.Max(0, maxY - minY);

            return new Rect(minX, minY, width, height);
        }
    }
}