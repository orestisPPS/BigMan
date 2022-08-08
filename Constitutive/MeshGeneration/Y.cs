namespace Constitutive
{
    public class Y : Position
    {
        public string Type => "Y";
        public Y()
        {
            Value = -1d;
        }

        public Y(double value)
        {
            Value = value;
        }
    }
}