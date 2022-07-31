namespace Discretization
{
    /// <summary>
    /// A class containing all the position values of the node in all systems examined.
    /// Can be Cartesian (x)(ξ) or Spherical (r)
    /// </summary>
    public class CoordinateOne 
    {
        public Natural Natural {get; set;} 
        public Computational Computational {get; set;} 
        public Template Template {get; set;} 

        
        public CoordinateOne()
        {
        }
    }
}