using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WSCAD_Challenge.Models;
using WSCAD_Challenge.Models.Data;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.ViewModels
{
    public class ShapeLoader : IShapeLoader
    {
        public List<IShape> LoadShapes(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            try
            {
                // Read JSON from file
                var json = File.ReadAllText(filePath);

                // Deserialize JSON into shape data
                var shapeData = JsonConvert.DeserializeObject<List<ShapeData>>(json);

                if (shapeData == null || !shapeData.Any())
                    return new List<IShape>();

                // Use LINQ to create shapes and filter out invalid ones
                return shapeData
                    .Select(ShapeFactory.CreateShape)
                    .Where(shape => shape != null)
                    .ToList();
            }
            catch (IOException ex)
            {
                throw new ApplicationException($"Error reading the file: {filePath}", ex);
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("Invalid JSON format in the input file.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while loading shapes.", ex);
            }
        }
    }
}
