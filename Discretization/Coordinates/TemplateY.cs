namespace Discretization
{
    public class TemplateY : IDirectionOne
    {
        public CoordinateType Type => CoordinateType.TemplateY;
        public double Value { get; set; }
        public TemplateY()
        {

        }

        public TemplateY(double value)
        {
            this.Value = value;
        }
    }
}
