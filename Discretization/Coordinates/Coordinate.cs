namespace Discretization
{
    public class Coordinate : ICoordinate
    {
        public double Value {get; set;} = -1d;
        public string Type {get; set;} = "Coordinate";

        public Coordinate()
        {
        }
    }

}