namespace Constitutive
{
    public enum DegreeOfFreedomType
    {
        X,
        Y,
        Z
    }
    public class DegreeOfFreedom : IDegreeOfFreedom
    {
        public double Value {get; set;}
        public string Type {get;}
    }
}