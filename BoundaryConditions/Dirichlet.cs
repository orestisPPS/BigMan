namespace BoundaryConditions
{
    public class Dirichlet : BoundaryCondition
    {   
        public Dirichlet(Func<double, double, double> value)
        {
            this.Type = "Dirichlet";
            this.Value = value;
        }
    }
}