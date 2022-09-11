using DifferentialEquations;
using MathematicalProblems;
using Discretization;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class FiniteDifferenceMethod : DifferentialEquationSolutionMethod
    {
        public Node[,] Nodes { get; }

        //public override MathematicalProblem MathematicalProblem { get; }
        public MathematicalProblem MathematicalProblem { get; }
        
        //public override DifferentialEquationsSolutionMethodType Type => DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod;
        public DifferentialEquationsSolutionMethodType Type => DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod;

                        
        private FiniteDifferenceScheme Scheme;

        public FiniteDifferenceMethod(Node[,] domainNodes,  MathematicalProblem mathematicalProblem)
        {
            this.Nodes = domainNodes;
            this.MathematicalProblem = mathematicalProblem;
            this.Scheme = new FiniteDifferenceScheme(domainNodes, mathematicalProblem);
            SchemeSelector();

        }


        public void SchemeSelector()
        {
            switch (MathematicalProblem.Equation.)
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