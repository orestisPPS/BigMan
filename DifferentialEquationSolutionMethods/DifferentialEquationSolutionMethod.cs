using DifferentialEquations;
using MathematicalProblems;
namespace DifferentialEquationSolutionMethods
{
    public enum DifferentialEquationsSolutionMethodType
    {
        FiniteDifferences,
        FiniteElements
    }

    public interface IDifferentialEquationSolutionMethod
    {
        public DifferentialEquationsSolutionMethodType Type { get; }

        public IMathematicalProblem MathematicalProblem { get; }

        public INumericalScheme Scheme { get; }
    }
}