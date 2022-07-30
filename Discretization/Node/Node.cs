namespace Discretization 
{
    public class Node : INode
    {   
        public NodeId Id {get; set;}

        public Dictionary<CoordinateType, double> Coordinates {get; set;}

        public Dictionary<DegreeOfFreedomType, double> DegreesOfFreedom {get; set;}
        
        public Node()
        {
            Id = new NodeId();
            Coordinates = new Dictionary<CoordinateType, double>();
            DegreesOfFreedom = new Dictionary<DegreeOfFreedomType, double>();
        }
    }
}