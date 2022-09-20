using Equations;
using DifferentialEquations;
using Constitutive; 
using BoundaryConditions;
namespace MathematicalProblems
{
    public class SteadyStateMathematicalProblem : IMathematicalProblem
    {
        public MathematicalProblemType Type => MathematicalProblemType.BoundaryValueProblem;
        
        public DifferentialEquation Equation { get; }

        public Dictionary<DomainBoundary, IBoundaryCondition> BoundaryConditions { get; }

        public List<DegreeOfFreedom> DegreeOfFreedom { get; }
        
        public bool IsTransient => false;

        public SteadyStateMathematicalProblem(DifferentialEquation equation,
                                              Dictionary<DomainBoundary, IBoundaryCondition> boundaryConditions,
                                              List<DegreeOfFreedom> degreesOfFreedom)
        {
            this.Equation = equation;
            this.BoundaryConditions = boundaryConditions;
            this.DegreeOfFreedom = degreesOfFreedom;
        }
    }
}