namespace Discretization
{
    public class DegreeOfFreedom : IDegreeOfFreedom
    {
        public double Value {get; set;}
        public string Type {get; set;}

        public DegreeOfFreedom()
        {
        }

        public DegreeOfFreedom( string type )
        {
            this.Type = type;
        }
    }
}