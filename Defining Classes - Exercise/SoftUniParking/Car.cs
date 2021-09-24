using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine($"Make: {Make}")
                .AppendLine($"Model: {Model}")
                .AppendLine($"HorsePower: {HorsePower}")
                .AppendLine($"RegistrationNumber: {RegistrationNumber}");

            return builder.ToString().Trim();
        }

    }
}
