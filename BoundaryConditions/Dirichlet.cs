namespace BoundaryConditions
{
    public class Dirichlet : IBoundaryCondition
    {   
        public string Type => "Dirichlet";
        public Func<double, double, double> Value { get; set; }

        public Dirichlet(Func<double, double, double> value)
        {
            this.Value = value;
        }
        public Dirichlet()
        {
            
        }
    }
}