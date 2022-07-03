namespace AcademyHomework3.TaxiStation.Factories
{
    public class RandomTaxiUsualFactory : ITaxiFactory
    {
        public Taxi GenerateTaxi()
        {
            Random random = new Random();

            return new TaxiUsual(
                (int)random.NextInt64(10000,int.MaxValue),
                (int)random.NextInt64(5,15),
                (int)random.NextInt64(5000,50000),
                (int)random.NextInt64(90,120),
                (int)random.NextInt64(0,1)==0,
                (int)random.NextInt64(0, 1) == 0);
        }
    }
}
