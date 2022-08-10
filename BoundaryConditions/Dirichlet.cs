namespace BoundaryConditions
{
    public class Dirichlet : BoundaryCondition
    {
        public Dirichlet(Func<double, double, double> value)
        {
            this.Value = value;
        }
    }
}