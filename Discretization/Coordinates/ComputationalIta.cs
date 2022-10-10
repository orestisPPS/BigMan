namespace Discretization
{
    public class ParametricIta : IDirectionTwo
    {
        public CoordinateType Type => CoordinateType.ParametricIta;
        public double Value { get; set; }
        public ParametricIta()
        {

        }

        public ParametricIta(double value)
        {
            this.Value = value;
        }
    }
}