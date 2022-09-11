using DifferentialEquations;
using MathematicalProblems;
using Discretization;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class FiniteDifferenceMethod : IDifferentialEquationSolutionMethod
    {
        public Node[,] Nodes { get; }

        //public override MathematicalProblem MathematicalProblem { get; }
        public MathematicalProblem MathematicalProblem { get; }
        
        public DifferentialEquationsSolutionMethodType Type => DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod;
 
        private INumericalScheme Scheme => SchemeSelector();

        public FiniteDifferenceMethod(Node[,] domainNodes,  MathematicalProblem mathematicalProblem)
        {
            this.Nodes = domainNodes;
            this.MathematicalProblem = mathematicalProblem;
        }

        public INumericalScheme SchemeSelector()
        {
            switch (MathematicalProblem.Equation.DifferentialEquationType)
            {
                case DifferentialEquationType.ConvectionDiffusionReaction:
                    return new ConvectionDiffusionReactionFiniteDifferenceScheme(Nodes, MathematicalProblem);
                default:
                    throw new System.NotImplementedException();
            }
        }

    }


}