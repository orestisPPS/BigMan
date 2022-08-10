using prizaLinearAlgebra;
using utility;
using Discretization;
namespace Mesh
{
    public class NodeMetrics
    {
        public double[] covariants1 {get; internal set;}
        public double[] covariants2 {get; internal set;}
        public double[] contravariants1 {get; internal set;}
        public double[] contravariants2 {get; internal set;}
        public double[,] covariantTensor {get; internal set;}
        public double[,] contravariantTensor {get; internal set;}
        public double Jacobian {get; internal set;}

        public NodeMetrics()
        {
            covariants1 = new double[2];
            covariants2 = new double[2];
            contravariants1 = new double[2];
            contravariants2 = new double[2];
            covariantTensor = new double[2, 2];
            contravariantTensor = new double[2, 2];
        } 


        public void CalculateNodeMetrics(Node node)
        {
            if (node.boundaryType != -1)
            {
                //Bottom left node
                if (node.boundaryType == 0.3)
                {
                    //[x,ksi, y,ksi]
                    covariants1[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["E"].TempCoord.X, 1); 
                    covariants1[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["E"].TempCoord.Y, 1);     

                    //[[x,ita, y,ita]]
                    covariants2[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["N"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["N"].TempCoord.Y, 1);     
                    
                    //[ksi,x, ita,x]
                    contravariants1[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["E"].CompCoord.Ita,  node.hood["E"].TempCoord.X - node.TempCoord.X ); 
                    contravariants1[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["E"].CompCoord.Ksi,  node.hood["E"].TempCoord.X - node.TempCoord.X );     

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y); 

                }
                //Bottom right node
                if (node.boundaryType == 0.1)
                {
                    covariants1[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["W"].TempCoord.X, 1); 
                    covariants1[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["W"].TempCoord.Y, 1);  

                    covariants2[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["N"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["N"].TempCoord.Y, 1);  

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["W"].CompCoord.Ksi, node.hood["W"].TempCoord.X - node.TempCoord.X);     
                    contravariants1[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["W"].CompCoord.Ita, node.hood["W"].TempCoord.X - node.TempCoord.X); 

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y); 

                }
                //Top right node
                if (node.boundaryType == 1.2)
                {
                    covariants1[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["W"].TempCoord.X, 1); 
                    covariants1[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["W"].TempCoord.Y, 1);     

                    covariants2[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["S"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["S"].TempCoord.Y, 1);   

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["W"].CompCoord.Ksi, node.hood["W"].TempCoord.X - node.TempCoord.X);     
                    contravariants1[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["W"].CompCoord.Ita, node.hood["W"].TempCoord.X - node.TempCoord.X); 

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["S"].CompCoord.Ksi, node.TempCoord.Y -node.hood["S"].TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["S"].CompCoord.Ita, node.TempCoord.Y -node.hood["S"].TempCoord.Y); 
                }
                //Top left node
                if (node.boundaryType == 2.3)
                {
                    covariants1[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["E"].TempCoord.X, 1); 
                    covariants1[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["E"].TempCoord.Y, 1);     

                    covariants2[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["S"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["S"].TempCoord.Y, 1);

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["E"].CompCoord.Ksi,  node.hood["E"].TempCoord.X - node.TempCoord.X );     
                    contravariants1[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["E"].CompCoord.Ita,  node.hood["E"].TempCoord.X - node.TempCoord.X ); 

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["S"].CompCoord.Ksi, node.TempCoord.Y -node.hood["S"].TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["S"].CompCoord.Ita, node.TempCoord.Y -node.hood["S"].TempCoord.Y);  
                }

