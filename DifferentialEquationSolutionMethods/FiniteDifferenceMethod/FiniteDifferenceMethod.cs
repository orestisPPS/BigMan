using DifferentialEquations;
using MathematicalProblems;
using Discretization;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class FiniteDifferenceMethod : DifferentialEquationSolutionMethod
    {
        public override DifferentialEquationsSolutionMethodType Type => DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod;
        
        public Node[,] Nodes { get; }
        
        public override BoundaryValueProblem MathematicalProblem { get; }
        
        public FiniteDifferenceScheme Scheme { get;  internal set; }

        public FiniteDifferenceMethod(Node[,] domainNodes, BoundaryValueProblem mathematicalProblem)
        {
            this.Nodes = domainNodes;
            this.MathematicalProblem = mathematicalProblem;
            SchemeSelector();
        }


        private void SchemeSelector()
        {
            switch (MathematicalProblem.Equation.DifferentialEquationType)
            {
                case DifferentialEquationType.ConvectionDiffusionReaction:
                    Scheme = new ConvectionDiffusionReactionFiniteDifferenceScheme(MathematicalProblem.Equation, Nodes);
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

    }


}