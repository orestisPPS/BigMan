namespace prizaLinearAlgebra
{
    public interface IMatrix
    {
        Dictionary<Tuple<int, int>, double> Elements { get; }
        int Rows { get; }
        int Columns { get; }
        int NumberOfElements { get; }
        bool IsSymmetric { get; }
    }
}