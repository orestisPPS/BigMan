using Discretization;
using BoundaryConditions;
using DifferentialEquations;
using utility;

namespace Mesh
{
    public class MeshPreProcessor
    {
        public int NNX {get;}
        
        public int NNY {get;}

        public double TemplateHX {get;}

        public double TemplateHY {get;}

        public double TemplateRotationAngleInDegrees {get;} 

        public double TemplateShearXAngleInDegrees {get;}

        public double TemplateShearYAngleInDegrees {get;}

        public int NumberOfNodes => NNX * NNY;

        public Node[,] Nodes {get; internal set;}

        public Dictionary<Node, NodeMetrics> Metrics {get; internal set;}

        public DifferentialEquationProperties DomainProperties {get; internal set;}
        private NodeFactory nodeFactory;

        public MeshPreProcessor(int numberOfNodesX, int numberOfNodesY, double templateHX, double templateHy,
                                double templateRotationAngleInDegrees, double templateShearXAngleInDegrees, double templateShearYAngleInDegrees)
        {
            this.NNX = numberOfNodesY;
            this.NNY = numberOfNodesX;
            this.TemplateHX = templateHX;
            this.TemplateHY = templateHy;
            this.TemplateRotationAngleInDegrees = templateRotationAngleInDegrees;
            this.TemplateShearYAngleInDegrees = templateShearYAngleInDegrees;
            this.TemplateShearXAngleInDegrees = templateShearXAngleInDegrees;
            this.nodeFactory = new NodeFactory(NNX, NNY);
            this.Nodes = new Node[NNX,NNY];
            this.Nodes = nodeFactory.Nodes;
            this.Metrics = new Dictionary<Node, NodeMetrics>();
            AssingCoordinatesToNodes();
            CalculateMeshMetrix();
            AssignMeshProperties();
            ClearMemory();
        }

        private void AssingCoordinatesToNodes()
        {
            for (int i = 0; i < NNX; i++)
            {
                for (int j = 0; j < NNY; j++)
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
        private void AssgignComputationalMeshCoordinatesToNodes(int i, int j)
        {
            var templateCoordinates = Transform(new double[] {i, j}); 
            Nodes[i, j].Coordinates.Add(CoordinateType.ComputationalKsi, new ComputationalKsi(templateCoordinates[0]));
            Nodes[i, j].Coordinates.Add(CoordinateType.ComputationalIta, new ComputationalIta(templateCoordinates[1]));
        }

        private void AssignTemplateMeshCoordinatesToNodes(int i, int j)
        {
            Nodes[i, j].Coordinates.Add(CoordinateType.TemplateX, new TemplateX(i));
            Nodes[i, j].Coordinates.Add(CoordinateType.TemplateY, new TemplateY(j));
        }

        private double[] Transform(double[] initialCoord)
        {
            var transformedCoord = TransformationTensors.Rotate (initialCoord, TemplateRotationAngleInDegrees);
            transformedCoord = TransformationTensors.Shear(transformedCoord, TemplateShearXAngleInDegrees, TemplateShearYAngleInDegrees);
            transformedCoord = TransformationTensors.Scale(transformedCoord, TemplateHX, TemplateHY);
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
