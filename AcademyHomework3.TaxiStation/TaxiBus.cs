﻿namespace AcademyHomework3.TaxiStation
{
    public class TaxiBus: Taxi
    {
        public int NumberOfPassengerSeaats { get; set; }
        public TaxiBus(int id, double consumption, double cost, double speed, int numberOfPassengerSeaats=16)
            : base(id, consumption, cost, speed)
        {
            NumberOfPassengerSeaats = numberOfPassengerSeaats;
        }

        public override string PrintInfo()
        {
            return "Bus taxi: " + base.PrintInfo() + " Number of passenger seaats: " + NumberOfPassengerSeaats;
        }
    }
}
