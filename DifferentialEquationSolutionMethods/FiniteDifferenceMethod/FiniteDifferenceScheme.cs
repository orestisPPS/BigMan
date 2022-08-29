using DifferentialEquations;
using Discretization;


namespace DifferentialEquationSolutionMethods
{
    public abstract class FiniteDifferenceScheme
    {
        public virtual DifferentialEquation Equation { get; }

        public virtual Node[,] Nodes { get; }
        public virtual double[,] Matrix {get; internal set;}
        public virtual double[] Vector {get; internal set;}

        public void CreateLinearSystem()
        {
            Parallel.Invoke(
                () => CreateMatrix(),
                () => CreateVector()
            );
        }
        public virtual void CreateMatrix()
        {
            
        }

        public virtual void CreateVector()
        {
            
        }
    }
}