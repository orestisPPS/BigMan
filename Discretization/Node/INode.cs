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

        /// <summary>
        /// An object containing a dictionary with all the coordinates of the node in all systems examined
        /// </summary>
        /// <value></value>
        public Dictionary<CoordinateType, double> Coordinates {get; set;}

        /// <summary>
        /// A dictionary containing a DOF type object as a key (temperature, displacement) 
        /// </summary>
        /// <value></value>
        public Dictionary<DegreeOfFreedomType, double> DegreesOfFreedom {get; set;}

    }
}