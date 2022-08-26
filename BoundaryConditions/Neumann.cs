namespace BoundaryConditions
{
    public class Neumann : BoundaryCondition
    {
        public Neumann(Func <double, double, double> value)
        {
            this.Type = "Neumann";
            this.Value = value;
        }
    }
}