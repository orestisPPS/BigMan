namespace prizaLinearAlgebra
{
    public class LinearSystem : ILinearSystem
    {
        public double[,] Matrix { get; }
        
        public double[] Vector { get; }
        public double[] Solution { get; }
        public bool isSymmetric { get; } 

        public LinearSystem(double[,] matrix, double[] vector, bool isSymmetric)
        {
            Matrix = matrix;
            Vector = vector;
            Solution = new double[vector.Length];
            this.isSymmetric = isSymmetric;
        }
    }

}