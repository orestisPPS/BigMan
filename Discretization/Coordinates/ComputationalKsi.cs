namespace Discretization
{
    public class ParametricKsi : IDirectionTwo
    {
        public CoordinateType Type => CoordinateType.ParametricKsi;
        public double Value { get; set; }
        public ParametricKsi()
        {

        }

        public ParametricKsi(double value)
        {
            this.Value = value;
        }
    }
}