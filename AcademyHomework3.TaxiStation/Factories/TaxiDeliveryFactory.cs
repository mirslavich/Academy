namespace AcademyHomework3.TaxiStation.Factories
{
    internal class TaxiDeliveryFactory:ITaxiFactory
    {
        private readonly int _id;
        private readonly int _consumption;
        private readonly int _cost;
        private readonly int _speed;
        private readonly int _usefulWeight;

        public TaxiDeliveryFactory(int id, int consumption, int cost, int speed, bool seatForChild, bool seatForAnimal, int usefulWeight )
        {
            _id = id;
            _consumption = consumption;
            _cost = cost;
            _speed = speed;
            _usefulWeight = usefulWeight;
        }
        public TaxiDeliveryFactory(string[] arguments)
        {
            _id = int.Parse(arguments[0]);
            _consumption = int.Parse(arguments[1]);
            _cost = int.Parse(arguments[2]);
            _speed = int.Parse(arguments[3]);
            _usefulWeight=int.Parse(arguments[4]);
        }

        public Taxi GenerateTaxi()
        {
            return new TaxiDelivery(_id, _consumption, _cost, _speed, _usefulWeight);
        }
    }
}
