using DifferentialEquations;
using Discretization;
using System.Threading;
using System.Threading.Tasks;

namespace DifferentialEquationSolutionMethods
{
    public class ConvectionDiffusionReactionFiniteDifferenceScheme : FiniteDifferenceScheme
    {
        public override DifferentialEquation Equation { get; }
        public override Node[,] Nodes { get; }
        public override double[,] Matrix { get; internal set; }
        public override double[] Vector { get; internal set; }

        public ConvectionDiffusionReactionFiniteDifferenceScheme(DifferentialEquation equation, Node[,] nodes )
        {
            Equation = equation;
            Nodes = nodes;
        }

        public override void CreateMatrix()
        {
            throw new System.NotImplementedException();
        }
        public override void CreateVector()
        {
            throw new System.NotImplementedException();
        }
    }
}