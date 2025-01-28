using System.Collections.Generic;
using WSCAD_Challenge.Models.Shapes;

namespace WSCAD_Challenge.ViewModels
{
    public interface IShapeLoader
    {
        List<IShape> LoadShapes(string filePath);
    }
}
