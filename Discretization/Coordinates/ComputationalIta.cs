namespace Discretization
{
    public class ComputationalIta : Coordinate
    {
        public double Value {get; set;}
        public string Type {get; set;}
        public ComputationalIta()
        {
            this.Value = -1;
            this.Type = "ComputationalIta";
        }
    }
}