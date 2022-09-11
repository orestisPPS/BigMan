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
        public IMathematicalProblem MathematicalProblem { get; }
        
        public DifferentialEquationsSolutionMethodType Type => DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod;
 
        public INumericalScheme Scheme { get; }

        
        public FiniteDifferenceMethod(Node[,] domainNodes,  IMathematicalProblem mathematicalProblem)
        {
            this.Nodes = domainNodes;
            this.MathematicalProblem = mathematicalProblem;
            this.Scheme = SchemeSelector();
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