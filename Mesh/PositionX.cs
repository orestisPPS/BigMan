using Discretization;
namespace Mesh
{
    public class PositionX : DegreeOfFreedom
    {
        public PositionX()
        {
            this.Value = -1d;
            this.Type = "PositionX";
        }

    }
}