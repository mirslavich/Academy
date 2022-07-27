namespace AcademyHomework5.BillingSystem
{
    public class NotificationCallEventArgs
    {
        public int SomePhoneNumber { get; }
        public DateTime DateTimeNow { get; }

        public NotificationCallEventArgs(int somePhoneNumber)
        {
            SomePhoneNumber = somePhoneNumber;
            DateTimeNow = DateTime.Now;
        }
    }
}