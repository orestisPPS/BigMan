using DifferentialEquations;
using Discretization;
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
        DifferentialEquationsSolutionMethodType Type { get; }

        IMathematicalProblem MathematicalProblem { get; }

        INumericalScheme Scheme { get; }

        List<Node> FreeDOF { get; }

        List<Node> BoundedDOF { get; }
    }
}