                //bottom boundary
                if (node.boundaryType == 0d)
                {
                    covariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.Y, node.hood["E"].TempCoord.Y,  1);  
                    covariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.X, node.hood["E"].TempCoord.X,  1);  

                    covariants2[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["N"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["N"].TempCoord.Y, 1);

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ksi, node.hood["E"].CompCoord.Ksi, node.hood["W"].TempCoord.X - node.TempCoord.X);     
                    contravariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ita, node.hood["E"].CompCoord.Ita, node.hood["W"].TempCoord.X - node.TempCoord.X);    

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y);       
                }

                //right boundary
                if (node.boundaryType == 1d)
                {
                    covariants1[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["W"].TempCoord.X, 1);  
                    covariants1[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["W"].TempCoord.Y, 1);  

                    covariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.X, node.hood["N"].TempCoord.X, 1);   
                    covariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.Y, node.hood["N"].TempCoord.Y, 1);

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["W"].CompCoord.Ksi, node.hood["W"].TempCoord.X - node.TempCoord.X);     
                    contravariants1[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["W"].CompCoord.Ita, node.hood["W"].TempCoord.X - node.TempCoord.X); 

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y);
                    contravariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y);  

                }

                //top boundary
                if (node.boundaryType == 2d)
                {
                    covariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.X, node.hood["E"].TempCoord.X, 1);  
                    covariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.Y, node.hood["E"].TempCoord.Y, 1);      

                    covariants2[0] = FirstDerivative.BackwardDifference1(node.TempCoord.X, node.hood["S"].TempCoord.X, 1); 
                    covariants2[1] = FirstDerivative.BackwardDifference1(node.TempCoord.Y, node.hood["S"].TempCoord.Y, 1);

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ksi, node.hood["E"].CompCoord.Ksi, node.hood["E"].TempCoord.X - node.TempCoord.X );    
                    contravariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ita, node.hood["E"].CompCoord.Ita, node.hood["E"].TempCoord.X - node.TempCoord.X );
                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.BackwardDifference1(node.CompCoord.Ksi, node.hood["S"].CompCoord.Ksi, node.TempCoord.Y -node.hood["S"].TempCoord.Y); 
                    contravariants2[1] = FirstDerivative.BackwardDifference1(node.CompCoord.Ita, node.hood["S"].CompCoord.Ita, node.TempCoord.Y -node.hood["S"].TempCoord.Y);        
                }

                //left boundary
                if (node.boundaryType == 3d)
                {
                    covariants1[0] = FirstDerivative.ForwardDifference1(node.TempCoord.X, node.hood["E"].TempCoord.X, 1);
                    covariants1[1] = FirstDerivative.ForwardDifference1(node.TempCoord.Y, node.hood["E"].TempCoord.Y, 1);

                    covariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.X, node.hood["N"].TempCoord.X, 1);  
                    covariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.Y, node.hood["N"].TempCoord.Y, 1);

                    //[ksi,x, ita,x]
                    contravariants1[0] = FirstDerivative.ForwardDifference1(node.CompCoord.Ksi, node.hood["E"].CompCoord.Ksi, node.hood["E"].TempCoord.X - node.TempCoord.X );     
                    contravariants1[1] = FirstDerivative.ForwardDifference1(node.CompCoord.Ita, node.hood["E"].CompCoord.Ita, node.hood["E"].TempCoord.X - node.TempCoord.X ); 

                    //[[ksi,y ita,y]
                    contravariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y);    
                    contravariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y);    
                }
            }
            else if (node.boundaryType == -1)
            {
                covariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.X, node.hood["E"].TempCoord.X, 1); 
                covariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].TempCoord.Y, node.hood["E"].TempCoord.Y, 1); 

                covariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.X, node.hood["N"].TempCoord.X, 1); 
                covariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].TempCoord.Y, node.hood["N"].TempCoord.Y, 1);

                //[ksi,x, ita,x]
                contravariants1[0] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ksi, node.hood["E"].CompCoord.Ksi, node.hood["W"].TempCoord.X - node.TempCoord.X);    
                contravariants1[1] = FirstDerivative.CentralDifference(node.hood["W"].CompCoord.Ita, node.hood["E"].CompCoord.Ita, node.hood["W"].TempCoord.X - node.TempCoord.X);

                //[[ksi,y ita,y]
                contravariants2[0] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ksi, node.hood["N"].CompCoord.Ksi, node.hood["N"].TempCoord.Y - node.TempCoord.Y);    
                contravariants2[1] = FirstDerivative.CentralDifference(node.hood["S"].CompCoord.Ita, node.hood["N"].CompCoord.Ita, node.hood["N"].TempCoord.Y - node.TempCoord.Y);    
            }

            covariantTensor[0, 0] = utilitiez.Calculators.vectorDotProduct(covariants1, covariants1);
            covariantTensor[0, 1] = utilitiez.Calculators.vectorDotProduct(covariants1, covariants2);
            covariantTensor[1, 0] = utilitiez.Calculators.vectorDotProduct(covariants2, covariants1);
            covariantTensor[1, 1] = utilitiez.Calculators.vectorDotProduct(covariants2, covariants2);

            contravariantTensor[0, 0] = utilitiez.Calculators.vectorDotProduct(contravariants1, contravariants1);
            contravariantTensor[1, 0] = utilitiez.Calculators.vectorDotProduct(contravariants1, contravariants2);
            contravariantTensor[0, 1] = utilitiez.Calculators.vectorDotProduct(contravariants2, contravariants1);
            contravariantTensor[1, 1] = utilitiez.Calculators.vectorDotProduct(contravariants2, contravariants2);
            utilitiez.matrixPrinter(covariantTensor);
            utilitiez.matrixPrinter(contravariantTensor);

            Jacobian = covariants1[0] * covariants2[1] - covariants1[1] * covariants2[0];
        }
    
    }
}