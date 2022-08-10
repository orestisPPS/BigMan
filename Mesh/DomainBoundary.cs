using Discretization;
using Constitutive;
namespace Mesh
{
    public class BoundaryCondition
    {

        /// <summary>
        /// 0 -> bottom, 1 -> right, 2 -> top, 3 -> left
        /// </summary>
        /// <value></value>
        public int Id {get;}

        /// <summary>
        /// A dictionary containing the boundary 
        /// </summary>
        /// <value></value>
        public Dictionary<DegreeOfFreedomType, Func <double, double, double> > BoundaryConditionValues {get;}

        public DomainBoundary(int id, double[,] boundaryNodesCoordinates)
        {
            this.Id = id;
            this.BoundaryNodesCoordinates = boundaryNodesCoordinates;
        }
    }
}

