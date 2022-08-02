namespace Discretization
{
    public class TemplateX : Coordinate
    {
        public double Value {get; set;}
        public string Type {get; set;}
        public TemplateX()
        {
            this.Value = -1;
            this.Type = "TemplateX";
        }
    }
}