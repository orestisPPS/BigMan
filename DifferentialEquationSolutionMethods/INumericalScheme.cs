using Discretization;
using MathematicalProblems;

namespace DifferentialEquationSolutionMethods
{
    public interface INumericalScheme
    {
        public Node[,] Nodes { get; }
        public IMathematicalProblem Problem { get; }
        public double[,] Matrix { get; }
        public double[] Vector  { get; }
        public virtual void CreateLinearSystem() {}
    }
}