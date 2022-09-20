using Discretization;

namespace Meshing
{
    public class Mesh2D : IMesh2D
    {
        public MeshSpecs2D Specs {get; }
        public Node[,] Nodes { get; internal set; }
        private MeshGenerator2D Generator;
        public Mesh2D(MeshSpecs2D specs)
        {
            this.Specs =specs;
            AssembleMesh();
        }


        private void AssembleMesh()
        {
            Generator = new MeshGenerator2D(Specs);
        }

    }
}
