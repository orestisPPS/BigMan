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

    public SteadyStateMathematicalProblem MathProblem { get; }

    public DifferentialEquationsSolutionMethodType SolutionMethodType { get; }

    public IDifferentialEquationSolutionMethod DifferentialEquationSolutionMethod { get; internal set; } 

    public Problem(Node[,] nodes, SteadyStateMathematicalProblem mathProblem, IDifferentialEquationSolutionMethod solutionMethod)
    {
        this.Nodes = nodes;
        this.MathProblem = mathProblem;
        MathProblem.;
        this.SolutionMethodType = solutionMethod;
        ChooseBoundaryProblemSolutionMethod();
        AssignDegreesOfFreedomToNodes();
        AssignBoundaryValuesToBoundaryNodes();
    }

    // private DifferentialEquationSolutionMethod ChooseBoundaryProblemSolutionMethod()
    // {
    //     switch (SolutionMethodType)
    //     {
    //         case DifferentialEquationsSolutionMethodType.FiniteDifferenceMethod:
    //             switch (MathProblem.IsTransient)
    //             {
    //                 case true:
    //                     DifferentialEquationSolutionMethod = new FiniteDifferenceMethod(Nodes, MathProblem);
    //                     break;
    //                 case false:
    //                     DifferentialEquationSolutionMethod = new FiniteDifferenceMethod(Nodes, MathProblem);
    //                     break;
    //                 default:
    //                     throw new System.NotImplementedException();
    //             }
    //             {
    //                 case DifferentialEquationType.ConvectionDiffusionReaction:
    //                     DifferentialEquationSolutionMethod = new FiniteDifferenceMethod(Nodes, MathProblem);
    //                     break;
    //                 default:
    //                     throw new System.NotImplementedException();
    //             }
    //             return new FiniteDifferenceMethod(Nodes, BoundaryValueProblem);
    //             break;
    //         //case DifferentialEquationsSolutionMethodType.FiniteElementsMethod:
    //             //return new FiniteElementsMethod(Nodes, MathProblem);
    //             //break;
    //         default:
    //             throw new Exception("Solution method not implemented");
    //             return null;
    //     }
    // }

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