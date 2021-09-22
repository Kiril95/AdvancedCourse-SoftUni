using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public List<Tire> Tire { get; set; }

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tire)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tire = tire;
        }
        public override string ToString()
        {
            return Model;
        }
    }
}
