using System.Collections.Generic;
namespace AcademyHomework3.TaxiStation.Factories
{
    public class RandomTaxiBusFactory:ITaxiFactory
    {
        public Taxi GenerateTaxi()
        {
            Random random = new Random();
            return new TaxiBus(
                (int)random.NextInt64(10000, int.MaxValue),
                random.NextInt64(16, 25),
                random.NextInt64(50000, 150000),
                random.NextInt64(90, 120));
        }
    }
}
