namespace Discretization
{
    public class NaturalX : Coordinate
    {
        public string Type {get; internal set;}
        public NaturalX()
        {
            this.Type = "NaturalX";
        }

        public NaturalX(double value)
        {
            this.Value = value;
        }
    }
}
