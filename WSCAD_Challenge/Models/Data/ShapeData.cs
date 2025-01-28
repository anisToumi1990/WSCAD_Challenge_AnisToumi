namespace WSCAD_Challenge.Models.Data
{
    public class ShapeData
    {
        public string Type { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
        public string Color { get; set; }

        // Helper method to convert the color string to a Color object
        public (byte A, byte R, byte G, byte B) GetColor()
        {
            var colorValues = Color.Split(';');
            return (
                byte.Parse(colorValues[0]),
                byte.Parse(colorValues[1]),
                byte.Parse(colorValues[2]),
                byte.Parse(colorValues[3])
            );
        }
    }
}
