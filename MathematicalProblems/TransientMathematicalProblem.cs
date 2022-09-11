using Equations;
using DifferentialEquations;
using Constitutive; 
using BoundaryConditions;
using InitialConditions;
namespace MathematicalProblems
{
    public class TransientMathematicalProblem : IMathematicalProblem
    {
        public MathematicalProblemType Type => MathematicalProblemType.BoundaryValueProblem;
        
        public DifferentialEquation Equation { get; }

        public List<Dictionary<string, BoundaryCondition>> BoundaryConditions { get; }

        public List<Dictionary<string, InitialCondition>> InitialConditions { get; }
        
        public List<DegreeOfFreedom> DegreeOfFreedom { get; }

        public bool IsTransient => true;

        public TransientMathematicalProblem(DifferentialEquation equation,
                                            List<Dictionary<string, BoundaryCondition>> boundaryConditions,
                                            List<Dictionary<string, InitialCondition>> initialConditions,
                                            List<DegreeOfFreedom> degreesOfFreedom)
        {
            this.Equation = equation;
            this.BoundaryConditions = boundaryConditions;
            this.InitialConditions = initialConditions;
            this.DegreeOfFreedom = degreesOfFreedom;
        }

        // public TransientMathematicalProblem(List<DifferentialEquation> equation,
        //                                     List<Dictionary<string, InitialCondition>> initialConditions,
        //                                     List<DegreeOfFreedom> degreesOfFreedom)
        // {
        //     this.Equation = equation;
        //     this.InitialConditions = initialConditions;
        //     this.DegreeOfFreedom = degreesOfFreedom;
        // }
    }
}