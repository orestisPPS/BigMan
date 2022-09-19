using Discretization;

namespace Mesh
{
    public interface IMesh
    {
        Node[,] Nodes { get;}

        List<Node> FreeDOF { get; }

        List<Node> BoundedDOF { get; }

        //TODO - Add Boundary class list

        int NNDirectionOne {get;}

        int NNDirectionTwo {get;}

        void AssignFreeDegreesOfFreedom();

        void AssignBoundedegreesOfFreedom();

        void AssembleMesh();


    }
}