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

    public class Coordinates : ICoordinate
    {
        public double Value { get; set; }
        public string Type { get; set; }
    }

}