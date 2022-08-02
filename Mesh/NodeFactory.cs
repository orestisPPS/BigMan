using utility;
using Discretization;
using Constitutive;
namespace Mesh
{
    public class NodeFactory
    {
        /// <summary>
        /// Dictionary with the boundary nodes.
        /// The key is the boundary id (0 -> bot, 1 -> right, 2 -> top, 3 ->left)
        /// The value is a double array with the node coordinates
        /// </summary>
        /// <value></value>
        public DomainBoundary[] Boundaries {get; set;}

        /// <summary>
        /// Input: A 2 dimensional array which maps the nodes in the computational
        /// domain, in the order they they appear in the domain (from left to right)
        /// </summary>
        /// <value></value>
        public Node[,] Nodes {get; set;}

        /// <summary>
        /// A dictionary with key the global id of the node and as value an node object
        /// in the order they they appear in the domain (from left to right)
        /// </summary>
        /// <value></value>
        public Dictionary<int, Node> NodesDictionary {get; set;}

        /// <summary>
        /// Contains the boundary nodes of the computational mesh
        /// </summary>
        /// <value></value>
        private List<Node> BoundaryNodes = new List<Node>();
        
        private int nnx => Boundaries[0].BoundaryNodesCoordinates.GetLength(0);
        private int nny => Boundaries[1].BoundaryNodesCoordinates.GetLength(0);

        public NodeFactory(DomainBoundary[] boundaries)
        {
            this.Boundaries = boundaries;
            Nodes = new Node[nny, nnx];
            NodesDictionary = new Dictionary<int, Node>();
            CreateNodes();
            AssignGlobalIds();

            for (int row = 0; row < nny; row++)
            {
                for (int column = 0; column < nnx; column++)
                {
                    var node =  Nodes[row, column];
                    Console.WriteLine(node.Id.Global + " " + node.Id.Internal + " " + node.Id.Boundary + " "
                    + node.Coordinates[CoordinateType.NaturalX].Value + " " + node.Coordinates[CoordinateType.NaturalY].Value);
                }
            }

        }

        private void CreateNodes()
        {
            var boundaryCounter = 0;
            //Bottom Boundary
            for (int i = 0; i < nnx; i++)
            {
                Nodes[0, i] = InitializeBoundaryNode(positionInBoundary : i, boundaryId : 0, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Right Boundary
            for (int i = 1; i < nny; i++)
            {
                Nodes[0, i] = InitializeBoundaryNode(positionInBoundary : i, boundaryId : 1, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Top Boundary
            for (int i = 1; i < nnx; i++)
            {
                Nodes[0, i] = InitializeBoundaryNode(positionInBoundary : i, boundaryId : 2, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Left Boundary
            for (int i = 1; i < nny - 1; i++)
            {
                Nodes[0, i] = InitializeBoundaryNode(positionInBoundary : i, boundaryId : 3, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Internal 
            var internalCounter = 0;
            for (int row = 1; row < nny - 1; row++)
            {
                for (int column = 1; column < nnx - 1; column++)
                {
                    Nodes[row, column] = InitializeInternalNode(positionInternal : internalCounter);
                    internalCounter++;
                }
            }
        }

        private Node InitializeBoundaryNode(int positionInBoundary, int boundaryId , int nodalBoundaryId)
        {
            var node = new Node();
            AssignBoundaryNodeCoordinates(positionInBoundary, boundaryId, node);
            AssignValueToBoundaryDOF(positionInBoundary, boundaryId, node);
            node.Id.Boundary = nodalBoundaryId;
            return node;
        }
        private void AssignBoundaryNodeCoordinates(int positionInBoundary, int boundaryId, Node node)
        {
            node.Coordinates.Add(CoordinateType.NaturalX, new NaturalX());
            node.Coordinates.Add(CoordinateType.NaturalY, new NaturalY());
            node.Coordinates[CoordinateType.NaturalX].Value = Boundaries[boundaryId].BoundaryNodesCoordinates[positionInBoundary, 0];
            node.Coordinates[CoordinateType.NaturalY].Value = Boundaries[boundaryId].BoundaryNodesCoordinates[positionInBoundary, 1];
        }
        private void AssignValueToBoundaryDOF(int positionInBoundary, int boundaryId, Node node)
        {
            node.DegreesOfFreedom.Add(DegreeOfFreedomType.X, new X());
            node.DegreesOfFreedom.Add(DegreeOfFreedomType.Y, new Y());
            node.DegreesOfFreedom[DegreeOfFreedomType.X].Value = node.Coordinates[CoordinateType.NaturalX].Value;
            node.DegreesOfFreedom[DegreeOfFreedomType.Y].Value = node.Coordinates[CoordinateType.NaturalY].Value;
        }
        private Node InitializeInternalNode(int positionInternal)
        {
            var node = new Node();
            node.DegreesOfFreedom.Add(DegreeOfFreedomType.X, new X());
            node.DegreesOfFreedom.Add(DegreeOfFreedomType.Y, new Y());
            node.Id.Internal = positionInternal;
            return node;
        }


        private void  AssignGlobalIds()
        {
            var k = 0;
            for (int row = 0; row < nny; row++)
            {
                for (int column = 0; column < nnx; column++)
                {
                    Nodes[row, column].Id.Global = k;
                    k++;
                }
            }
        }
    }
}