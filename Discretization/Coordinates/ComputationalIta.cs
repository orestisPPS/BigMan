namespace Discretization
{
    public class ComputationalIta : Coordinate
    {
        public string Type => "ComputationalIta";
        public ComputationalIta()
        {

        }
        public ComputationalIta(double value)
        {
            this.Value = value;
        }
    }
}