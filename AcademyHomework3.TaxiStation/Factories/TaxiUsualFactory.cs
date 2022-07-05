namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiUsualFactory : ITaxiFactory
    {
        private readonly int _id;
        private readonly int _consumption;
        private readonly int _cost;
        private readonly int _speed;
        private readonly bool _seatForChild;
        private readonly bool _seatForAnimal;
        private readonly int _numberOfPassengerSeaats;
        
        public TaxiUsualFactory(int id, int consumption, int cost, int speed, bool seatForChild, bool seatForAnimal, int numberOfPassengerSeaats=4)
        {
            _id = id;
            _consumption = consumption;
            _cost = cost;
            _speed = speed;
            _seatForChild = seatForChild;
            _seatForAnimal = seatForAnimal;
            _numberOfPassengerSeaats = numberOfPassengerSeaats;
        }

        public TaxiUsualFactory(string[] arguments)
        {
            _id = int.Parse(arguments[0]); 
            _consumption = int.Parse(arguments[1]);
            _cost = int.Parse(arguments[2]);
            _speed = int.Parse(arguments[3]);
            _seatForChild = bool.Parse(arguments[4]);
            _seatForAnimal = bool.Parse(arguments[5]);
            _numberOfPassengerSeaats = int.Parse(arguments[6]);
        }


        public Taxi GenerateTaxi()
        {
            return new TaxiUsual(_id, _consumption, _cost, _speed, _seatForChild, _seatForAnimal, _numberOfPassengerSeaats);
        }
    }
}
