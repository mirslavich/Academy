namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiRandomFactory
    {
        public static ITaxiFactory GetRandomTaxiFactory()
        { 
            Random random = new Random();
            switch (random.Next(1,5))
            {
                case 1:
                    return new RandomTaxiUsualFactory();
                case 2:
                    return new RandomTaxiBusFactory();
                case 3:
                    return new RandomTaxiDelivery();
                case 4:
                    return new RandomTaxiHelicopter();
                default:
                    return null;
            }
        }
    }
}
