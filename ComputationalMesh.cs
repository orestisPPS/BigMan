using Discretization;
using Constitutive;

namespace Mesh
{
    public class ComputationalMesh : IMesh
    {
        public Node[,] Nodes { get; }
        public int NumberOfNodesDirectionOne { get; internal set; }
        public int NumberOfNodesDirectionTwo { get; internal set; }
        public ComputationalMesh(Node[,] nodes)
        {
            this.Nodes = nodes;
            this.NumberOfNodesDirectionOne = nodes.GetLength(1);
            this.NumberOfNodesDirectionTwo = nodes.GetLength(0);
        }

        private void CreateMesh()
        {
            for (int row = 0; row < NumberOfNodesDirectionTwo; row++)
            {
                for (int column = 0; column < NumberOfNodesDirectionOne; column++)
                {
                    var node = Nodes[row, column];
                    node.Coordinates.Add(CoordinateType.ComputationalKsi, new ComputationalKsi(row, column));
                    node.Coordinates.Add(CoordinateType.ComputationalIta, new ComputationalIta(row, column));
                }
            }
        }
    }
}