namespace Discretization
{
    public class NaturalY : IDirectionOne
    {
        public CoordinateType Type => CoordinateType.NaturalY;
        public double Value { get; set; }
        public NaturalY()
        {

        }

        public NaturalY(double value)
        {
            this.Value = value;
        }
    }
}
