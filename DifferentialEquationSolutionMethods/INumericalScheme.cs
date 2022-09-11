using Discretization;
using MathematicalProblems;

namespace DifferentialEquationSolutionMethods
{
    public interface INumericalScheme
    {
        public Node[,] Nodes { get; }
        public MathematicalProblem Problem { get; }
        public double[,] Matrix { get; }
        public double[] Vector { get; }
        public abstract double [,] CreateMatrix();
        public abstract double [] CreateVector();
  
    }
}