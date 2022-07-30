using utility;
using Discretization;
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
            Nodes = new Node[nnx, nny];
            NodesDictionary = new Dictionary<int, Node>();
            CreateNodes();
            AssignGlobalIds();
        }

        private void CreateNodes()
        {
            var boundaryCounter = 0;
            //Bottom Boundary
            for (int i = 0; i < nnx; i++)
            {
                Nodes[0, i] = CreateBottomBoundaryNode(i);
                Nodes[0, i].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Right Boundary
            for (int i = 1; i < nny; i++)
            {
                Nodes[i, nny - 1] = CreateRightBoundaryNode(i);
                Nodes[i, nny - 1].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Top Boundary
            for (int i = 0; i < nny - 1; i++)
            {
                Nodes[nnx - 1, i] = CreateTopBoundaryNode(i);
                Nodes[nnx - 1, i].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Left Boundary
            for (int i = 1; i < nnx - 1; i++)
            {
                Nodes[i, 0] = CreateLeftBoundaryNode(i);
                Nodes[i, 0].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Internal 
            var internalCounter = 0;
            for (int i = 1; i < nnx - 1; i++)
            {
                for (int j = 1; j < nny - 1; j++)
                {
                    Nodes[i, j] = CreateInternalNode();
                    Nodes[i, j].Id.Internal = internalCounter; 
                    internalCounter++;
                }
            }
        }

        private Node CreateBottomBoundaryNode(int i)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[0].BoundaryNodesCoordinates[i,0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[0].BoundaryNodesCoordinates[i,1];
            return node;
        }
        private Node CreateRightBoundaryNode(int i)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[1].BoundaryNodesCoordinates[i, 0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[1].BoundaryNodesCoordinates[i, 1];
            return node;  
        }
        
        private Node CreateTopBoundaryNode(int i)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[2].BoundaryNodesCoordinates[nnx -1 - i,0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[2].BoundaryNodesCoordinates[nnx -1 - i,1];
            return node;
        }

        private Node CreateLeftBoundaryNode(int i)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[3].BoundaryNodesCoordinates[i, 0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[3].BoundaryNodesCoordinates[i, 1];
            return node;
        }
        private Node CreateInternalNode()
        {
            var node = InitializeNode();
            return node;
        }

        private Node InitializeNode()
        {
            var node = new Node();
            node.DegreesOfFreedom.Add(new DegreeOfFreedomType("PositionX"), -1);
            node.DegreesOfFreedom.Add(new DegreeOfFreedomType("PositionY"), -1);
            node.Coordinates.Add(new CoordinateType("NaturalX"), -1);
            node.Coordinates.Add(new CoordinateType("NaturalY"), -1);
            
            return node;
        }

        private void  AssignGlobalIds()
        {
            var k = 0;
            for (int row = 0; row < nnx; row++)
            {
                for (int column = 0; column < nny; column++)
                {
                    Nodes[row, column].Id.Global = k;
                    NodesDictionary.Add(k, Nodes[row, column]);
                    k++;
                    Console.WriteLine(Nodes[row, column].Id.Global + " " + Nodes[row, column].Id.Internal + " " + Nodes[row, column].Id.Boundary);// + " " + Nodes[row, column].Coordinates[new CoordinateType("NaturalX")] + " " + Nodes[row, column].Coordinates[new CoordinateType("NaturalY")]);
                }
            }
        }
    }
}