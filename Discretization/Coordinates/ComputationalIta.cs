namespace Discretization
{
    public class ComputationalIta : IDirectionTwo
    {
        public CoordinateType Type => CoordinateType.ComputationalIta;
        public double Value { get; set; }
        public ComputationalIta()
        {

        }

        public ComputationalIta(double value)
        {
            this.Value = value;
        }
    }
}