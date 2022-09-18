namespace BoundaryConditions
{
    public interface IBoundaryCondition
    {
        public string Type { get; }
    
        public Func<double, double, double> Value { get; set; }

    }
}