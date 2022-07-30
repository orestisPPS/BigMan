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

        /// <summary>
        /// Contains the nodes that form the boundary
        /// </summary>
        /// <typeparam name="Node">Nodes</typeparam>
        /// <returns>BoundaryNodes</returns>
        public List<Node> boundaryNodes = new List<Node>();


        public DomainBoundary(int id, double[,] boundaryNodesCoordinates)
        {
            this.Id = id;
            this.BoundaryNodesCoordinates = boundaryNodesCoordinates;
            CreateNodes(); 
        }

        private void CreateNodes()
        {
            for (int i = 0; i < BoundaryNodesCoordinates.GetLength(0); i++)
            {
                var newNode = new Node();
                var NaturalX = new CoordinateType("NaturalX");
                var NaturalY = new CoordinateType("NaturalY");
                newNode.Coordinates.Add(NaturalX, BoundaryNodesCoordinates[i, 0]);
                newNode.Coordinates.Add(NaturalY, BoundaryNodesCoordinates[i, 1]); //    NatCoord.X = BoundaryNodesCoordinates[i,0];
                newNode.Id.Boundary = Id;
                boundaryNodes.Add(newNode);
            }
        }
    }
}

