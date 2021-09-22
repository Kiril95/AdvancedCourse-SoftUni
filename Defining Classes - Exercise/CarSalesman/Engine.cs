using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, string power, string displacement = "n/a", string efficiency = "n/a")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:")
             .AppendLine($"    Power: {this.Power}")
             .AppendLine($"    Displacement: {Displacement}")
             .Append($"    Efficiency: {Efficiency}");
            return sb.ToString();
        }
    }
}
