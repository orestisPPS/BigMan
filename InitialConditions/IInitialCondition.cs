namespace BoundaryConditions
{
    public interface IBoundaryCondition
    {
        public string Type { get; set; }
    
        public Func<double, double, double> Value { get; set; }

    }
}