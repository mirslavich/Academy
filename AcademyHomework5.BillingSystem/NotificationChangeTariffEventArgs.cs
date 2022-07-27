namespace AcademyHomework5.BillingSystem
{
    public class NotificationChangeTariffEventArgs
    {
        public TariffPlans TariffPlans { get; }

        public NotificationChangeTariffEventArgs(TariffPlans tariffPlans)
        {
            TariffPlans = tariffPlans;
        }
    }
}