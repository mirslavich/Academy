﻿namespace AcademyHomework3.TaxiStation
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
                        Console.WriteLine("<<<<Saved");
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
                    var rangeSpeed = new double[2];
                    rangeSpeed= InputSpeedRange();
                    PrintList("Taxi with speed", taxiStation.GetTaxiBySpeed(rangeSpeed[0], rangeSpeed[1]));
                    break;
                case 6:
                    Console.WriteLine(taxiStation.CalculateCostCarPark());
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

        static int ChoiceOption()
        {   
            Console.Clear();
            Console.WriteLine("\t >>>>> Welcome to Taxi station <<<<<\n");
            Console.WriteLine("My option:\n 0.Exit from Taxi station\n 1.Loading from file.\n 2.New taxi generation.\n 3.Show park taxi list.\n" +
            " 4.Sorting cars by consumption.\n 5.Find a car by speed range.\n 6.Calculate the cost of a car park.\n\n Enter number from 0 to 6!"); 
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