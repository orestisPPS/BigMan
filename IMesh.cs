using Discretization;

namespace Mesh
{
    public interface IMesh
    {
        public Node[,] Nodes { get;}
        public int NumberOfNodesDirectionOne {get; internal set;}
        public int NumberOfNodesDirectionTwo {get; internal set;}
        private void CreateMesh()
        {
            
        }
    }
}