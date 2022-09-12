namespace prizaLinearAlgebra
{
    public interface ILinearSystem
    {
        public double[,] Matrix { get; }
        public double[] Vector { get; }
        public double[] Solution { get; }
        public bool IsSymmetric { get; } 
    }
}