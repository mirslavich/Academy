using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework3.TaxiStation.Factories
{
    internal class RandomTaxiUsualFactory : ITaxiFactory
    {
        public Taxi GenerateTaxi()
        {
            Random random = new Random();

            return new TaxiUsual(
                (int)random.NextInt64(10000,int.MaxValue),
                random.NextInt64(5,15),
                random.NextInt64(5000,50000),
                random.NextInt64(90,120),
                random.NextInt64(0,1)==0,
                random.NextInt64(0, 1) == 0
                );
        }
    }
}
