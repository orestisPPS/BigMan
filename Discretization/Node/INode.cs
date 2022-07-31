namespace Discretization
{
    public interface INode  
    {
        /// <summary>
        /// A class containg the global, internal and boundary Ids of the node
        /// If a node is internal BoundaryId = -1, or boundary InternalId = -1 
        /// </summary>
        /// <value></value>
        public NodeId Id {get; set;}
        public Dictionary<Coordinate, double> Coordinates {get; set;}
        public CoordinateOne CoordinateOne {get; set;}
        public CoordinateTwo CoordinateTwo {get; set;}

        /// <summary>
        /// A dictionary containing a DOF type object as a key (temperature, displacement) 
        /// </summary>
        /// <value></value>
        public Dictionary<string, double> DegreesOfFreedom {get; set;}

    }
}