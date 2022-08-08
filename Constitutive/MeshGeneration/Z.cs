namespace Constitutive
{
    public class Z : Position
    {
        public string Type => "Z";
        public Z()
        {
            Value = -1d;
        }

        public Z(double value)
        {
            Value = value;
        }
    }
}