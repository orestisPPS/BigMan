namespace Discretization
{
    public enum CoordinateType
    {
        NaturalX,
        NaturalY,
        TemplateX,
        TemplateY,
        ComputationalKsi,
        ComputationalIta
    }

    public class Coordinate : ICoordinate
    {
        public double Value { get; set; }
        public string Type { get; set; }
    }

}