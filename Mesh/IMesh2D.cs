using Discretization;

namespace Meshing
{
    public interface IMesh2D
    {
        MeshSpecs2D Specs { get; }

        Node[,] Nodes { get;}

        //TODO - Add Boundary class list


        void AssembleMesh();


    }
}