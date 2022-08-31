using Equations;
using DifferentialEquations;
using Constitutive; 
using BoundaryConditions;
namespace MathematicalProblems
{
    public class SteadyStateMathematicalProblem : MathematicalProblem
    {
        public override MathematicalProblemType Type => MathematicalProblemType.BoundaryValueProblem;
        
        public override List<DifferentialEquation> Equation { get; }

        public override List<Dictionary<string, BoundaryCondition>> BoundaryConditions { get; }

        public override List<DegreeOfFreedom> DegreeOfFreedom { get; }

        public SteadyStateMathematicalProblem(List<DifferentialEquation> equation,
                                              List<Dictionary<string, BoundaryCondition>> boundaryConditions,
                                              List<DegreeOfFreedom> degreesOfFreedom)
        {
            this.Equation = equation;
            this.BoundaryConditions = boundaryConditions;
            this.DegreeOfFreedom = degreesOfFreedom;
        }
    }
}