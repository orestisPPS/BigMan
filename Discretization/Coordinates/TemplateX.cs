namespace Discretization
{
    public class TemplateX : IDirectionOne
    {
        public CoordinateType Type => CoordinateType.TemplateX;
        public double Value { get; set; }
        public TemplateX()
        {

        }

        public TemplateX(double value)
        {
            this.Value = value;
        }
    }
}
