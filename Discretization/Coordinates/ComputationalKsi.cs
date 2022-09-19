namespace Discretization
{
    public class ComputationalKsi : IDirectionTwo
    {
        public CoordinateType Type => CoordinateType.ComputationalKsi;
        public double Value { get; set; }
        public ComputationalKsi()
        {

        }

        public ComputationalKsi(double value)
        {
            this.Value = value;
        }
    }
}