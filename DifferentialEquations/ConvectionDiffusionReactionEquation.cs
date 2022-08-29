namespace DifferentialEquations
{
    public class ConvectionDiffusionReactionEquation : DifferentialEquation
    {
        public override DifferentialEquationType DifferentialEquationType => DifferentialEquationType.ConvectionDiffusionReaction;
        public override DifferentialEquationProperties Coefficients { get; }
        public override bool IsTransient => Coefficients.IsTransient();
        public ConvectionDiffusionReactionEquation(DifferentialEquationProperties coefficients)
        {
            this.Coefficients = coefficients;
        }
    }
}