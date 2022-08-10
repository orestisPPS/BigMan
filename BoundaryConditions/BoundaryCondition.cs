namespace BoundaryConditions
{
    public class BoundaryCondition : IBoundaryCondition
    {
        public string Type { get; set; }
        public Func<double, double, double> Value { get; set; }
    }
}