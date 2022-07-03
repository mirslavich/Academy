namespace AcademyHomework3.TaxiStation
{
    public class TaxiUsual : Taxi
    {
        //public TaxiClass TaxiClass { get; set; }
        public bool SeatForChild { get; set; }
        public bool SeatForAnimal { get; set; }
        private int _numberOfPassengerSeaats { get; set;}

        public override string  PrintInfo()
        {
            return "Usual taxi: " + base.PrintInfo()+ " Seat for child: " + SeatForChild + " Seat for animal: " + SeatForAnimal + 
                " Number of passenger seaats: " + _numberOfPassengerSeaats;
        }

        public TaxiUsual(int id, double consumption, double cost, double speed,
            bool seatForChild=false, bool seatForAnimal=false,int numberOfPassengerSeaats=4) 
            : base(id, consumption, cost, speed)
        { 
            SeatForChild = seatForChild;
            SeatForAnimal = seatForAnimal;
            _numberOfPassengerSeaats = numberOfPassengerSeaats;
        }

    }
}
