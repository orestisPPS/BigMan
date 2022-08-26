namespace Constitutive
{
    public enum DegreeOfFreedomType
    {
        X,
        Y,
        Z
    }
    public abstract class DegreeOfFreedom : IDegreeOfFreedom
    {
        public virtual double Value {get; set;}
        public virtual DegreeOfFreedomType Type {get;}
    }
}