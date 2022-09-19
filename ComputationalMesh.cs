using Discretization;
using Constitutive;

namespace Mesh
{
    public class ComputationalMesh : IMesh2D
    {
        public Node[,] Nodes { get; }
        public int NumberOfNodesDirectionOne { get; set; }
        public int NumberOfNodesDirectionTwo { get; set; }
        public ComputationalMesh(Node[,] nodes)
        {
            this.Nodes = nodes;
            this.NumberOfNodesDirectionOne = nodes.GetLength(1);
            this.NumberOfNodesDirectionTwo = nodes.GetLength(0);
            CreateMesh();
        }

        private void CreateMesh()
        {
            for (int row = 0; row < NumberOfNodesDirectionTwo; row++)
            {
                for (int column = 0; column < NumberOfNodesDirectionOne; column++)
                {
                    var node = Nodes[row, column];
                    node.Coordinates.Add(CoordinateType.ComputationalKsi, new ComputationalKsi(column));
                    node.Coordinates.Add(CoordinateType.ComputationalIta, new ComputationalIta(row));
                }
            }
        }
    }
}