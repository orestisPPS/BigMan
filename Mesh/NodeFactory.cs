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
        
        private int nnx => Boundaries[0].boundaryNodes.Count();
        private int nny => Boundaries[1].boundaryNodes.Count();

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
            for (int column = 0; column < nny; column++)
            {
                Nodes[0, column] = CreateBottomBoundaryNode(column);
                Nodes[0, column].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Right Boundary
            for (int row = 0; row < nnx - 1; row++)
            {
                Nodes[row, nny - 1] = CreateRightBoundaryNode(row);
                Nodes[row, nny - 1].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Top Boundary
            for (int column = 1; column < nny - 1; column++)
            {
                Nodes[nnx - 1, column] = CreateTopBoundaryNode(column);
                Nodes[nnx - 1, column].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Left Boundary
            for (int row = 1; row < nnx - 1; row++)
            {
                Nodes[row, 0] = CreateLeftBoundaryNode(row);
                Nodes[row, 0].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Internal 
            var internalCounter = 0;
            for (int row = 1; row < nnx - 1; row++)
            {
                for (int column = 1; column < nny - 1; column++)
                {
                    Nodes[row, column] = CreateInternalNode();
                    Nodes[row, column].Id.Internal = internalCounter; 
                    internalCounter++;
                }
            }
        }

        private Node CreateBottomBoundaryNode(int column)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[0][column,0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[0][column,1];
            return node;
        }
        private Node CreateRightBoundaryNode(int row)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[1][row, 0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[1][row, 1];
            return node;  
        }
        
        private Node CreateTopBoundaryNode(int column)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[2][nnx -1 - column,0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[2][nnx -1 - column,1];
            return node;
        }

        private Node CreateLeftBoundaryNode(int row)
        {
            var node = InitializeNode();
            node.Coordinates[new CoordinateType("PositionX")] = Boundaries[3][row, 0];
            node.Coordinates[new CoordinateType("PositionY")] = Boundaries[3][row, 1];
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
                }
            }
        }
    }
}