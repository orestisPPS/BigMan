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

        public virtual DifferentialEquation Equation { get; }

        public virtual List<DegreeOfFreedom> DegreeOfFreedom { get; }

        public virtual bool IsTransient { get; }
    }

}
