namespace AcademyHomework3.TaxiStation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int userChoice = 0;
            var taxiStation= new TaxiStation();
            do
            {   
                userChoice = ChoiceOption();
                ManageUserChoice(userChoice, taxiStation);

            } while (userChoice!=0);


            /*var taxiBus3 = new TaxiBus(124, 15.2, 10000, 100);
            var taxiBus1 = new TaxiBus(128, 11.2, 10100, 200);
            var taxiBus2= new TaxiBus(130, 9.2, 20100, 300);
            var taxiUsual1 = new TaxiUsual(533, 7.3, 15000,170);
            var ArrayTaxi = new Taxi[] { taxiBus1, taxiBus2, taxiBus3, taxiUsual1 };*/
            //double speedMin;
            // double speedMax;
            //var SpeedRange = new double[2];
            //var fullCost= CalculateCostCarPark(ArrayTaxi);
            // ManageTaxiStation(userChoice, ArrayTaxi);
            // SortTaxiByConsumption(ArrayTaxilist);

        }

        private static void ManageUserChoice(int userChoice, TaxiStation taxiStation)
        {
            switch (userChoice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    taxiStation.GenerateTaxi();
                    Console.WriteLine(taxiStation._previewTaxi.PrintInfo());
                    Console.WriteLine("You want to save it? Y/N");
                    var testY = Console.ReadLine();
                    if (testY == "Y" || testY == "y")
                    {
                        taxiStation.SavePreviewTaxi();
                        Console.WriteLine("You saved it!");
                    }
                    else
                    {
                        Console.WriteLine("You didn't save it!");
                    }
                    break;
                case 3:
                    PrintList("Taxi list", taxiStation.GetTaxiList());
                     break;
                case 4:
                    taxiStation.SortList();
                    PrintList("Taxi list sorted", taxiStation.GetTaxiList());
                    break;
                case 5:
                   //List<Taxi> taxi = taxiStation.GetTaxiBySpeed(0,150) ;
                    PrintList("Taxi with speed", taxiStation.GetTaxiBySpeed(0, 110));
                    break;

                default:
                    break;
            }
        }

        static void PrintList(string messege, List<Taxi> taxiList)
        {
            Console.WriteLine(messege);
            foreach (var item in taxiList)
            {
                Console.WriteLine(item.PrintInfo());
            }
        }
        static double CalculateCostCarPark(Taxi[] ArrayTaxi)
        {
            double fullCost= 0;
            foreach (var item in ArrayTaxi)
            {
                fullCost += item.Cost;
            }
            return fullCost;
        }

        static void ManageTaxiStation(int userChoice, Taxi[] ArrayTaxi)
        {
            

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine($"Full price is: {CalculateCostCarPark(ArrayTaxi)}");
                    break;
                case 2:
                    Console.WriteLine("\t >>>>>Sort by fuel consumption");
                   // SortTaxiByConsumption(ArrayTaxi);
                    break;
                case 3:
                    GetListOfCarsBySpeed(ArrayTaxi, InputSpeedRange());
                    break;
                default:
                    break;
            }
        }

        static int ChoiceOption()
        {   
            //Console.Clear();
            Console.WriteLine("\t >>>>> Welcome to Taxi station <<<<<\n");
            Console.WriteLine("My option:\n 0.Exit from Taxi station\n 1.Loading from file.\n 2.New taxi generation.\n" +
                " 3.Show park taxi list.\n 4.Sorting cars by consumption.\n 5.Find a car by speed range.\n 6.Calculate the cost of a car park.\n" +
                " \n Enter number from 0 to 6!"); 
            // Загрузка из файла //генерация //сохранение в список// показаь список // сортировка // фильтрция по скорости //общая стоимость
            bool isInput = int.TryParse(Console.ReadLine(), out int userChoice);
            if (!isInput || userChoice>6 || userChoice<0)
            {
                Console.WriteLine(">>>>Input is wrong");
                Console.ReadLine();
                ChoiceOption();
            }
            return userChoice;
        }

        static double[] InputSpeedRange()
        {
            var resultArray = new double[2];
            Console.WriteLine("Enter speed range! (Format min-max)\n ");
            var inputSpeedRange = Convert.ToString(Console.ReadLine());
            if (String.IsNullOrEmpty(inputSpeedRange))
            {
                Console.WriteLine(">>>>Input is null or empty");
                InputSpeedRange();
            }
            else
            { 
                var speedRange = inputSpeedRange.Split('-','-');
                if (speedRange.Length != 2)
                {
                    Console.WriteLine(">>>>Input format is wrong");
                    InputSpeedRange();
                }
                bool isInputMin = double.TryParse(speedRange[0], out resultArray[0]);
                bool isInputMax = double.TryParse(speedRange[1], out resultArray[1]);
                if (!(isInputMin&&isInputMax)&& resultArray[0] > resultArray[1])
                {
                    Console.WriteLine(">>>>Input format is wrong");
                    InputSpeedRange();
                }
            }
            return resultArray;
        }

        static void GetListOfCarsBySpeed(Taxi[] ArrayTaxi, double[] SpeedRangeArray)
        {
            foreach (var item in ArrayTaxi)
            {
                if (SpeedRangeArray[0]<=item.Speed && SpeedRangeArray[1] >= item.Speed)
                {
                    item.PrintInfo();
                }
            }
        }

        
        

    }
}