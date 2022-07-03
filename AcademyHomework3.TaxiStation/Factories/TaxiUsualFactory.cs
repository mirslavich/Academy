using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiUsualFactory : ITaxiFactory
    {
        private readonly int _id;
        private readonly double _consumption;
        private readonly double _cost;

        private readonly double _speed;
        private readonly bool _seatForChild;
        private readonly bool _seatForAnimal;
        private readonly int _numberOfPassengerSeaats;

        
        public TaxiUsualFactory(int id, double consumption, double cost, double speed, bool seatForChild, bool seatForAnimal, int numberOfPassengerSeaats=4)
        {
            _id = id;
            _consumption = consumption;
            _cost = cost;
            _speed = speed;
            _seatForChild = seatForChild;
            _seatForAnimal = seatForAnimal;
            _numberOfPassengerSeaats = numberOfPassengerSeaats;
        }

        public Taxi GenerateTaxi()
        {
            return new TaxiUsual(_id, _consumption, _cost, _speed, _seatForChild, _seatForAnimal, _numberOfPassengerSeaats);
        }

        
    }
}
