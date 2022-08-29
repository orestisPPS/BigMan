using Equations;
using DifferentialEquations;
using BoundaryConditions;
using Discretization;
using Constitutive;
namespace MathematicalProblems
{
    public enum MathematicalProblemType
    {
        BoundaryValueProblem,
        InitialValueProblem,
        BoundaryInitialValueProblem,
    }
    public abstract class MathematicalProblem
    {
        public virtual MathematicalProblemType Type { get; }

        public virtual List<DifferentialEquation> Equation { get; }

        public virtual List<Dictionary<string, BoundaryCondition>> BoundaryConditions { get; }

        //public virtual Dictionary<string, InitialCondition> InitialConditions { get; }

        public virtual List<DegreeOfFreedom> DegreeOfFreedom { get; }


    }

}
