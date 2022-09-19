using Discretization;
using Constitutive;
using utility;

namespace Mesh
{
    public class TemplateMesh
        {
        
        public TemplateSpecs Specs { get; }

        public TemplateMesh(MeshSpecs2D templateSpecs)
        {
            this.Nodes = nodes;
            this.Hx = hx;
            this.Hy = hy;
            this.RotAngle = rotAngle;
            this.ShearX = shearX;
            this.ShearY = shearY;
            this.NumberOfNodesDirectionOne = nodes.GetLength(1);
            this.NumberOfNodesDirectionTwo = nodes.GetLength(0);
            CreateMesh();
        }
        private void CreateMesh()
        {
            for (int row = 0; row < NumberOfNodesDirectionTwo; row++)
            {
                for (int column = 0; column < NumberOfNodesDirectionOne; column++)
                {
                    var coord = Transform(new double[] {column, row});

                    var node = Nodes[row, column];
                    node.Coordinates.Add(CoordinateType.TemplateX, new TemplateX(coord[0]));
                    node.Coordinates.Add(CoordinateType.TemplateY, new TemplateY(coord[1]));
                    
                }
            }
        }

        double[] Transform(double[] initialCoord)
        {
            var transformedCoord = TransformationTensors.Rotate (initialCoord, RotAngle);
            transformedCoord = TransformationTensors.Shear(transformedCoord, ShearX, ShearY);
            transformedCoord = TransformationTensors.Scale(transformedCoord, Hx, Hy);
            return transformedCoord;    
        } 
    }
}