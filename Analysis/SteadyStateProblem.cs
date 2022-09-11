using MathematicalProblems;
using Discretization;
using Constitutive;
using DifferentialEquations;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using utility;

public class SteadyStateProblem
{
    public Node [,] Nodes { get; }

    public SteadyStateMathematicalProblem MathProblem { get; }

    public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

    public IDifferentialEquationSolutionMethod SolutionMethod => AssignSolutionMethod();

    public SteadyStateProblem(Node[,] nodes, SteadyStateMathematicalProblem mathProblem, DifferentialEquationsSolutionMethodType solutionMethod, Solver solver)
    {
        this.Nodes = nodes;
        this.MathProblem = mathProblem;
        this.SolutionMethodType = solutionMethod;
        AssignDegreesOfFreedomToNodes();
        AssignBoundaryValuesToBoundaryNodes();
        
    }

    private IDifferentialEquationSolutionMethod AssignSolutionMethod()
    {
        switch (SolutionMethodType)
        {
            case DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod:
                return new FiniteDifferenceMethod(Nodes, MathProblem);
            //case DifferentialEquationsSolutionMethodType.FiniteElementsMethod:
                //return new FiniteElementsMethod(Nodes, MathProblem);
            default:
                throw new Exception("Solution method not implemented");
        }
    }

    public void AssignDegreesOfFreedomToNodes()
    {
        foreach (var node in Nodes)
        {
            foreach (var degreeOfFreedom in DegreesOfFreedom)
            {
                node.DegreesOfFreedom.Add(degreeOfFreedom.Type, degreeOfFreedom);
            }
        }
    }
    //TODO - implement this method
    public void AssignBoundaryValuesToBoundaryNodes()
    {
        foreach (var boundaryCondition in BoundaryConditions)
        {
            foreach (var node in boundaryCondition.Value.Nodes)
            {
                node.BoundaryCondition = boundaryCondition.Value;
            }
        }
    }

    public void Solve()
    {

    } 
}