using Discretization;

namespace Mesh
{
    public interface IMesh
    {
        public Node[,] Nodes { get;}
        public int NumberOfNodesDirectionOne {get; set;}
        public int NumberOfNodesDirectionTwo {get; set;}
        private void CreateMesh()
        {
            
        }
    }
}