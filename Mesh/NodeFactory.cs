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
            Nodes = new Node[nny, nnx];
            NodesDictionary = new Dictionary<int, Node>();
            CreateNodes();
            AssignGlobalIds();

            var node = new Node();
            var PositionX = new PositionX();
            var PositionY = new PositionY();
            var NaturalX = new NaturalX();
            var NaturalY = new NaturalY();
node.Coordinates.Add(NaturalX, -1);
                        foreach (var coordinate in node.Coordinates)
            {
                if (coordinate is NaturalX)
                {
                    Console.WriteLine("Found NaturalX");
                }
            }
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
                Nodes[i, nnx - 1] = CreateRightBoundaryNode(i);
                Nodes[i, nnx - 1].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Top Boundary
            for (int i = 1; i < nnx; i++)
            {
                Nodes[nny - 1, nnx - 1 - i] = CreateTopBoundaryNode(i);
                Nodes[nny - 1, nnx - 1 - i].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Left Boundary
            for (int i = 1; i < nny - 1; i++)
            {
                Nodes[nny - 1 - i, 0] = CreateLeftBoundaryNode(i);
                Nodes[nny - 1 - i, 0].Id.Boundary = boundaryCounter;
                boundaryCounter++;
            }
            //Internal 
            var internalCounter = 0;
            for (int row = 1; row < nny - 1; row++)
            {
                for (int column = 1; column < nnx - 1; column++)
                {
                    Nodes[row, column] = CreateInternalNode();
                    Nodes[row, column].Id.Internal = internalCounter; 
                    internalCounter++;
                }
            }
        }

        private Node CreateBottomBoundaryNode(int i)
        {
            var node = InitializeNode();
            // node.Coordinates[new CoordinateType("PositionX")] = Boundaries[0].BoundaryNodesCoordinates[i,0];
            // node.Coordinates[new CoordinateType("PositionY")] = Boundaries[0].BoundaryNodesCoordinates[i,1];
            return node;
        }
        private Node CreateRightBoundaryNode(int i)
        {
            var node = InitializeNode();
            // node.Coordinates[new CoordinateType("PositionX")] = Boundaries[1].BoundaryNodesCoordinates[i, 0];
            // node.Coordinates[new CoordinateType("PositionY")] = Boundaries[1].BoundaryNodesCoordinates[i, 1];
            return node;  
        }
        
        private Node CreateTopBoundaryNode(int i)
        {
            var node = InitializeNode();
            // node.Coordinates[new CoordinateType("PositionX")] = Boundaries[2].BoundaryNodesCoordinates[i,0];
            // node.Coordinates[new CoordinateType("PositionY")] = Boundaries[2].BoundaryNodesCoordinates[i,1];
            return node;
        }

        private Node CreateLeftBoundaryNode(int i)
        {
            var node = InitializeNode();
            
            //node.Coordinates[NaturalX()] = Boundaries[3].BoundaryNodesCoordinates[i,0];
            // Console.WriteLine(node.Coordinates[new NaturalX()].GetHashCode().                          // NaturalX.ReferenceEquals(null)]);
            // node.Coordinates[new NaturalX()] = 1E6;
            // Console.WriteLine(node.Coordinates[new NaturalX()]);
            // // node.Coordinates[NaturalX] = Boundaries[3].BoundaryNodesCoordinates[i,0];
            // node.Coordinates["PositionX")] = Boundaries[3].BoundaryNodesCoordinates[i, 0];
            // node.Coordinates["PositionY")] = Boundaries[3].BoundaryNodesCoordinates[i, 1];
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
            var PositionX = new PositionX();
            var PositionY = new PositionY();
            var NaturalX = new NaturalX();
            var NaturalY = new NaturalY();
            node.DegreesOfFreedom.Add(PositionX, PositionX.Value);
            node.DegreesOfFreedom.Add(PositionY, PositionY.Value);
            node.Coordinates.Add(NaturalX, NaturalX.Value);
            node.Coordinates.Add(NaturalY, NaturalY.Value);
            return node;
        }
        

        private void  AssignGlobalIds()
        {
            var k = 0;
            for (int row = 0; row < nny; row++)
            {
                for (int column = 0; column < nnx; column++)
                {
                    // Nodes[row, column].Id.Global = k;
                    // NodesDictionary.Add(k, Nodes[row, column]);
                    // k++;
                    // Console.WriteLine(Nodes[row, column].Id.Global + " " + Nodes[row, column].Id.Internal + " " + Nodes[row, column].Id.Boundary);// + " " + Nodes[row, column].Coordinates[new CoordinateType("NaturalX")] + " " + Nodes[row, column].Coordinates[new CoordinateType("NaturalY")]);
                    // Nodes[0,0].Coordinates.TryGetValue(new NaturalX().GetHashCode(),)      [new NaturalX()] = 1;
                    
                        
                    foreach (var coordinate in Nodes[row, column].Coordinates)
                    {
                        if (coordinate is NaturalX)
                        {
                            Console.WriteLine("Found NaturalX");
                        }
                    }
                }
            }
        }
    }
}