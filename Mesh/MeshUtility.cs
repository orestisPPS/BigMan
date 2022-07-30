 using AwokeKnowing.GnuplotCSharp;
 using Discretization;
 namespace Mesh
 {

    public static class MeshUtility
    {
        static MeshUtility() {}

        public static void CheckInputData(DomainBoundary[] DomainBoundaries)
        {
            if (DomainBoundaries.Count() != 4)
                {throw new Exception("INSERT 4 BOUNDARIES"); }
            else if (DomainBoundaries[0].Id != 0 || DomainBoundaries[1].Id != 1 || DomainBoundaries[2].Id != 2 || DomainBoundaries[3].Id != 3)
                {throw new Exception("INSERT BOUNDARIES WITH THIS ORDER : BOTTOM(0) -> RIGHT(1) -> TOP(2) -> LEFT(3)"); }
            else if  (DomainBoundaries[0].boundaryNodes.Count() != DomainBoundaries[2].boundaryNodes.Count()) 
                {throw new Exception("MISMATCH IN NODE NUMBER IN BOUNDARIES: 0 AND 2");}
            else if  (DomainBoundaries[1].boundaryNodes.Count() != DomainBoundaries[3].boundaryNodes.Count())
                {throw new Exception("MISMATCH IN NODE NUMBER IN BOUNDARIES: 1 AND 3");}
            else 
                {Console.WriteLine("INPUT DATA CHECKED! PROCCEED TO MESH GENERATOR...");}
        }

        // public static Node NeighbourFinder(Node node, string direction) 
        // {
        //     var result = new Node();

        //     if      (direction == "N"  ) { result = node.hood["N"];}
        //     else if (direction == "NN" ) { result = node.hood["N"].hood["N"];}
        //     else if (direction == "NNN") { result = node.hood["N"].hood["N"];}
            
        //     else if (direction == "S"  ) { result = node.hood["S"];}
        //     else if (direction == "SS" ) { result = node.hood["S"].hood["S"];}
        //     else if (direction == "SSS") { result = node.hood["S"].hood["S"].hood["S"];}
            
        //     else if (direction == "W"  ) { result = node.hood["W"];}
        //     else if (direction == "WW" ) { result = node.hood["W"].hood["W"];}
        //     else if (direction == "WWW") { result = node.hood["W"].hood["W"].hood["W"];}
            
        //     else if (direction == "E"  ) { result = node.hood["E"];}
        //     else if (direction == "EE" ) { result = node.hood["E"].hood["E"];}
        //     else if (direction == "EEE") { result = node.hood["E"].hood["E"];}

        //     return result;
        // }

        // public static void CalculateMetrix(Node[,] nodeMesh)
        // {
        //     var nnx = nodeMesh.GetLength(0);
        //     var nny = nodeMesh.GetLength(1);

        //     for (int i = 0; i < nnx; i++)
        //     {
        //         for (int j = 0; j < nny; j++)
        //         {
        //             nodeMesh[i, j].metrics.CalculateMetrics(nodeMesh[i, j]);
        //         }
        //     }
        // }
        
        public static void GnuplotBoundary(DomainBoundary[] domainBoundaries)
        {
            GnuPlot.HoldOn();
            GnuPlot.Set("xlabel 'X'") ;
            GnuPlot.Set("ylabel 'Y'");
            GnuPlot.Set("grid");
            foreach (var boundary in domainBoundaries)
            {
                var nn = boundary.BoundaryNodesCoordinates.GetLength(0);
                var x = new double[nn];
                var y = new double[nn];
                for (int i = 0; i < nn; i++)
                {
                    x[i] = boundary.BoundaryNodesCoordinates[i, 0];
                    y[i] = boundary.BoundaryNodesCoordinates[i, 1];
                }
                GnuPlot.Plot(x, y);
            }
            GnuPlot.HoldOff(); 
        }

        // public static void MeshPrinter(Node[,] nodeMesh)
        // {
        //     var nnx = nodeMesh.GetLength(0);
        //     var nny = nodeMesh.GetLength(1);
        //     for (int j =0; j < nny; j++)
        //     {
        //         for (int i = 0; i < nnx; i++)
        //         {
        //             Console.WriteLine("ID " + nodeMesh[i, j].Id.Global + " B ID: " 
        //             + nodeMesh[i,j].Id.Boundary +  " I ID: " + nodeMesh[i,j].Id.Internal 
        //             + " x: " + nodeMesh[i,j].Coordinates[NaturalX].value + " y: " + nodeMesh[i,j].NatCoord.Y);
        //         }
        //     }
        // }
        public static void GnuplotMesh  (double[,] x, double[,] y)
        {
            var nnx = x.GetLength(0);
            var nny = x.GetLength(1);
            var xCol = new double[nny];
            var yCol = new double[nny];
            var xRow = new double[nnx];
            var yRow = new double[nnx];
            var k = 0;
            GnuPlot.HoldOn();
            for (int i = 0; i < nny; i++)
            {
                for (int j = 0; j < nnx; j++ )
                {
                    xRow[j] = x[i, j];
                    yRow[j] = y[i, j];
                }
                GnuPlot.Plot(xRow, yRow, "with lines");
            }
            for (int i = 0; i < nnx; i++)
            {
                for (int j = 0; j < nny; j++ )
                {
                    xCol[j] = x[i, j];
                    yCol[j] = y[i, j];
                }
                GnuPlot.Plot(xCol, yCol, "with lines");
            }

            //GnuPlot.HoldOff();
            GnuPlot.Set("xlabel 'X'") ;
            GnuPlot.Set("ylabel 'Y'");

            GnuPlot.Set("grid");
            // GnuPlot.Set("xrange[-1.02 : 1.02]");
            // GnuPlot.Set("yrange[-1.02 : 1.02]");
            //GnuPlot.Set("xrange[0.0: 1.02]");
            //GnuPlot.Set("yrange[-10 : 10]");
            // GnuPlot.Set("xtics 0.1");
            // GnuPlot.Set("ytics 0.1");
        }

    }
}