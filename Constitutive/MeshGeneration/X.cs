namespace Constitutive
{
    public class X : Position
    {
        public string Type => "X";
        public X()
        {
            Value = -1d;
        }

        public X(double value)
        {
            Value = value;
        }
    }
}