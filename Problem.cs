using MathematicalProblems;
using Discretization;
using Constitutive;
using DifferentialEquations;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using utility;

public class Problem
{
    public Node [,] Nodes { get; }

    public BoundaryValueProblem BoundaryValueProblem { get; }

    public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

    public DifferentialEquationSolutionMethod DifferentialEquationSolutionMethod { get; internal set; } 

    public DifferentialEquation Equation { get; }


    public Problem(Node[,] nodes, BoundaryValueProblem mathProblem, DifferentialEquationsSolutionMethodType SolutionMethod)
    {
        this.Nodes = nodes;
        this.BoundaryValueProblem = mathProblem;
        this.SolutionMethodType = SolutionMethod;
        ChooseBoundaryProblemSolutionMethod();
        AssignDegreesOfFreedomToNodes();
        AssignBoundaryValuesToBoundaryNodes();
    }

    private void ChooseBoundaryProblemSolutionMethod()
    {
        switch (SolutionMethodType)
        {
            case DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod:
                DifferentialEquationSolutionMethod = new FiniteDifferenceMethod(Nodes, BoundaryValueProblem);
                break;
            case DifferentialEquationsSolutionMethodType.FiniteElementsMethod:
                //DifferentialEquationSolutionMethod = new FiniteElementsMethod(Nodes, MathProblem);
                break;
            default:
                throw new System.NotImplementedException();
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