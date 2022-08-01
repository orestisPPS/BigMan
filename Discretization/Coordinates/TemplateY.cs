namespace Discretization
{
    public class TemplateY : ICoordinate
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