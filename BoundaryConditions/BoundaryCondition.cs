namespace BoundaryConditions
{
    public abstract class BoundaryCondition : IBoundaryCondition
    {
        public string Type { get; set; }
        
        public Func<double, double, double> Value { get; set; }

    }
}