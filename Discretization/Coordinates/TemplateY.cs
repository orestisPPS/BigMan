namespace Discretization
{
    public class TemplateY : Coordinate
    {
        public double Value {get; set;}
        public string Type {get; set;}
        public TemplateY()
        {
            this.Value = -1;
            this.Type = "TemplateX";
        }
    }
}