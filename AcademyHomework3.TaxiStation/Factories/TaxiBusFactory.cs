namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiBusFactory: ITaxiFactory
    {
        private readonly int _id;
        private readonly int _consumption;
        private readonly int _cost;
        private readonly int _speed;
        private readonly int _numberOfPassengerSeaats;

        public TaxiBusFactory(int id, int consumption, int cost, int speed, bool seatForChild, bool seatForAnimal, int numberOfPassengerSeaats = 16)
        {
            _id = id;
            _consumption = consumption;
            _cost = cost;
            _speed = speed;
            _numberOfPassengerSeaats = numberOfPassengerSeaats;
        }

        public Taxi GenerateTaxi()
        {
            return new TaxiBus(_id, _consumption, _cost, _speed, _numberOfPassengerSeaats);
        }
    }
}
