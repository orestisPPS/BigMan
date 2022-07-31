namespace Discretization
{
    /// <summary>
    /// A class containing the position values of the node in Direction Two.
    /// Can be Cartesian (y)(η) or Spherical (θ)
    /// </summary>
    public class CoordinateTwo : ICoordinate
    {
        public Natural Natural {get; set;}
        public Computational Computational {get; set;}
        public Template Template {get; set;}
        public CoordinateTwo()
        {

        }
    }
}
