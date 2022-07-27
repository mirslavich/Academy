namespace AcademyHomework5.BillingSystem
{
    public class NotificationPhoneConnectionToPortEventArgs
    {
        public bool PhoneConnectionToPort { get;}

        public NotificationPhoneConnectionToPortEventArgs(bool phoneConnectionToPort)
        {
            PhoneConnectionToPort = phoneConnectionToPort;
        }
    }
}