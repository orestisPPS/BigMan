namespace Discretization
{
    public class TemplateY : Coordinate
    {
        public TemplateY()
        {
            this.Type = "TemplateX";
        }

        public TemplateY(double value)
        {
            this.Value = value;
            this.Type = "TemplateX";
        }
    }
}