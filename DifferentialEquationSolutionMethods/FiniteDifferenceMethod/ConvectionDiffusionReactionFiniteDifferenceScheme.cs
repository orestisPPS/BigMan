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
        public IMathematicalProblem Problem { get; }
        public double[,] Matrix {get;   internal set;} 
        public double[] Vector {get; internal set;}

        public ConvectionDiffusionReactionFiniteDifferenceScheme(Node[,] nodes, IMathematicalProblem problem)
        {
            this.Nodes = nodes;
            this.Problem = problem;
            this.Matrix = CreateMatrix();
            this.Vector = CreateVector();
        }

        public double[,] CreateMatrix()
        {
            // TODO - Create Linear System
            switch (Problem.Equation.IsTransient)
            {
                case true:
                    return CreateTransientMatix();

                case false:
                    return CreateSteadyStateMatrix();
                
                default:
                    throw new System.NotImplementedException();
            }
        }

        public double[] CreateVector()
        {
            // TODO - Create Linear System
            switch (Problem.Equation.IsTransient)
            {
                case true:
                    return CreateTransientVector();

                case false:
                    return CreateSteadyStateVector();
                
                default:
                    throw new System.NotImplementedException();
            }
        }


        public double[,] CreateSteadyStateMatrix()
        {
            // TODO - Create Matrix
            return new double[1, 1];
        }

        public double[] CreateSteadyStateVector()
        {
            // TODO - Create Vector
            return new double[1];
        }

        public double[,] CreateTransientMatix()
        {
            // TODO - Create Matrix
            return new double[1, 1];        }

        public double[] CreateTransientVector()
        {
            // TODO - Create Vector
            return new double[1];
        }

 

    }

}