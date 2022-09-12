using MathematicalProblems;
using Discretization;
using Constitutive;
using DifferentialEquations;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using Simulations;
using utility;

public class SteadyStateSimulation : ISteadyStateSimulation
{
    public SimulationType Type => SimulationType.SteadyState;
    
    public Node [,] Nodes { get; }

    public SteadyStateMathematicalProblem MathProblem { get; }

    public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

    public IDifferentialEquationSolutionMethod SolutionMethod { get; internal set; }

    public SteadyStateSimulation(Node[,] nodes, SteadyStateMathematicalProblem mathProblem, DifferentialEquationsSolutionMethodType solutionMethodType)
    {
        this.Nodes = nodes;
        this.MathProblem = mathProblem;
        this.SolutionMethodType = solutionMethodType;
        AssignDegreesOfFreedomToNodes();
        this.SolutionMethod = AssignSolutionMethod();
        var linearSystem = SolutionMethod.Scheme.LinearSystem;
        var matrix = linearSystem.Matrix;
        //AssignBoundaryValuesToBoundaryNodes();
        
        
    }
    private void AssignDegreesOfFreedomToNodes()
    {
        foreach (var node in Nodes)
        {
            foreach (var degreeOfFreedom in SolutionMethod.MathematicalProblem.DegreeOfFreedom)
            {
                node.DegreesOfFreedom.Add(degreeOfFreedom.Type, degreeOfFreedom);
            }
        }
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

    } 
}