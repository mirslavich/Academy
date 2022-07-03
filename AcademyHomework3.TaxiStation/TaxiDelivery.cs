namespace AcademyHomework3.TaxiStation
{
    public class TaxiDelivery
    {
       public double UsefulWeight { get; set; }
        public void PrintInfoAboutWeight()
        {
            Console.WriteLine($"Taxi is carrying {UsefulWeight}");
        }
    }
}
