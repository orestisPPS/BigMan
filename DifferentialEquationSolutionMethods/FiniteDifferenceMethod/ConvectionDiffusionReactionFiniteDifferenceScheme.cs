using DifferentialEquations;
using Discretization;
using MathematicalProblems;
using prizaLinearAlgebra;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class ConvectionDiffusionReactionFiniteDifferenceScheme : INumericalScheme
    {
        public Node[,] Nodes { get; }

        public IMathematicalProblem Problem { get; }

        public LinearSystem LinearSystem => CreateLinearSystem();

        public ConvectionDiffusionReactionFiniteDifferenceScheme(Node[,] nodes, IMathematicalProblem problem)
        {
            this.Nodes = nodes;
            this.Problem = problem;
        }
        
        private LinearSystem CreateLinearSystem()
        {
            
            var matrix = new Matrix(Nodes.GetLength(0) * Nodes.GetLength(1));
            var vector = CreateVector();
            return new LinearSystem(matrix, vector);
        }

        private double[,] CreateMatrix()
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

        private double[] CreateVector()
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


        private double[,] CreateSteadyStateMatrix()
        {
            // TODO - Create Matrix
            return new double[1, 1];
        }

        private double[] CreateSteadyStateVector()
        {
            // TODO - Create Vector
            return new double[1];
        }

        private double[,] CreateTransientMatix()
        {
            // TODO - Create Matrix
            return new double[1, 1];        }

        private double[] CreateTransientVector()
        {
            // TODO - Create Vector
            return new double[1];
        }

 

    }

}