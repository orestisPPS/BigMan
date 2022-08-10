namespace Discretization
{
    public class ComputationalKsi : Coordinate
    {
        public ComputationalKsi()
        {
            this.Type = "ComputationalKsi";
        }

        public ComputationalKsi(double value)
        {
            this.Value = value;
            this.Type = "ComputationalKsi";
        }
    }
}