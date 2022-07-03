
namespace AcademyHomework3.TaxiStation
{
    internal class TaxiHelicopter : Taxi
    {
        private int _numberOfPassengerSeats { get; set; }
        public TaxiHelicopter(int id, int consumption, int cost, int speed, int numberOfPassengerSeaats=3) : base(id, consumption, cost, speed)
        {
            _numberOfPassengerSeats = numberOfPassengerSeaats;
        }

        public override string PrintInfo()
        {
            return "Taxi helicopter: " + base.PrintInfo() + " Number of passenger seats: " + _numberOfPassengerSeats;
        }
    }
}
