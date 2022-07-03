using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiBusFactory: ITaxiFactory
    {
        private readonly int _id;
        private readonly double _consumption;
        private readonly double _cost;
        private readonly double _speed;
        private readonly int _numberOfPassengerSeaats;


        public TaxiBusFactory(int id, double consumption, double cost, double speed, bool seatForChild, bool seatForAnimal, int numberOfPassengerSeaats = 16)
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
