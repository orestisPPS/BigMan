namespace Discretization
{
    public class ComputationalKsi : ICoordinate
    {
        public double Value {get; set;}
        public string Type {get; set;}
        public ComputationalKsi()
        {
            this.Value = -1;
            this.Type = "ComputationalKsi";
        }
    }
}