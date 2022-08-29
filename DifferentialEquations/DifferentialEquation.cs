using Equations;
namespace DifferentialEquations
{
    public enum DifferentialEquationType
    {
        ConvectionDiffusionReaction
    }
    public abstract class DifferentialEquation : Equation
    {
        public override EquationType Type => EquationType.DifferentialEquation;
        public virtual DifferentialEquationType DifferentialEquationType { get; }
        public virtual bool IsTransient { get; }
        public virtual DifferentialEquationProperties Coefficients { get; }
    }
}