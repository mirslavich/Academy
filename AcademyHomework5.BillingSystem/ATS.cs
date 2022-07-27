using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem
{
    public class ATS
    {
        public List<Client> Clients= new List<Client>() ;
        public List<Call> CallsHistories = new List<Call>();

        public void AddNewClient(string firstName, string secondName, string adress,Tariff tariff)
        {
            
            var port = new Port();
            port.isActive = true;
            port.PhoneNumber= GetPhoneNumber();
            var phone = new Phone();
            phone.SomePhone=true;
            phone.ConnectPhoneToPort();
            var newClient =new Client(SingAnAgreemeet(),firstName, secondName, GenerateDateOfBirth(), adress,phone, port, tariff );
            Clients.Add(newClient);
            Clients.Last().NotifyCall += Clients.Last().Phone.ConnectionWithSomeone;
            Clients.Last().Phone.NotificationConnection += TryToConnect;
            Clients.Last().Phone.StatusPhoneToPort += StatusPhoneToPort;
        }

        public int GetPhoneNumber()
        {
            var newPhone = new Random().Next(4000000, 4999999);
            return newPhone;
        }
        private void StatusPhoneToPort(Phone sender, NotificationPhoneConnectionToPortEventArgs eventArgs)
        {
            // need more logical 
            

        }

        private DateTime GenerateDateOfBirth()
        {
            var dateOfBirth = new Random();
            int dateOfBirthYear = dateOfBirth.Next(1995, 2006);
            int dateOfBirthMonth = dateOfBirth.Next(1, 12);
            int dateOfBirthDay = dateOfBirth.Next(1, 31);
            DateTime generateDateOfBirth = new DateTime(dateOfBirthYear, dateOfBirthMonth, dateOfBirthDay);
            return generateDateOfBirth;

        }

        private Guid SingAnAgreemeet()
        {
            var areement = Guid.NewGuid();
            return areement;
        }

        public bool CheckClient(int number)
        {
            var isClient = Clients.Select(n=>n.Port.PhoneNumber).Contains(number);
            return isClient;
        }

        public void TryToConnect(Client sender, NotificationCallEventArgs callEventArgs)
        {
            if (CheckClient(callEventArgs.SomePhoneNumber))
            {
                
                var endCall= callEventArgs.DateTimeNow.AddSeconds(new Random().Next(1, 3600));
                CallsHistories.Add(new Call(sender,callEventArgs.DateTimeNow,endCall,callEventArgs.SomePhoneNumber));
            }
            else
            {
                Console.WriteLine($"Number {callEventArgs.SomePhoneNumber} is not in service ");
            }
        }

        public void ChangeTariffForClient(Client client, Tariff newTariff)
        { 
            
        }


       





    }
}
