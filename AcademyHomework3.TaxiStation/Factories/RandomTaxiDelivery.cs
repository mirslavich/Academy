namespace AcademyHomework3.TaxiStation.Factories
{
    public class RandomTaxiDelivery : ITaxiFactory
    {
        public Taxi GenerateTaxi()
        {
            Random random = new Random();
            return new TaxiDelivery(
                (int)random.NextInt64(10000, int.MaxValue),
                (int)random.NextInt64(16, 25),
                (int)random.NextInt64(50000, 150000),
                (int)random.NextInt64(90, 120),
                (int)random.NextInt64(1,100));
        }
    }
}
