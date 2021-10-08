using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine($"Make: {Make}")
                .AppendLine($"Model: {Model}")
                .AppendLine($"License Plate: {LicensePlate}")
                .AppendLine($"Horse Power: {HorsePower}")
                .AppendLine($"Weight: {Weight}");

            return builder.ToString().TrimEnd();
        }
    }
}
