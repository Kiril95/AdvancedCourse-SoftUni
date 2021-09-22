using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public Car()
        {

        }
        public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:")
              .AppendLine($"  {this.Engine}")
              .AppendLine($"  Weight: {Weight}")
              .Append($"  Color: {Color}");
            return sb.ToString();
        }
    }
}
