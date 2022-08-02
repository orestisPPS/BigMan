using Constitutive;
namespace Discretization 
{
    public class Node : INode
    {   
        public NodeId Id {get; set;} = new NodeId();

        public Dictionary <CoordinateType, Coordinate> Coordinates {get; set;} = new Dictionary <CoordinateType, Coordinate>();

        public Dictionary<DegreeOfFreedomType, DegreeOfFreedom> DegreesOfFreedom {get; set;} = new Dictionary<DegreeOfFreedomType, DegreeOfFreedom>();
        
        public Node()
        {
        }
    }
}