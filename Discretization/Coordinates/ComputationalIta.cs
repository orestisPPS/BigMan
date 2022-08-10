namespace Discretization
{
    public class ComputationalIta : Coordinate
    {
        public ComputationalIta()
        {
            this.Type = "ComputationalIta";
        }
        public ComputationalIta(double value)
        {
            this.Value = value;
            this.Type = "ComputationalIta";
        }
    }
}