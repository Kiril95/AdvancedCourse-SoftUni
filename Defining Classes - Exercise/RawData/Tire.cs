namespace RawData
{
    public class Tire
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
