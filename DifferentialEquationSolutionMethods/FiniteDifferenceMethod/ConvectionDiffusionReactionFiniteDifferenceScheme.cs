using DifferentialEquations;
using Discretization;
using MathematicalProblems;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class ConvectionDiffusionReactionFiniteDifferenceScheme : INumericalScheme
    {
        public Node[,] Nodes { get; }
        public MathematicalProblem Problem { get; }
        public double[,] Matrix => CreateMatrix(); 
        public double[] Vector => CreateVector();

        public ConvectionDiffusionReactionFiniteDifferenceScheme(Node[,] nodes, MathematicalProblem problem)
        {
            this.Nodes = nodes;
            this.Problem = problem;
        }
        
        public double[,] CreateMatrix()
        {
            throw new System.NotImplementedException();
        }

        public double[] CreateVector()
        {
            throw new System.NotImplementedException();
        }

    }

}