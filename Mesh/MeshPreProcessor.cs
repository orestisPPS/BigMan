using Discretization;
using BoundaryConditions;
using DifferentialEquations;
using utility;

namespace Mesh
{
    public class MeshPreProcessor
    {
        public MeshSpecs2D Specs { get; }

        public Node[,] Nodes {get; internal set;}

        public Dictionary<Node, NodeMetrics> Metrics {get; internal set;}

        public DifferentialEquationProperties DomainProperties {get; internal set;}
        private NodeFactory nodeFactory;

        public MeshPreProcessor(MeshSpecs2D specs)
        {
            this.Specs = specs;
            nodeFactory = new NodeFactory(numberOfNodesX : Specs.NNDirectionOne, numberOfNodesY : Specs.NNDirectionTwo);
            Nodes = nodeFactory.Nodes;
            Metrics = new Dictionary<Node, NodeMetrics>();
            AssingCoordinatesToNodes();
            CalculateMeshMetrix();
            AssignMeshProperties();
            ClearMemory();
        }


        private void AssingCoordinatesToNodes()
        {
            for (int i = 0; i < Specs.NNDirectionOne; i++)
            {
                for (int j = 0; j < Specs.NNDirectionTwo; j++)
                {
                    AssignNaturalMeshCoordinatesToNodes(i, j);
                    AssgignComputationalMeshCoordinatesToNodes(i, j);
                    AssignTemplateMeshCoordinatesToNodes(i, j);
                }
            }
        }
        private void AssignNaturalMeshCoordinatesToNodes(int i, int j)
        {
            Nodes[i, j].Coordinates.Add(CoordinateType.NaturalX, new NaturalX());
            Nodes[i, j].Coordinates.Add(CoordinateType.NaturalY, new NaturalY());
        }
        private void   AssgignComputationalMeshCoordinatesToNodes(int i, int j)
        {

            Nodes[i, j].Coordinates.Add(CoordinateType.ComputationalKsi, new ComputationalKsi(i));
            Nodes[i, j].Coordinates.Add(CoordinateType.ComputationalIta, new ComputationalIta(j));
        }

        private void AssignTemplateMeshCoordinatesToNodes(int i, int j)
        {
            var templateCoordinates = Transform(new double[] {i, j}); 
            Nodes[i, j].Coordinates.Add(CoordinateType.TemplateX, new TemplateX(templateCoordinates[0]));
            Nodes[i, j].Coordinates.Add(CoordinateType.TemplateY, new TemplateY(templateCoordinates[1]));
        }

        private double[] Transform(double[] initialCoord)
        {
            var transformedCoord = TransformationTensors.Rotate (initialCoord, Specs.TemplateRotAngle);
            transformedCoord = TransformationTensors.Shear(transformedCoord, Specs.TemplateShearX, Specs.TemplateShearY);
            transformedCoord = TransformationTensors.Scale(transformedCoord, Specs.TemplateHx, Specs.TemplateHy);
            return transformedCoord;    
        }

        private void CalculateMeshMetrix()
        {
            var MetricsCalculator = new MetricsCalculator(Nodes);
        }

        private void ClearMemory()
        {
            foreach (var node in Nodes)
            {
                node.Coordinates.Remove(CoordinateType.ComputationalKsi);
                node.Coordinates.Remove(CoordinateType.ComputationalIta);
                node.Coordinates.Remove(CoordinateType.TemplateX);
                node.Coordinates.Remove(CoordinateType.TemplateY);
            }
        }
        
        private void AssignMeshProperties()
        {
            var diffusionCoefficients = new Dictionary<Node, double[,]>();
            var convectionCoefficients = new Dictionary<Node, double[]>();
            var dependentReactionCoefficients = new Dictionary<Node, double[]>();
            var independentReactionCoefficients = new Dictionary<Node, double[]>();
            foreach (var node in Nodes)
            {
                diffusionCoefficients.Add(node, Metrics[node].contravariantTensor);
                convectionCoefficients.Add(node, new double[] {0, 0});
                dependentReactionCoefficients.Add(node, new double[] {0d, 0d} );
                independentReactionCoefficients.Add(node, new double[] {0d, 0d} );
            }
            DomainProperties = new LocallyAnisotropicConvectionDiffusionReactionEquationProperties(diffusionCoefficients, convectionCoefficients,
                                                                                  dependentReactionCoefficients, independentReactionCoefficients);
        }
    }
}
