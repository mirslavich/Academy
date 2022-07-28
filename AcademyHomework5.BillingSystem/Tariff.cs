using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem
{
    public class Tariff
    {
        public TariffPlans TariffPlans { get; set; }
        public double PriceOfSecond { get; set; }
        public DateTime DateOfConnection { get; set; }

        public Tariff(TariffPlans tariffPlans)
        {
            TariffPlans = tariffPlans;
            DateOfConnection = DateTime.Now;
            CalculatePriceForTariff();
        }

        private void CalculatePriceForTariff()
        {
            switch (TariffPlans)
            {
                case TariffPlans.Unlimited:
                    PriceOfSecond = 0.001;
                    break;
                case TariffPlans.Business:
                    PriceOfSecond = 0.003;
                    break;
                case TariffPlans.Common:
                    PriceOfSecond = 0.007;
                    break;
                case TariffPlans.Social:
                    PriceOfSecond = 0.006;
                    break;
                default:
                    Console.WriteLine($"There is no tariff plan");
                    break;
            }
        }
    }
}
