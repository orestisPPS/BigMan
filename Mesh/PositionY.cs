using Discretization;
namespace Mesh
{
    public class PositionY : DegreeOfFreedom
    {
        public PositionY()
        {
            this.Value = -1d;
            this.Type = "PositionY";
        }

    }
}