using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem
{
   
    public class Port
    {
        public bool isActive { get; set; }
        public int PhoneNumber { get; set; }

        public void AssignNumber(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
