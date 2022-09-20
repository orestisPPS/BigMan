using Discretization;
using BoundaryConditions;
using DifferentialEquations;
using utility;

namespace Meshing
{
    public class MeshPreProcessor
    {
        public MeshSpecs2D Specs { get; }

        public Node[,] Nodes {get; set;}

        public Dictionary<Node, NodeMetrics> Metrics {get; internal set;} = new Dictionary<Node, NodeMetrics>();

        public DifferentialEquationProperties DomainProperties {get; internal set;}
        
        private NodeFactory nodeFactory;

        public MeshPreProcessor(MeshSpecs2D specs)
        {
            this.Specs = specs;
            Nodes = InitiateNodes();
            AssingCoordinatesToNodes();
            CalculateMeshMetrix();
            AssignMeshProperties();
            ClearMemory();
        }

        private Node[,] InitiateNodes()
        {
            Console.WriteLine("Initiating nodes...");
            nodeFactory = new NodeFactory(numberOfNodesX : Specs.NNDirectionOne, numberOfNodesY : Specs.NNDirectionTwo);
            return nodeFactory.Nodes;
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
        {   Console.WriteLine("Calculating mesh metrics...");
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
        
        private LocallyAnisotropicConvectionDiffusionReactionEquationProperties AssignMeshProperties()
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
            return new LocallyAnisotropicConvectionDiffusionReactionEquationProperties(diffusionCoefficients, convectionCoefficients,
                                                                                  dependentReactionCoefficients, independentReactionCoefficients);
        }
    }
}
