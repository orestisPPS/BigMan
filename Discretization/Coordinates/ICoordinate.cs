namespace Discretization
{
    public enum CoordinateType
    {
        NaturalX,
        NaturalY,
        NaturalZ,
        ParametricKsi,
        ParametricIta,
        ComputationalGiota,
        TemplateX,
        TemplateY,
        TemplateZ,
        NaturalR,
        NatruralTheta,
        NaturalPhi,
    }
    public interface ICoordinate
    {
        public double Value {get; set;}
        public CoordinateType Type {get; }
    }
}