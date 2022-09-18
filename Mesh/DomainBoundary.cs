using Discretization;
namespace BoundaryConditions
{
    public class DomainBoundary
    {
        public int Id { get; }
        public List<Node> Nodes { get; set; } = new List<Node>();
        public int NumberOfNodes => Nodes.Count;
       


        /// <summary>
        /// This constructor is used when the boundary condition function is applied to all nodes of the boundary.
        /// </summary>
        /// <param name="numberOfBoundaryNodes"></param>
        /// <param name="boundaryCondition"></param>
        public DomainBoundary(int id, int numberOfBoundaryNodes, BoundaryCondition boundaryCondition)
        {
            this.Id = id;
            this.NumberOfBoundaryNodes = numberOfBoundaryNodes;
            this.BoundaryCondition = boundaryCondition;

            for (int i = 0; i < numberOfBoundaryNodes; i++)
            {
                BoundaryConditions.Add(BoundaryCondition);
            }
        }


        /// <summary>
        /// This constructor is used when the boundary condition function varies with the node.
        /// </summary>
        /// <param name="boundaryConditions"></param>
        public DomainBoundary(int id, List <BoundaryCondition> boundaryConditions)
        {
            this.Id = id;
            this.NumberOfBoundaryNodes = boundaryConditions.Count;
            this.BoundaryConditions = boundaryConditions;
        }

    }   
}