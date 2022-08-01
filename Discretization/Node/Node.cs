namespace Discretization 
{
    public enum CoordinateType
    {
        NaturalX,
        NaturalY,
        ComputationalX,
        ComputationalY,
        TemplateX,
        TemplateY
    }
    public class Node : INode
    {   
        public NodeId Id {get; set;} = new NodeId();

        public Dictionary <CoordinateType, Coordinate> Coordinates {get; set;} = new Dictionary <CoordinateType, Coordinate>();

        public Dictionary<DegreeOfFreedom, double> DegreesOfFreedom {get; set;} = new Dictionary<DegreeOfFreedom, double>();
        
        public Node()
        {
            
        }
    }
}