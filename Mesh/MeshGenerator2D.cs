using Discretization;

namespace Meshing
{
    public class MeshGenerator2D
    {
        public MeshSpecs2D MeshSpecs { get; }
        public MeshGenerator2D(MeshSpecs2D specs)
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
        var mathematicalProblem = new SteadyStateMathematicalProblem(equation, new Dictionary<string, BoundaryCondition>(), DegreesOfFreedom);
        var meshGenerationProblem =  new SteadyStateProblem(domainNodes, mathematicalProblem, solutionMethod, DegreesOfFreedom);
        meshGenerationProblem.SolutionMethod.Scheme. 
        }
    }
}