using prizaLinearAlgebra;
using utility;
namespace Mesh
{
    public static class BoundaryCreator
    {

        public static DomainBoundary[] Ellipse(int nnx, int nny)
        {
            var domainBoundaries = new DomainBoundary[4];

            var pi = Math.Acos(-1d);
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 

            var a = 1; //horizontal radius
            var b = 1; //vertical radius


            var k = 0;
            var x = new double[nnx * nny];
            var y = new double[nnx * nny];



            //bottom

            var theta = 5 * pi / 4;
            var hTheta = (pi / 2 ) / (nnx - 1);
            for (int i = 0; i < nnx; i++)
            {
                //x
                coordinatesX[i, 0] = a * Math.Cos(theta + i * hTheta);
                x[k] = coordinatesX[i, 0];
                //y
                coordinatesX[i, 1] = b * Math.Sin(theta + i * hTheta);
                y[k] = coordinatesX[i, 1];
                k++;

            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);

            //right
            theta = 7 * pi / 4;
            hTheta = (pi / 2 ) / (nny - 1);
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int i = 0; i < nnx; i++)
            {
                //x
                coordinatesY[i, 0] = a * Math.Cos(theta + i * hTheta);
                x[k] = coordinatesY[i, 0];
                //y
                coordinatesY[i, 1] = b * Math.Sin(theta + i * hTheta);
                y[k] = coordinatesY[i, 1];
                k++;


            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);

            //top
            theta = pi / 4;
            hTheta = (pi / 2 ) / (nnx - 1);
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int i = 0; i < nnx; i++)
            {
                //x
                coordinatesX[i, 0] = a * Math.Cos(theta + i * hTheta);
                x[k] = coordinatesX[i, 0];
                //y
                coordinatesX[i, 1] = b * Math.Sin(theta + i * hTheta);
                y[k] = coordinatesX[i, 1];
                k++;

            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);

