using Discretization;
using DifferentialEquations;
using DifferentialEquationSolutionMethods;
using Constitutive;
using MathematicalProblems;
using BoundaryConditions;
using Simulations;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Meshing
{
    public class MeshGenerator2D
    {
        public MeshSpecs2D MeshSpecs { get; }
        private MeshPreProcessor PreProcessor;
        private SteadyStateMathematicalProblem MathematicalProblemForX;
        private SteadyStateMathematicalProblem MathematicalProblemForY;
        private SteadyStateSimulation SimulationForX;
        private SteadyStateSimulation SimulationForY;
    
        public MeshGenerator2D(MeshSpecs2D specs)
        {
            this.MeshSpecs = specs;
            PreProcessor = new MeshPreProcessor(specs);
            MathematicalProblemForX = CreateMathematicalProblemForX();
            MathematicalProblemForY = CreateMathematicalProblemForY();
            ParallelSolution();

        }

        private SteadyStateMathematicalProblem CreateMathematicalProblemForX()
        {
            Console.WriteLine("Initiating mathematical problems ...");
            var equationProperties = PreProcessor.DomainProperties;
            var equationForX =   new ConvectionDiffusionReactionEquation(equationProperties);
            var xDOF = new X();
            return new SteadyStateMathematicalProblem(equationForX, new Dictionary<int, IBoundaryCondition>(), xDOF);
        }

        private SteadyStateMathematicalProblem CreateMathematicalProblemForY()
        {
            var equationProperties = PreProcessor.DomainProperties;
            var equationForY =   new ConvectionDiffusionReactionEquation(equationProperties);
            var yDOF = new Y();
            return new SteadyStateMathematicalProblem(equationForY, new Dictionary<int, IBoundaryCondition>(), yDOF);
        }

        private SteadyStateSimulation CreateSimulationForX()
        {
            var nodes = PreProcessor.Nodes;
            var solutionMethodType = DifferentialEquationsSolutionMethodType.FiniteDifferences;
            SimulationForX = new SteadyStateSimulation(0, nodes, MathematicalProblemForX, solutionMethodType);
            return SimulationForX;
        }

        private SteadyStateSimulation CreateSimulationForY()
        {
            var nodes = PreProcessor.Nodes;
            var solutionMethodType = DifferentialEquationsSolutionMethodType.FiniteDifferences;
            SimulationForY = new SteadyStateSimulation(1, nodes, MathematicalProblemForY, solutionMethodType);
            return SimulationForY;
        }

        private void ParallelSolution()
        {
            Console.WriteLine("Initiating parallel solution ...");
            Parallel.Invoke(
                () => SimulationForX = CreateSimulationForX(),
                () => SimulationForY = CreateSimulationForY()
            );
        }

    }
}