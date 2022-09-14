namespace utility
{

    public static class TransformationTensors
    {


        private static utilitiez.Calculators calculators = new utilitiez.Calculators();

        static TransformationTensors()
        { }
        public static  double[] Rotate(double[] array, double theta)
        {
            theta = utilitiez.Calculators.DegreesToRad(theta);
            var rotationTensor2D = new double[,] { { Math.Cos(theta), -Math.Sin(theta)},
                                                   { Math.Sin(theta),  Math.Cos(theta)}};

            var result = utilitiez.Calculators.MatrixVectorMultiplication(rotationTensor2D, array);
            return result;
        }

        public static  double[] Shear(double[] array, double shearAngleX, double shearAngleY)
        {
            var shearX = utilitiez.Calculators.DegreesToRad(shearAngleX);
            var shearY = utilitiez.Calculators.DegreesToRad(shearAngleY);

            var shearTensor2D    = new double[,] { { 1d,               Math.Tan(shearX)},
                                                   { Math.Tan(shearY),               1d}};    

            var result = utilitiez.Calculators.MatrixVectorMultiplication(shearTensor2D, array);
            return result;
        }

        public static double[] Scale(double[] array, double stepX, double stepY)
        {
            var scaleTensor2D    = new double[,] { { stepX,     0},
                                                   { 0,     stepY}};

            var result = utilitiez.Calculators.MatrixVectorMultiplication(scaleTensor2D, array);
            return result;
        }

        public static double[] MirrorX(double[] array)
        {
            var MirrorTensor2D    = new double[,] { { 1d,  0d},
                                                   { 0d, -1d}};
            var result = utilitiez.Calculators.MatrixVectorMultiplication(MirrorTensor2D, array);
            return result;
        }

        public static double[] MirrorY(double[] array)
        {
            var MirrorTensor2D    = new double[,] { { -1d, 0d},
                                                   {  0d, 1d}};
            var result = utilitiez.Calculators.MatrixVectorMultiplication(MirrorTensor2D, array);
            return result;
        }

        public static double[] Translate(double[] array, double hx, double hy)
        {
            var TranslationalTensor    = new double[,] { { array[0] + hx, 0d           },
                                                         { 0d,            array[1] + hy}};
            var result = utilitiez.Calculators.MatrixVectorMultiplication(TranslationalTensor, array);
            return result;
        }
    }



}
