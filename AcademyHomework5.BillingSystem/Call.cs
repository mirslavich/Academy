namespace AcademyHomework5.BillingSystem
{
    public class Call
    {
        public Client FromClient { get;} 
        public DateTime StartDateTime { get;}
        public DateTime EndDateTime { get;}
        public int ToPhoneNumber { get;}
        public double CostOfCall { get;}

        public Call(Client fromClient, DateTime startDateTime,DateTime endDateTime, int toPhoneNumber, double addSecond)
        {
            FromClient = fromClient;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ToPhoneNumber = toPhoneNumber;
            CostOfCall = fromClient.Tariff.PriceOfSecond*addSecond;
        }
    }
}