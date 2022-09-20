using MathematicalProblems;
using Discretization;
using Constitutive;
using DifferentialEquations;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using Simulations;
using utility;
using System.Diagnostics;

public class SteadyStateSimulation : ISteadyStateSimulation
{
    public int Id { get; }
    public SimulationType Type => SimulationType.SteadyState;
    
    public Node [,] Nodes { get; }

    public SteadyStateMathematicalProblem MathProblem { get; }

    public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

    public IDifferentialEquationSolutionMethod SolutionMethod { get; internal set; }

    public List<Node> FreeDegreesOfFreedom { get; }

    public SteadyStateSimulation(int id, Node[,] nodes, SteadyStateMathematicalProblem mathProblem,
                                 DifferentialEquationsSolutionMethodType solutionMethodType)
    {
        var sw = new Stopwatch();
        sw.Start();
        this.Id = id;
        this.Nodes = nodes;
        this.MathProblem = mathProblem;
        this.SolutionMethodType = solutionMethodType;
        AssignDegreesOfFreedomToNodes();
        SolutionMethod = AssignSolutionMethod();
        sw.Stop();
        Console.WriteLine($"Steady state simulation {id} executed in {sw.ElapsedMilliseconds} ms");
        //AssignBoundaryValuesToBoundaryNodes();
        
        
    }
    private void AssignDegreesOfFreedomToNodes()
    {
        throw new System.NotImplementedException();
    }
    private IDifferentialEquationSolutionMethod AssignSolutionMethod()
    {
        switch (SolutionMethodType)
        {
            case DifferentialEquationsSolutionMethodType.FiniteDifferences:
                return new FiniteDifferenceMethod(Nodes, MathProblem);
            //case DifferentialEquationsSolutionMethodType.FiniteElementsMethod:
                //return new FiniteElementsMethod(Nodes, MathProblem);
            default:
                throw new Exception("Solution method not implemented");
        }
    }

    public void InitiateAnalysis()
    {
        throw new System.NotImplementedException();
    } 
}