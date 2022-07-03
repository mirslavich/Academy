using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework3.TaxiStation.Factories
{
    public interface ITaxiFactory
    {
        public Taxi GenerateTaxi();

    }
}
