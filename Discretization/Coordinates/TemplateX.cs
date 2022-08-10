namespace Discretization
{
    public class TemplateX : Coordinate
    {
        public TemplateX()
        {
            this.Type = "TemplateX";
        }

        public TemplateX(double value)
        {
            this.Value = value;
            this.Type = "TemplateX";
        }
    }
}