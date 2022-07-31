namespace Discretization 
{
    public class Node : INode
    {   
        public NodeId Id {get; set;}

        public Dictionary <Coordinate, double> Coordinates {get; set;} = new Dictionary <Coordinate, double>();

        public Dictionary<DegreeOfFreedom, double> DegreesOfFreedom {get; set;} = new Dictionary<DegreeOfFreedom, double>();
        
        public Node()
        {
            Id = new NodeId();
    }
}