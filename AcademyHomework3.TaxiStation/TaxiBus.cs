namespace AcademyHomework3.TaxiStation
{
    public class TaxiBus: Taxi
    {
        private int _numberOfPassengerSeats { get; set; }

        public TaxiBus(int id, int consumption, int cost, int speed, int numberOfPassengerSeaats=16)
            : base(id, consumption, cost, speed)
        {
            _numberOfPassengerSeats = numberOfPassengerSeaats;
        }

        public override string PrintInfo()
        {
            return "Bus taxi:      " + base.PrintInfo() + " Number of passenger seaats: " + _numberOfPassengerSeats;
        }

        public override string GetSaveData()
        {
            return "TaxiBus " + base.GetSaveData() + " " + _numberOfPassengerSeats;
        }
    }
}
