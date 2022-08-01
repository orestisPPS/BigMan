namespace Discretization
{
    public class NaturalX : ICoordinate
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
