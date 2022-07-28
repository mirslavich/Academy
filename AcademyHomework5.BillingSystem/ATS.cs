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
        public List<double> PaymentOnceMonth = new List<double>() ;
        private const string _path = "@historyOfCalls.txt";

        public void AddNewClient(string firstName, string secondName, string adress,Tariff tariff)
        {
            var port = new Port();
            port.isActive = true;
            port.PhoneNumber= GetPhoneNumber();
            var phone = new Phone();
            phone.SomePhone=true;
            phone.PhoneConnectionToPort=true;
            var newClient =new Client(SingAnAgreemeet(),firstName, secondName, GenerateDateOfBirth(), adress,phone, port, tariff );
            Clients.Add(newClient);
            Clients.Last().NotifyCall += Clients.Last().Phone.ConnectionWithSomeone;
            Clients.Last().Phone.NotificationConnection += ConnectClientToClient;
            Clients.Last().Phone.StatusPhoneToPort += StatusPhoneToPort;
            Clients.Last().NotifyChangeTariff += ChangeTariffForClient;
        }

        public int GetPhoneNumber()
        {
            var newPhone = new Random().Next(4000000, 4999999);
            return newPhone;
        }

        private void StatusPhoneToPort(Client sender, NotificationPhoneConnectionToPortEventArgs eventArgs)
        {
            Clients.Find(c => c.Agreement == sender.Agreement).Phone.PhoneConnectionToPort = eventArgs.PhoneConnectionToPort;
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

        public void ConnectClientToClient(Client sender, NotificationCallEventArgs callEventArgs)
        {
            if (CheckClient(callEventArgs.SomePhoneNumber))
            {
                var addSecond = new Random().Next(2, 3600);
                var endCall= callEventArgs.DateTimeNow.AddSeconds(addSecond);
                CallsHistories.Add(new Call(sender,callEventArgs.DateTimeNow,endCall,callEventArgs.SomePhoneNumber, addSecond));
                sender.Wallet -= CallsHistories.Last().CostOfCall;
            }
            else
            {
                Console.WriteLine($"Number {callEventArgs.SomePhoneNumber} is not in service ");
            }
        }

        public void ChangeTariffForClient(Client sender, NotificationChangeTariffEventArgs newTariffEventArgs)
        {
            if ((sender.Tariff.DateOfConnection.Day - DateTime.Now.Day) > 30)
            {
                Clients.Find(c => c.Agreement == sender.Agreement).Tariff = new Tariff(newTariffEventArgs.TariffPlans);
            }
            else
            {
                Console.WriteLine("You can change the tariff only once a month!");
            }
         }

        public void SaveHistoryCalls()
        {
            var fileForSave = new FileHandler();
            fileForSave.WriteHistoriesCallsToFileAsync(_path, CallsHistories);
        }
    }
}
