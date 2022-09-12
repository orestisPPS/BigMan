namespace prizaLinearAlgebra
{
    public class Matrix : IMatrix
    {
        public Dictionary<Tuple<int, int>, double> Elements { get; }
        public int Rows => Elements.Keys.Max(x => x.Item1);
        public int Columns => Elements.Keys.Max(x => x.Item2);
        public int NumberOfElements => Rows * Columns;
        public bool IsSymmetric { get; set; }

        public Matrix ()
        {
            Elements = new Dictionary<Tuple<int, int>, double>();
            IsSymmetric = IsMatrixSymmetric
        }

        public double[,] AsDoubleArray()
        {
            var array = new double[Rows, Columns];
            foreach (var (key, value) in Elements)
            {
                array[key.Item1, key.Item2] = value;
            }
            return array;
        }

        public void CopyFromDictionary(Dictionary<Tuple<int, int>, double> matrix)
        {
            foreach (var (key, value) in matrix)
            {
                Elements.Add(key, value);
            }
        }

        public void CopyFromArray(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Elements[new Tuple<int, int>(i, j)] = matrix[i, j];
                }
            }
        }


        private bool IsMatrixSymmetric ()
        {
            if (Rows != Columns)
            {
                return false;
            }
            for (int i = 1; i < Rows; i++)
            {
                for (int j = i; j < Columns; j++)
                {
                    if (Elements[new Tuple<int, int>(i, j)] != Elements[new Tuple<int, int>(j, i)])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}