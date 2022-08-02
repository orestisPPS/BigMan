namespace Discretization
{
    public class NaturalY : Coordinate
    {
        public double Value { get; set; }
        public string Type { get; set; }

        public NaturalY()
        {
            this.Value = -1;
            this.Type = "NaturalY";
        }
    }
}