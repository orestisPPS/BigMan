using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace utility
{
    
public static class utilitiez
{
    static utilitiez() { }

    public static void vectorPrinter(double[] y)
    {
        {
            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(y[i].ToString("F5"));
            }
            //Console.WriteLine(" ");
        }
    }
    public static void vectorPrinter2(double[] x1, double[] x2)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; }
        matrixPrinter(A);
    }
    public static void vectorPrinter3(double[] x1, double[] x2, double[] x3)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; }
        matrixPrinter(A);
    }
    public static void vectorPrinter4(double[] x1, double[] x2, double[] x3, double[] x4)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; A[i, 3] = x4[i]; }
        matrixPrinter(A);
    }
    public static void vectorPrinter5(double[] x1, double[] x2, double[] x3, double[] x4, double[]x5)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; A[i, 3] = x4[i]; A[i, 4] = x5[i]; }
        matrixPrinter(A);
    }

    public static void vectorScientificPrinter(double[] y)
    {
        {
            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(y[i].ToString("E10"));
            }
            //Console.WriteLine(" ");
        }
    }
    public static void vectorScientificPrinter2(double[] x1, double[] x2)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; }
        matrixScientificPrinter(A);
    }
    public static void vectorScientificPrinter3(double[] x1, double[] x2, double[] x3)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; }
        matrixScientificPrinter(A);
    }
    public static void vectorScientificPrinter4(double[] x1, double[] x2, double[] x3, double[] x4)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; A[i, 3] = x4[i]; }
        matrixScientificPrinter(A);
    }
    public static void vectorScientificPrinter5(double[] x1, double[] x2, double[] x3, double[] x4, double[] x5)
    {
        var n = x1.Length;
        double[,] A = new double[n, 4];
        for (int i = 0; i < n; i++) { A[i, 0] = x1[i]; A[i, 1] = x2[i]; A[i, 2] = x3[i]; A[i, 3] = x4[i]; A[i, 4] = x5[i]; }
        matrixScientificPrinter(A);
    }

    public static void matrixPrinter(double[,] A)
    {
        // setw is for displaying nicely
        Console.WriteLine(setw(2));

        // Displaying the result :
        for (int i = 0; i < A.GetLength(0); i++)
        {
            // Lower
            for (int j = 0; j < A.GetLength(1); j++)
                Console.Write(setw(2) + A[i, j].ToString("F7") + "\t");
            Console.WriteLine("\t");
        }

        static String setw(int noOfSpace)
        {
            var s = "";
            for (int i = 0; i < noOfSpace; i++)
                s += " ";
            return s;
        }
    }
    public static void matrixScientificPrinter(double[,] A)
    {
        // setw is for displaying nicely
        Console.WriteLine(setw(2));

        // Displaying the result :
        for (int i = 0; i < A.GetLength(0); i++)
        {
            // Lower
            for (int j = 0; j < A.GetLength(1); j++)
                Console.Write(setw(2) + A[i, j].ToString("E6") + "\t");
                Console.WriteLine("\t");
        }

        static String setw(int noOfSpace)
        {
            var s = "";
            for (int i = 0; i < noOfSpace; i++)
                s += " ";
            return s;
        }
    }

    public static void IterativeMethodPrinter(double[,] A, double[] b, double[] x, int iterations, double[] residual)
    {
        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Matrix A");
        Line();
        matrixScientificPrinter(A);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("vector b");
        Line();
        vectorPrinter(b);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("x");
        Line();
        vectorPrinter(x);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Iterations ");
        Line();
        Console.WriteLine(iterations);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Residual Ax-b");
        Line();
        vectorScientificPrinter(residual);

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    public static void CompressedIterativeMethodPrinter(double[] b, double[] x, int iterations, double[] residual)
    {
        Line();
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("vector b");
        Line();
        vectorPrinter(b);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("x");
        Line();
        vectorScientificPrinter(x);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Iterations ");
        Line();
        Console.WriteLine(iterations);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Residual Ax-b");
        Line();
        vectorScientificPrinter(residual);

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    public static void CSRPrinter(double[,] A, double[] values, int[] columnIndices, int[] rowOffsets)
    {
        Line();
        Console.WriteLine("Compressed Sparse Rows (CSR)");
        Line();

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Matrix A");
        Line();
        matrixPrinter(A);
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Values");
        Line();
        vectorPrinter(values);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Column Indices");
        Line();
        vectorPrinter(columnIndices.Select(Convert.ToDouble).ToArray());
        Console.WriteLine(" ");      
        
        Line();
        Console.WriteLine("Row Offsets");
        Line();
        vectorPrinter(columnIndices.Select(Convert.ToDouble).ToArray());
        Console.WriteLine(" ");
    }

    public static void BandedPrinter(double[,] A, double[] values, int bandwith)
    {
        Line();
        Console.WriteLine("Banded");
        Line();

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Matrix A");
        Line();
        matrixPrinter(A);
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Values");
        Line();
        vectorPrinter(values);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Bandwidth");
        Line();
        Console.WriteLine(bandwith);
        Console.WriteLine(" ");
    }

    public static void SkylinePrinter(double[,] A, double[] values, double[] diagonalOffsets)
    {
        Line();
        Console.WriteLine("Skyline GT-R 1200 PS");
        Line();

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Matrix A");
        Line();
        matrixPrinter(A);
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Values");
        Line();
        vectorPrinter(values);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Diagonal offsets");
        Line();
        vectorPrinter(diagonalOffsets);
        Console.WriteLine(" ");
    }

    public static void CholeskySkylinePrinter(double[] values, double[] diagonalOffsets, double[] x)
    {
        Line();
        Console.WriteLine(":ower Triangular Skyline");
        Line();

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Values");
        Line();
        vectorPrinter(values);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Diagonal offsets");
        Line();
        vectorPrinter(diagonalOffsets);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Cholesky Skyline storage ");
        Console.WriteLine("x");
        Line();
        vectorPrinter(x);
        Console.WriteLine(" ");
    }

    public static void COOPrinter(double[,] A, double[] values, int[] column, int[] row)
    {
        Line();
        Console.WriteLine("Coordinate List (COO)");
        Line();

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Matrix A");
        Line();
        matrixPrinter(A);
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Line();
        Console.WriteLine("Values");
        Line();
        vectorPrinter(values);
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Row");
        Line();
        vectorPrinter(row.Select(Convert.ToDouble).ToArray());
        Console.WriteLine(" ");

        Line();
        Console.WriteLine("Column");
        Line();
        vectorPrinter(column.Select(Convert.ToDouble).ToArray());
        Console.WriteLine(" ");

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    public static void criticalLoad1Printer(double Load, double u, bool NRConvergence, int NRIterations)
    {
        Console.WriteLine("F = " + Load.ToString("E10") + "  u = " + u.ToString("E10") + "  Convergence = " + NRConvergence.ToString() + "NR Iterations = " + NRIterations);
    }

    public static void criticalLoad1Saver(List<string> Force, List<string> Displacement, List<string> Iterations, double Load, double u, int NRIterations)
    {
        Force.Add(Load.ToString("E10"));
        Displacement.Add(u.ToString("E10"));
        Iterations.Add(NRIterations.ToString("E10"));
    }

    public static void criticalLoad1DAT(List<string> Force, List<string> Displacement, List<string> Iterations)
    {
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad_force.dat", Force);
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad_displacement.dat", Displacement);
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad_iterations.dat", Iterations);
    }
    
    public static void criticalLoad2Printer(double Load1, double Load2, double[] u, bool NRConvergence, int NRIterations)
    {
        Console.WriteLine("F1 = " + Load1.ToString("E10") + "F2 = " + Load2.ToString("E10") + "  x1 = " + u[0].ToString("E10") + "  x2 = " + u[1].ToString("E10") + "  Convergence = " + NRConvergence.ToString() + "NR Iterations = " + NRIterations);
    }
    
    public static void criticalLoad2Saver(List<string> Force, List<string> Displacement, List<string> Iterations, double Load, double u, int NRIterations)
    {
        Force.Add(Load.ToString("E10"));
        Displacement.Add(u.ToString("E10"));
        Iterations.Add(NRIterations.ToString("E10"));
    }

    public static void criticalLoad2DAT(List<string> Force, List<string> Displacement, List<string> Iterations)
    {
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad2_force.dat", Force);
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad2_displacement.dat", Displacement);
        File.WriteAllLines(@"C:\Users\Orestis\CriticalLoad2_iterations.dat", Iterations);
    }

    public static void checker(double[] expected, double[] y)
    {
        for (int i = 0; i < expected.Length; i++)
        {
            Debug.Assert(expected[i] == y[i]);
        }
    }

    public static void csvCreatorX(double[,] res)
    {

        using (StreamWriter file = new StreamWriter("/home/prizatoixou/Code/meshBeta2/gnuPlots/resultsX.csv"))
        {
            var iLength = res.GetLength(0);
            var jLength = res.GetLength(1);

            {
                for (int i = 0; i < iLength; i++)
                {
                    string content = "";
                    for (int j = 0; j < jLength; j++)
                    {
                        content += res[i, j] + ";";
                    }
                    file.WriteLine(content);
                }
            }

        }

    }

    public static void csvCreatorY(double[,] res)
    {

        using (StreamWriter file = new StreamWriter("/home/prizatoixou/Code/meshBeta2/gnuPlots/resultsY.csv"))
        {
            var iLength = res.GetLength(0);
            var jLength = res.GetLength(1);

            {
                for (int i = 0; i < iLength; i++)
                {
                    string content = "";
                    for (int j = 0; j < jLength; j++)
                    {
                        content += res[i, j] + ";";
                    }
                    file.WriteLine(content);
                }
            }

        }
    }

        public static void csvCreatorZ(double[,] res)
    {

        using (StreamWriter file = new StreamWriter("/home/prizatoixou/Code/meshBeta2/gnuPlots/resultsZ.csv"))
        {
            var iLength = res.GetLength(0);
            var jLength = res.GetLength(1);

            {
                for (int i = 0; i < iLength; i++)
                {
                    string content = "";
                    for (int j = 0; j < jLength; j++)
                    {
                        content += res[i, j] + ";";
                    }
                    file.WriteLine(content);
                }
            }

        }
    }




    public static void Title(string title)
    {

        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        Console.WriteLine(title);
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }    

    public static void TwoBigLines()
        {
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
        }
    
    public static void Line()
    {
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------");

        }
    }

    public class Calculators
    {
        public Calculators() { }
        public static double[] vectorAddition(double[] a, double[] b)
        {
            var n = a.Length;
            double[] additionResult;
            additionResult = Calculator();

            double[] Calculator()
            {
                if (a.Length != b.Length) throw new ArgumentException("a and b should have the same length");
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    result[i] = a[i] + b[i];
                }
                return result;
            }
            return additionResult;
        }
        
        public static double[] vectorSubtraction(double[] a, double[] b)
        {
            var n = a.Length;
            double[] subtractionResult;
            subtractionResult = Calculator();

            double[] Calculator()
            {
                if (a.Length != b.Length) throw new ArgumentException("a and b should have the same length");
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    result[i] = a[i] - b[i];
                }
                return result;
            }
            return subtractionResult;
        }

        public static double[] vectorScalarMultiplication(double scalar, double[] a)
        {
            var n = a.Length;
            double[] vectorScalarMultiplicationResult;
            vectorScalarMultiplicationResult = Calculator();

            double[] Calculator()
            {
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    result[i] = scalar * a[i];
                }
                return result;
            }
            return vectorScalarMultiplicationResult;
        }

        public static double[] vectorEquals(double[] a)
        {
            var n = a.Length;
            double[] vectorEqResult;
            vectorEqResult = Calculator();

            double[] Calculator()
            {
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    result[i] = a[i];
                }
                return result;
            }
            return vectorEqResult;
        }

        public static double[] vectorLinearCombination(double scalar1, double scalar2, double[] a, double[] b)
        {
            var n = a.Length;
            double[] vectorLinearCombinationResult = Calculator();
            double[] Calculator()
            {
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    result[i] = scalar1 * a[i] + scalar2 * b[i];
                }
                return result;
            }
            return vectorLinearCombinationResult;
        }

        public static double vectorDotProduct(double[] a, double[] b)
        {
            //ci = ai * bi
            var n = a.Length;
            double dotProductResult;
            dotProductResult = Calculator();

            double Calculator()
            {
                var result = 0d;
                for (int i = 0; i < n; i++)
                {
                    result += a[i] * b[i];
                }
                return result;
            }
            return dotProductResult;
        }

        public static double[,] vectorTensorProduct(double[] a, double[] b)
        {
            var n = a.Length;
            var m = b.Length;
            double[,] vectorTensorProductResult = new double[n, m];
            vectorTensorProductResult = Calculator();


            double[,] Calculator()
            {
                var result = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[i, j] = a[i] * b[j];
                    }
                }
                return result;
            }
            return vectorTensorProductResult;
        }

        public static double[,] MatrixTranspose(double[,] A)
        {
            //ATij = Aji
            var n = A.GetLength(0);

            double[,] ATranspose;
            ATranspose = Calculator();
            double[,] Calculator()
            {
                var result = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++) { result[i, j] = A[j, i]; }
                }
                return result;
            }
            return ATranspose;
        }

        public static double[] VectorMatrixMultiplication(double[,] A, double[] a)
        {
            // bi = aj * Aji 
            var n = A.GetLength(0);
            double[] vectorMatrixMultResult;
            vectorMatrixMultResult = Calculator();

            double[] Calculator()
            {
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++) { result[i] += a[j] * A[j, i]; }
                }
                return result;
            }
            return vectorMatrixMultResult;
        }

        public static double[] MatrixVectorMultiplication(double[,] A, double[] a)
        {
            // bi = Aij *bj  
            var n = A.GetLength(0);
            double[] matrixVectorMultResult;
            matrixVectorMultResult = Calculator();

            double[] Calculator()
            {
                var result = new double[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++) { result[i] += A[i, j] * a[j]; }
                }
                return result;
            }
            return matrixVectorMultResult;
        }

        public static double[,] MatrixMatrixMultiplication(double[,] A, double[,] B)
        {
            //Cij = AikAkj
            var n = A.GetLength(0);
            var MatrixMatrixMult = Calculator();

            double[,] Calculator()
            {
                var sum = 0d;
                var result = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum = 0d;
                        for (int k = 0; k < n; k++) { sum += A[i, k] * B[k, j]; }
                        result[i, j] = sum;
                    }
                }
                //var result = Matrix<double>.Build.DenseOfArray(A).Multiply(Matrix<double>.Build.DenseOfArray(B)).ToArray();
                return result;
            }
            return MatrixMatrixMult;
        }

        public static double RadToDegrees (double rad)
        {
            double pi = Math.Acos(-1d);
            return  rad * 180d * pi;
        }

        public static double DegreesToRad(double degrees)
        {
            double pi = Math.Acos(-1d);
            return degrees * pi / 180d;
        }

        // public static double[,] MatrixInverse(double[,] A)
        // {
        //     var n = A.GetLength(0);
        //     double[,] AInverse = new double[n, n];
        //     var Inverse = Matrix<double>.Build.DenseOfArray(A).Inverse().ToArray();
        //     return Inverse;
        // }

        public static double Norm2(double[] x, double[] xOld)
        {
            var sum = 0d;
            for (int i = 0; i < x.Length; i++) { sum += Math.Pow((x[i] - xOld[i]), 2); }
            var norm2 = Math.Sqrt(sum) / x.Length;
            return norm2;
        }

    }

}

}
