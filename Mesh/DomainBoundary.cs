using Discretization;
namespace Mesh
{
    public class DomainBoundary
    {

        /// <summary>
        /// 0 -> bottom, 1 -> right, 2 -> top, 3 -> left
        /// </summary>
        /// <value></value>
        public int Id {get;}

        /// <summary>
        /// Contains the cooridinates of the boundary nodes.
        /// </summary>
        /// <value></value>
        public double[,] BoundaryNodesCoordinates {get;}

        public DomainBoundary(int id, double[,] boundaryNodesCoordinates)
        {
            this.Id = id;
            this.BoundaryNodesCoordinates = boundaryNodesCoordinates;
        }
    }
}

