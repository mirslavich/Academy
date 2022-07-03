namespace AcademyHomework3.TaxiStation
{
    public class TaxiUsual : Taxi
    {
        public bool SeatForChild { get; set; }
        public bool SeatForAnimal { get; set; }
        private int _numberOfPassengerSeats { get; set;}

        public override string  PrintInfo()
        {
            return "Usual taxi: " + base.PrintInfo()+ " Seat for child: " + SeatForChild + " Seat for animal: " + SeatForAnimal + 
                " Number of passenger seaats: " + _numberOfPassengerSeats;
        }

        public TaxiUsual(int id, int consumption, int cost, int speed,
            bool seatForChild=false, bool seatForAnimal=false,int numberOfPassengerSeaats=4) 
            : base(id, consumption, cost, speed)
        { 
            SeatForChild = seatForChild;
            SeatForAnimal = seatForAnimal;
            _numberOfPassengerSeats = numberOfPassengerSeaats;
        }

    }
}
