using DifferentialEquations;
using Mesh;
using Discretization;
using Constitutive;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using MathematicalProblems;
using utility;
internal class Program
{
    private static void Main(string[] args)
    {
        var meshPreProcessor = new MeshPreProcessor(numberOfNodesX : 5, numberOfNodesY : 5,
                                                    templateHX : 1d, templateHy : 1d,
                                                    templateRotationAngleInDegrees : 0d,
                                                    templateShearXAngleInDegrees : 0d, templateShearYAngleInDegrees : 0d);

        var equationProperties = meshPreProcessor.DomainProperties;
        var equation =   new ConvectionDiffusionReactionEquation(equationProperties);
        var domainNodes = meshPreProcessor.Nodes;                   
        var DegreesOfFreedom = new List<DegreeOfFreedom>();
        DegreesOfFreedom.Add(new X());
        DegreesOfFreedom.Add(new Y());
        var mathematicalProblem = new BoundaryValueProblem(equation, new Dictionary<string, BoundaryCondition>(), DegreesOfFreedom);

        var solutionMethod = new FiniteDifferenceMethod(equation, nodes);
        var meshGenerationProblem =  new Problem(domainNodes, mathematicalProblem,
                                                 meshBoundaries.BoundaryConditions, solutionMethod, DegreesOfFreedom);
    }
}