using utility;
namespace prizaLinearAlgebra
{
    public class LinearSystem : ILinearSystem
    {
        public double[,] Matrix { get; }
        
        public double[] Vector { get; }
        public double[] Solution { get; }
        public bool IsSymmetric { get; } 

        public LinearSystem(double[,] matrix, double[] vector, bool isSymmetric)
        {
            this.Matrix = matrix;
            this.Vector = vector;
            this.Solution = new double[vector.Length];
            this.IsSymmetric = isSymmetric;
        }

        public LinearSystem(double[,] matrix, double[] vector)
        {
            Matrix = matrix;
            Vector = vector;
            Solution = new double[vector.Length];
            this.IsSymmetric = Calculators.IsMatrixSymmetric(matrix);
            Matrix matrix1 = 
        }

    }

}