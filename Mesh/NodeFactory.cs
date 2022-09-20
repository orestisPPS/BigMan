using utility;
using Discretization;
using Constitutive;
namespace Meshing
{
    public class NodeFactory
    {

        /// <summary>
        /// Input: A 2 dimensional array which maps the nodes in the computational
        /// domain, in the order they they appear in the domain (from left to right)
        /// </summary>
        /// <value></value>
        public Node[,] Nodes {get; set;}
        
        private int NumberOfNodesX {get;}

        private int NumberOfNodesY {get;}

        public Dictionary<int, Node> NodeDictionary {get; set;} = new Dictionary<int, Node>();
        
        public NodeFactory(int numberOfNodesX, int numberOfNodesY)
        {
            this.NumberOfNodesX = numberOfNodesX;
            this.NumberOfNodesY = numberOfNodesY;
            Nodes = new Node[NumberOfNodesY, NumberOfNodesX];
            CreateNodes();
            AssignGlobalIds();

            // for (int row = 0; row < NumberOfNodesY; row++)
            // {
            //     for (int column = 0; column < NumberOfNodesX; column++)
            //     {
            //         var node =  Nodes[row, column];
            //         Console.WriteLine("G. ID = " + node.Id.Global + " I. ID = " +  + node.Id.Internal + " B. ID = "  + node.Id.Boundary +
            //         " X = " + node.Coordinates[CoordinateType.NaturalX].Value + " Y = " +  + node.Coordinates[CoordinateType.NaturalY].Value);
            //     }
            // }

        }

        private void CreateNodes()
        {
            var boundaryCounter = 0;
            //Bottom Boundary
            for (int i = 0; i < NumberOfNodesX; i++)
            {
                Nodes[0, i] = InitializeBoundaryNode(positionInBoundary : i, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Right Boundary
            for (int i = 1; i < NumberOfNodesY; i++)
            {
                Nodes[i, NumberOfNodesX - 1] = InitializeBoundaryNode(positionInBoundary : i, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Top Boundary
            for (int i = 1; i < NumberOfNodesX; i++)
            {
                Nodes[NumberOfNodesY - 1, NumberOfNodesX - 1 - i] = InitializeBoundaryNode(positionInBoundary : i, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Left Boundary
            for (int i = 1; i < NumberOfNodesY - 1; i++)
            {
                Nodes[NumberOfNodesY - 1 - i, 0] = InitializeBoundaryNode(positionInBoundary : i, nodalBoundaryId: boundaryCounter);
                boundaryCounter++;
            }
            //Internal 
            var internalCounter = 0;
            for (int row = 1; row < NumberOfNodesY - 1; row++)
            {
                for (int column = 1; column < NumberOfNodesX - 1; column++)
                {
                    Nodes[row, column] = InitializeInternalNode(positionInternal : internalCounter);
                    internalCounter++;
                }
            }
        }

        private Node InitializeBoundaryNode(int positionInBoundary, int nodalBoundaryId)
        {
            var node = new Node();
            node.Id.Boundary = nodalBoundaryId;
            return node;
        }

        private Node InitializeInternalNode(int positionInternal)
        {
            var node = new Node();
            node.Id.Internal = positionInternal;
            return node;
        }

        private void  AssignGlobalIds()
        {
            var k = 0;
            for (int row = 0; row < NumberOfNodesY; row++)
            {
                for (int column = 0; column < NumberOfNodesX; column++)
                {
                    Nodes[row, column].Id.Global = k;
                    NodeDictionary.Add(k, Nodes[row, column]);
                    k++;
                }
            }
        }
    }
}