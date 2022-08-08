namespace Discretization
{
    public class ComputationalKsi : Coordinate
    {
        public string Type => "ComputationalKsi";
        public ComputationalKsi()
        {

        }

        public ComputationalKsi(double value)
        {
            this.Value = value;
        }
    }
}