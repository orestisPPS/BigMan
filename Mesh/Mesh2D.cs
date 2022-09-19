using Discretization;

namespace Mesh
{
    public abstract class Mesh2D : IMesh2D
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
            var meshPreProcessor = new MeshPreProcessor(Specs);
            Nodes = meshPreProcessor.Nodes;
            Generator = new MeshGenerator2D(Specs, Nodes);
            Generator.GenerateMesh();
        }

        private void AssignAdditional

    }
}
