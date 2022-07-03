using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework3.TaxiStation.Factories
{
    public class TaxiRandomFactory
    {
        public TaxiRandomFactory()
        {

        }

        public static ITaxiFactory GetRandomTaxiFactory()
        { 
            Random random = new Random();
            switch (random.Next(1,3))
            {
                case 1:
                    return new RandomTaxiUsualFactory();
                case 2:
                    return new RandomTaxiBusFactory();
                default:
                    return null;

            }
        }
    }
}
