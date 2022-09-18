namespace Discretization
{
    public class NaturalX : IDirectionOne
    {
        public CoordinateType Type => CoordinateType.NaturalX;
        public double Value { get; set; }
        public NaturalX()
        {

        }

        public NaturalX(double value)
        {
            this.Value = value;
        }
    }
}
