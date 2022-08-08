namespace Discretization
{
    public class NaturalY : Coordinate
    {
        public NaturalY()
        {
            this.Value = -1;
            this.Type = "NaturalY";
        }

        public NaturalY(double value)
        {
            this.Value = value;
            this.Type = "NaturalY";
        }
    }
}