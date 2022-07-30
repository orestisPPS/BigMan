using Mesh;
using Discretization;
internal class Program
{
    private static void Main(string[] args)
    {
        var square = BoundaryCreator.ParalleloGram(4, 4, 1, 1, 0, 0, 0);
        var nodeFactory = new NodeFactory(square);
    }
}