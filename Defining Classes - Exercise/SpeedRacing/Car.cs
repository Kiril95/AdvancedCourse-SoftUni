using System;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance = 0)
        {
            Model = model;
            FuelAmount = fuelAmount;
            TravelledDistance = travelledDistance;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public void Drive(double amountOfKm)
        {
            double travel = amountOfKm * FuelConsumptionPerKilometer;

            if (FuelAmount - travel >= 0)
            {
                FuelAmount -= travel;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }

    }
}
