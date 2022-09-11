using DifferentialEquations;
using MathematicalProblems;
namespace DifferentialEquationSolutionMethods
{
    public enum DifferentialEquationsSolutionMethodType
    {
        FiniteDifferenceMethod,
        FiniteElementsMethod
    }
    // public abstract class DifferentialEquationSolutionMethod
    // {
    //     public virtual DifferentialEquationsSolutionMethodType Type { get; }

    //     public virtual MathematicalProblem MathematicalProblem { get; }
    // }
    public interface IDifferentialEquationSolutionMethod
    {
        public DifferentialEquationsSolutionMethodType Type { get; }

        public IMathematicalProblem MathematicalProblem { get; }

        public INumericalScheme Scheme { get; }
    }
}