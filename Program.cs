using DifferentialEquations;
using Meshing;
using Discretization;
using Constitutive;
using BoundaryConditions;
using DifferentialEquationSolutionMethods;
using MathematicalProblems;
using Simulations;
using utility;
internal class Program
{
    private static void Main(string[] args)
    {
        Mesh Mesh = new Mesh(new MeshSpecs2D(5, 5, 1, 1, 0, 0, 0));
    }
}