using Discretization;
using Constitutive;
namespace Mesh
{
    public class MeshGenerator
    {
        public int NumberOfNodesX {get;}
        public int NumberOfNodesY {get;}
        public double TemplateHx {get;}
        public double TemplateHy {get;}
        public double TemplateRotAngle {get;}
        public double TemplateShearX {get;}
        public double TemplateShearY {get;}
        public DensificationMethod DensificationMethod {get;}
        public MeshGenerator(int nnx, int nny,  double templateHx, double templateHy, double templateRotAngle, double templateShearX, double templateShearY, DensificationMethod densificationMethod)
        {
            this.NumberOfNodesX = nnx;
            this.NumberOfNodesY = nny;
            this.TemplateHx = templateHx;
            this.TemplateHy = templateHy;
            this.TemplateRotAngle = templateRotAngle;
            this.TemplateShearX = templateShearX;
            this.TemplateShearY = templateShearY;
            this.DensificationMethod = densificationMethod;

            var NodeFactory = new NodeFactory(numberOfNodesX : NumberOfNodesX, numberOfNodesY : NumberOfNodesY);
            var nodes = NodeFactory.Nodes;
            var computationalMesh = new ComputationalMesh(nodes : nodes);
            var TemplateMesh = new TemplateMesh(nodes : nodes, hx : TemplateHx, hy : TemplateHy, rotAngle : TemplateRotAngle, shearX : TemplateShearX, shearY : TemplateShearY);
            
        }
    }
}
