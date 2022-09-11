using MathematicalProblems;
using Discretization;
using Constitutive;
using DifferentialEquations;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using utility;

namespace Simulations
{
    public enum SimulationType
    {
        SteadyState,
        Transient
    }
    public interface ISimulation
    {
        public SimulationType Type { get; }
        
        public Node[,] Nodes { get; }

        public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

        public IDifferentialEquationSolutionMethod SolutionMethod { get; }

        // TODO - Create Solver

    }
}