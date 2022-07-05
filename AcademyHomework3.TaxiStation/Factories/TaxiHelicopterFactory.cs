namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiHelicopterFactory : ITaxiFactory
    {
        private readonly int _id;
        private readonly int _consumption;
        private readonly int _cost;
        private readonly int _speed;
        private readonly int _numberOfPassengerSeaats;

        public TaxiHelicopterFactory(int id, int consumption, int cost, int speed, bool seatForChild, bool seatForAnimal, int numberOfPassengerSeaats = 3)
        {
            _id = id;
            _consumption = consumption;
            _cost = cost;
            _speed = speed;
            _numberOfPassengerSeaats = numberOfPassengerSeaats;
        }

        public TaxiHelicopterFactory(string[] arguments)
        {
            _id = int.Parse(arguments[0]);
            _consumption = int.Parse(arguments[1]);
            _cost = int.Parse(arguments[2]);
            _speed = int.Parse(arguments[3]);
            _numberOfPassengerSeaats = int.Parse(arguments[4]);
        }

        public Taxi GenerateTaxi()
        {
            return new TaxiHelicopter(_id, _consumption, _cost, _speed, _numberOfPassengerSeaats);
        }
    }
}