            //left
            hTheta = ( pi / 2 )   / (nny - 1);
            theta = 3 * pi / 4;
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int i = 0; i < nny; i++)
            {
                //x
                coordinatesY[i, 0] = a * Math.Cos(theta + i * hTheta);
                x[k] = coordinatesY[i, 0];
                //y
                coordinatesY[i, 1] = b * Math.Sin(theta + i * hTheta);
                y[k] = coordinatesY[i, 1];
                k++;

            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);

            //GnuPlot.Plot(x,y);

            
            return domainBoundaries;
        }



        /// <summary>
        /// creates a rotating parallelogram like mesh boundary with variable cell size and tiltation 
        /// </summary>
        /// <param name="nnx">number of nodes in direction 1 (x)</param>
        /// <param name="nny">number of nodes in direction 2 (y)</param>
        /// <param name="hx">step in direction 1 (x)</param>
        /// <param name="hy">step in direction 2 (y)</param>
        /// <param name="rotAngle">the rotation angle of the mesh [DEGREES]</param>
        /// <param name="tiltAngle">the tilt angle of the mesh cells [DEGREES]</param>
        // /// <returns> returns 4 arrays with the boundary nodes</returns>
        
        public static DomainBoundary[] ParalleloGram(int nnx, int nny, double hx, double hy, double rotAngle, double shearX, double shearY)
        {
            var rot = utilitiez.Calculators.DegreesToRad(rotAngle);
            var ShearX = utilitiez.Calculators.DegreesToRad(shearX);
            var ShearY = utilitiez.Calculators.DegreesToRad(shearY);
            var domainBoundaries = new DomainBoundary[4];

            var pi = Math.Acos(-1d);
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 


            //bottom 
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i;
                var yStep = 0;

                var transformedCoord = Transform(new double[]{xStep, yStep});
                coordinatesX[i, 0] = transformedCoord[0];
                coordinatesX[i, 1] = transformedCoord[1];

            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);

            //right
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int j = 0; j < nny; j++)
            {
                var xStep = nnx - 1;
                var yStep = j;
                var transformedCoord = Transform(new double[]{xStep, yStep});
                coordinatesY[j, 0] = transformedCoord[0];
                coordinatesY[j, 1] = transformedCoord[1];

            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);

            //top
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int i = 0; i < nnx; i++)
            {
                var xStep = nnx - 1 - i;
                var yStep = nny - 1;
                var transformedCoord = Transform(new double[]{xStep, yStep});
                coordinatesX[i, 0] = transformedCoord[0];
                coordinatesX[i, 1] = transformedCoord[1];

            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);

            //left
            coordinatesX = new double[nnx, 2];
            coordinatesY = new double[nny, 2]; 
            for (int j = 0; j < nny; j++)
            {
                var xStep = 0;
                var yStep = nny - 1 - j;
                var transformedCoord = Transform(new double[]{xStep, yStep});
                coordinatesY[j, 0] = transformedCoord[0];
                coordinatesY[j, 1] = transformedCoord[1];

            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);

            //GnuPlot.Plot(x,y);

            
            return domainBoundaries;

            double[] Transform(double[] initialCoord)
            {
                var transformedCoord = TransformationTensors.Rotate (initialCoord, rotAngle);
                transformedCoord = TransformationTensors.Shear(transformedCoord, shearX, shearY);
                transformedCoord = TransformationTensors.Scale(transformedCoord, hx, hy);
                return transformedCoord;    
            }
        }

        public static DomainBoundary[] TurboOutlet(int nnx, int nny, double dInlet)
        {

            var domainBoundaries = new DomainBoundary[4];
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 

            var pi = Math.Acos(-1d);
            var dx = 1d / (nnx - 1);      
            //bottom 
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i * dx;
                coordinatesX[i, 0] = xStep;
                coordinatesX[i, 1] = - dInlet / 2d - 1.5 * Math.Sin(-1.5 * xStep);
            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);

            //top
            coordinatesX = new double[nnx, 2];
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i * dx;
                coordinatesX[nnx - 1 - i, 0] = xStep;
                coordinatesX[nnx - 1 - i, 1] = dInlet / 2d + 1.5 * Math.Sin(-1.5 * xStep);
            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);



            //left
            coordinatesY = new double[nny,2];
            var leftXLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 0];
            var leftYLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 1];
            var leftXUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 0];
            var leftYUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 1];
            if (leftXLow != leftXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            var dy = (leftYUp - leftYLow) / (nny - 1d);
            coordinatesY[0, 0] = leftXLow;
            coordinatesY[0, 1] = leftYLow;
            coordinatesY[nny - 1, 0] = leftXUp;
            coordinatesY[nny - 1, 1] = leftYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = leftYLow + j * dy;
                coordinatesY[nny -1 - j, 0] = leftXLow;
                coordinatesY[nny -1 - j, 1] = stepY;
            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);
            



            //right
            coordinatesY = new double[nny,2];
            var rightXLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 0];
            var rightYLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 1];
            var rightXUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 0];
            var rightYUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 1];
            if (rightXLow != rightXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            dy = (rightYUp - rightYLow) / (nny - 1d);
            coordinatesY[0, 0] = rightXLow;
            coordinatesY[0, 1] = rightYLow;
            coordinatesY[nny - 1, 0] = rightXUp;
            coordinatesY[nny - 1, 1] = rightYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = rightYLow + j * dy;
                coordinatesY[j, 0] = rightXLow;
                coordinatesY[j, 1] = stepY;
            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);
            MeshUtility.GnuplotBoundary(domainBoundaries);

            return domainBoundaries;

        }

        public static DomainBoundary[] TurboOutlet2(int nnx, int nny, double dInlet)
        {

            var domainBoundaries = new DomainBoundary[4];
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 

            var pi = Math.Acos(-1d);
            var dx = 0.1 + 0.5d / (nnx - 1);      
            //bottom 
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i * dx;
                coordinatesX[i, 0] = xStep;
                coordinatesX[i, 1] = - dInlet / 2d - 5 * Math.Sqrt(10 * xStep);
            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);

            //top
            coordinatesX = new double[nnx, 2];
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i * dx;
                coordinatesX[nnx - 1 - i, 0] = xStep;
                coordinatesX[nnx - 1 - i, 1] = dInlet / 2d + 5 * Math.Sqrt(10 * xStep);
            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);



            //left
            coordinatesY = new double[nny,2];
            var leftXLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 0];
            var leftYLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 1];
            var leftXUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 0];
            var leftYUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 1];
            if (leftXLow != leftXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            var dy = (leftYUp - leftYLow) / (nny - 1d);
            coordinatesY[0, 0] = leftXLow;
            coordinatesY[0, 1] = leftYLow;
            coordinatesY[nny - 1, 0] = leftXUp;
            coordinatesY[nny - 1, 1] = leftYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = leftYLow + j * dy;
                coordinatesY[nny -1 - j, 0] = leftXLow;
                coordinatesY[nny -1 - j, 1] = stepY;
            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);
            
            //right
            coordinatesY = new double[nny,2];
            var rightXLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 0];
            var rightYLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 1];
            var rightXUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 0];
            var rightYUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 1];
            if (rightXLow != rightXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            dy = (rightYUp - rightYLow) / (nny - 1d);
            coordinatesY[0, 0] = rightXLow;
            coordinatesY[0, 1] = rightYLow;
            coordinatesY[nny - 1, 0] = rightXUp;
            coordinatesY[nny - 1, 1] = rightYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = rightYLow + j * dy;
                coordinatesY[j, 0] = rightXLow;
                coordinatesY[j, 1] = stepY;
            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);
            MeshUtility.GnuplotBoundary(domainBoundaries);

            return domainBoundaries;

        }


        public static DomainBoundary[] GarrettTourbine1(int nnx, int nny, double dInlet)
        {

            var domainBoundaries = new DomainBoundary[4];
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 

            var pi = Math.Acos(-1d);
            var dx = (1d - 0.0) / (nnx - 1);      
            //bottom 
            for (int i = 0; i < nnx; i++)
            {
                var xStep = i * dx;
                coordinatesX[i, 0] = 0.0 +  xStep;
                coordinatesX[i, 1] = - dInlet / 2d - 5 * Math.Exp(5 * Math.Pow(xStep, 0.9));
            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);

            //top
            coordinatesX = new double[nnx, 2];
            for (int i = 0; i < nnx; i++)
            {
                var xStep = (nnx - 1 - i) * dx;
                coordinatesX[i, 0] = 0.0 + xStep;
                coordinatesX[i, 1] = dInlet / 2d + 5 * Math.Exp(5 * Math.Pow(xStep, 0.9));
            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);



            //left
            coordinatesY = new double[nny,2];
            var leftXLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 0];
            var leftYLow = domainBoundaries[0].BoundaryNodesCoordinates[0, 1];
            var leftXUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 0];
            var leftYUp  = domainBoundaries[2].BoundaryNodesCoordinates[nnx - 1, 1];
            if (leftXLow != leftXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            var dy = (leftYUp - leftYLow) / (nny - 1d);
            coordinatesY[0, 0] = leftXLow;
            coordinatesY[0, 1] = leftYLow;
            coordinatesY[nny - 1, 0] = leftXUp;
            coordinatesY[nny - 1, 1] = leftYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = leftYLow + (nny - 2 - j) * dy;
                coordinatesY[j, 0] = leftXLow;
                coordinatesY[j, 1] = stepY;
            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);
            
            //right
            coordinatesY = new double[nny,2];
            var rightXLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 0];
            var rightYLow = domainBoundaries[0].BoundaryNodesCoordinates[nnx - 1, 1];
            var rightXUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 0];
            var rightYUp  = domainBoundaries[2].BoundaryNodesCoordinates[0, 1];
            if (rightXLow != rightXUp) { throw new Exception("The first node of the top and bottom boundaries have different x coordinates");}
            dy = (rightYUp - rightYLow) / (nny - 1d);
            coordinatesY[0, 0] = rightXLow;
            coordinatesY[0, 1] = rightYLow;
            coordinatesY[nny - 1, 0] = rightXUp;
            coordinatesY[nny - 1, 1] = rightYUp;
            for (int j = 1; j < nny -1; j++)
            {
                var stepY = rightYLow + j * dy;
                coordinatesY[j, 0] = rightXLow;
                coordinatesY[j, 1] = stepY;
            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);
            MeshUtility.GnuplotBoundary(domainBoundaries);

            return domainBoundaries;

        }

        public static DomainBoundary[] Tube(int nnx, int nny, double dInlet)
        {

            var domainBoundaries = new DomainBoundary[4];
            var coordinatesX = new double[nnx, 2];
            var coordinatesY = new double[nny, 2]; 


            var dx = (1d - (-1d)) / (nny - 1);        
            //left 
            for (int i = 0; i < nny; i++)
            {
                var xStep = i * dx;
                coordinatesY[i, 0] = xStep;
                coordinatesY[i, 1] = Math.Pow(xStep, 5d);
            }
            domainBoundaries[3] = new DomainBoundary(3, coordinatesY);

            //right
            coordinatesY = new double[nny, 2];
            for (int i = 0; i < nny; i++)
            {
                var xStep = i * dx;
                var transformedCoord = TransformationTensors.Translate(new double[] {domainBoundaries[3].BoundaryNodesCoordinates[i, 0], domainBoundaries[3].BoundaryNodesCoordinates[i, 1], dInlet, 0d }, dInlet, 0);
                coordinatesY[nny - 1 - i, 0] = transformedCoord[0];
                coordinatesY[nny - 1 - i, 1] = transformedCoord[1];
            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesY);

            //Bottom
            coordinatesX = new double[nnx,2];
            var botXLeft = domainBoundaries[3].BoundaryNodesCoordinates[nny - 1, 0];
            var botYLeft = domainBoundaries[3].BoundaryNodesCoordinates[nny - 1, 1];
            var botXRight  = domainBoundaries[1].BoundaryNodesCoordinates[0, 0];
            var botYRight  = domainBoundaries[1].BoundaryNodesCoordinates[0, 1];
            if (botYLeft != botYRight) { throw new Exception("The first node of the left and right boundaries have different y coordinates");}
            dx = (botXRight - botXLeft) / (nnx - 1d);
            coordinatesX[0, 0] = botXLeft;
            coordinatesX[0, 1] = botYRight;
            coordinatesX[nny - 1, 0] = botXRight;
            coordinatesX[nny - 1, 1] = botYLeft;
            for (int j = 1; j < nny -1; j++)
            {
                var stepx = botYLeft + j * dx;
                coordinatesX[nnx -1 - j, 0] = stepx;
                coordinatesX[nnx -1 - j, 1] = botYLeft;
            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesX);
            
            //Top
            coordinatesX = new double[nnx,2];
            var topXLeft = domainBoundaries[3].BoundaryNodesCoordinates[0, 0];
            var topYLeft = domainBoundaries[3].BoundaryNodesCoordinates[0, 1];
            var topXRight  = domainBoundaries[1].BoundaryNodesCoordinates[nny - 1, 0];
            var topYRight  = domainBoundaries[1].BoundaryNodesCoordinates[nny - 1, 1];
            if (topYLeft != topYRight) { throw new Exception("The first node of the left and right boundaries have different y coordinates");}
            dx = (topXRight - topXLeft) / (nnx - 1d);
            coordinatesX[0, 0] = topXLeft;
            coordinatesX[0, 1] = topYRight;
            coordinatesX[nny - 1, 0] = topXRight;
            coordinatesX[nny - 1, 1] = topYLeft;
            for (int j = 1; j < nny -1; j++)
            {
                var stepx = topYLeft + j * dx;
                coordinatesX[nnx -1 - j, 0] = stepx;
                coordinatesX[nnx -1 - j, 1] = topYLeft;
            }
            domainBoundaries[2] = new DomainBoundary(2, coordinatesX);
            
            MeshUtility.GnuplotBoundary(domainBoundaries);

            return domainBoundaries;

        }




        public static DomainBoundary[] Gewrgiou(int nnx, int nny, double dHole, double thickness, double phiDeg)
        {
            var pi = Math.Acos(-1d);
            var phiRad = utilitiez.Calculators.DegreesToRad(phiDeg);
            var thetaRad = 2 * pi - phiRad;

            var domainBoundaries = new DomainBoundary[4];
            var coordinatesBot = new double[nnx, 2];
            var coordinatesTop = new double[nnx, 2];
            var coordinatesRight = new double[nny, 2];
            var coordinatesLeft = new double[nny, 2];

            //bottom & top
            var dtheta = (thetaRad) / (nnx - 1d);      
            for (int i = 0; i < nnx; i++)
            {
                var thetaStep = i * dtheta;
                coordinatesBot[i, 0] = thickness * Math.Cos(thetaStep);
                coordinatesBot[i, 1] = thickness * Math.Sin(thetaStep);
                coordinatesTop[i, 0] = dHole * Math.Cos((nnx - 1 - i) * dtheta);
                coordinatesTop[i, 1] = dHole * Math.Sin((nnx - 1 - i) * dtheta);
            }
            domainBoundaries[0] = new DomainBoundary(0, coordinatesBot);
            domainBoundaries[2] = new DomainBoundary(2, coordinatesTop);

            
            //right & left
            var dr = (thickness - dHole) / (nny - 1d);
            for (int i = 0; i < nny; i++)
            {
                coordinatesRight[i, 0] = (thickness - i * dr) * Math.Cos(dtheta * (nnx - 1));
                coordinatesRight[i, 1] = (thickness - i * dr) * Math.Sin(dtheta * (nnx - 1));
                coordinatesLeft[i, 0]  = (dHole + i * dr) * Math.Cos(0);
                coordinatesLeft[i, 1]  = (dHole + i * dr) * Math.Sin(0);
            }
            domainBoundaries[1] = new DomainBoundary(1, coordinatesRight);
            domainBoundaries[3] = new DomainBoundary(3, coordinatesLeft);

            MeshUtility.GnuplotBoundary(domainBoundaries);

            //if ( (coordinatesRight[0,0] != coordinatesBot[nnx - 1, 0]) & (coordinatesRight[nny - 1,0] != coordinatesBot[nnx - 1, 0]) & (coordinatesRight[0,1] != coordinatesTop[nnx - 1, 1]) & (coordinatesRight[nny - 1, 1] != coordinatesBot[nnx - 1, 1]));
            //throw new Exception("rigt - top Mismatch");

            // if (coordinatesLeft[0,0] != coordinatesTop[0, 0] & coordinatesLeft[nny - 1,0] != coordinatesBot[nnx - 1, 0] & coordinatesRight[0,1] != coordinatesTop[nnx - 1, 1] & coordinatesRight[nny - 1, 1] != coordinatesBot[nnx - 1, 1])
            // throw new Exception("rigt - top Mismatch");


            
            return(domainBoundaries);

        }






    }
}



