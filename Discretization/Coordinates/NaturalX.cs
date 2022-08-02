namespace Discretization
{
    public class NaturalX : Coordinate
    {
        public double Value { get; set; }
        public string Type { get; set; }

        public NaturalX()
        {
            this.Value = -1;
            this.Type = "NaturalX";
        }
    }
}
