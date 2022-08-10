using Discretization;
using Constitutive;
using utility;

namespace Mesh
{
    public class TemplateMesh : IMesh
        {
        
        public Node[,] Nodes { get; }

        /// <summary>
        /// The distance of the nodes in x direction
        /// </summary>
        /// <value></value>
        public double Hx {get;}

        /// <summary>
        /// The distance of the nodes in Y direction
        /// </summary>
        /// <value></value>
        public double Hy {get;}

        /// <summary>
        /// The rotation angle of the mesh
        /// </summary>
        /// <value></value>
        public double RotAngle {get;}

        /// <summary>
        /// The shear angle of the mesh with the X axis
        /// </summary>
        /// <value></value>
        public double ShearX {get;}

        /// <summary>
        /// The shear angle of the mesh with the Y axis
        /// </summary>
        /// <value></value>
        public double ShearY {get;}

        public int NumberOfNodesDirectionOne { get; set; }
        
        public int NumberOfNodesDirectionTwo { get; set; }

        public TemplateMesh(Node[,] nodes, double hx, double hy, double rotAngle, double shearX, double shearY)
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