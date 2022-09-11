using Discretization;
using DifferentialEquationSolutionMethods;

namespace Simulations
{
    public abstract class Simulation : ISimulation
    {
        public virtual SimulationType Type { get; }
        public virtual Node[,] Nodes { get; }
        public virtual DifferentialEquationsSolutionMethodType SolutionMethodType { get; }
        public virtual IDifferentialEquationSolutionMethod SolutionMethod { get; }

        internal void AssignDegreesOfFreedomToNodes()
        {
            foreach (var node in Nodes)
            {
                foreach (var degreeOfFreedom in SolutionMethod.MathematicalProblem.DegreeOfFreedom)
                {
                    node.DegreesOfFreedom.Add(degreeOfFreedom.Type, degreeOfFreedom);
                }
            }
        }

    }

}