namespace Discretization
{
    public class NaturalX : Coordinate
    {
        public NaturalX()
        {
            this.Type = "NaturalX";
        }

        public NaturalX(double value)
        {
            this.Value = value;
            this.Type = "NaturalX";
        }
    }
}
