namespace AcademyHomework5.BillingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var isATS= new ATS();
            isATS.AddNewClient("Mike", "Tellor", "Los-Angeles 78",new Tariff(TariffPlans.Business));
            isATS.AddNewClient("Nilola", "Musk", "Los-Angeles 122", new Tariff(TariffPlans.Common));
            isATS.AddNewClient("Timber", "Coker", "Los-Angeles 118", new Tariff(TariffPlans.Social));

            var userChoice = 0;
            do
            {
                userChoice=ShowSelectionMenu();
                HandlingUserInput(userChoice, isATS);

            } while (userChoice!=0);
            





        }
        static void HandlingUserInput(int someInput, ATS isATS)
        {
            switch (someInput)
            {
                 case 1:
                    Console.WriteLine(">>>>>>List of phone numbers");
                    foreach (var client in isATS.Clients)
                    {
                        Console.WriteLine($"Name: {client.FirstName} Number: {client.Port.PhoneNumber}");
                    }
                    break;
                case 2:
                    var iAmClient= GetСlient(isATS);
                    Console.WriteLine("Enter the phone number to call the client");
                    iAmClient.Call(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    foreach (var item in isATS.CallsHistories)
                    {
                        Console.WriteLine($"Name: {item.FromClient.FirstName} Called the number: { item.ToPhoneNumber} {item.StartDateTime}");
                    }
                    break;
                case 4:
                    iAmClient = GetСlient(isATS);

                    break;
                default:
                    break;
            }
        }

        static int ShowSelectionMenu()
        {
            Console.WriteLine(">>>>>>Welcome");
            Console.WriteLine("[0]-Exit\n[1]-List phone numbers \n[2]-Call to someone \n[3]-Show histories calls\n[4]-Change tariff plan");
            bool isInput = int.TryParse(Console.ReadLine(), out int userChoice);
            if (!isInput || userChoice > 5 || userChoice < 0)
            {
                Console.WriteLine(">>>>Input is wrong");
                Console.ReadLine();
                ShowSelectionMenu();
            }
            return userChoice;
        }

        static Client GetСlient( ATS isATS)
        {
            Console.WriteLine("Please select the client you are ");
            Console.WriteLine($"[1] -{isATS.Clients[0].FirstName}\n[2] -{ isATS.Clients[1].FirstName}\n[3] -{isATS.Clients[2].FirstName}\n");
            bool isInput = int.TryParse(Console.ReadLine(), out int userChoice);
            if (!isInput || userChoice > 4 || userChoice < 0)
            {
                Console.WriteLine(">>>>Input is wrong");
                Console.ReadLine();
                ShowSelectionMenu();
            }
            var iAmClient = isATS.Clients[userChoice - 1];
            return iAmClient;
        }
    }
}