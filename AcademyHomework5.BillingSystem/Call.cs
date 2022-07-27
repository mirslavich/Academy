namespace AcademyHomework5.BillingSystem
{
    public class Call
    {
        public Client FromClient { get;}
        public Client ToClient { get; }  // need more logical with  toClient
        public DateTime StartDateTime { get;}
        public DateTime EndDateTime { get;}
        public int ToPhoneNumber { get;}

        public Call(Client fromClient, DateTime startDateTime,DateTime endDateTime, int toPhoneNumber)
        {
            FromClient = fromClient;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ToPhoneNumber = toPhoneNumber;
        }
    }
}