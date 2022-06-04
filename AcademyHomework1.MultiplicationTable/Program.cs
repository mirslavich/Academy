﻿namespace AcademyHomework1.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Hello, I am multiplication table");
                Console.WriteLine("Enter first number");
                int firstNumber = inputNumber();
                Console.WriteLine("Enter second number");
                int secondNumber = inputNumber();
                Multiplication (firstNumber, secondNumber);

                Console.WriteLine("\n Do you want to continue Y/N");
                string testY = Console.ReadLine();
                isContinue = (bool)(testY == "Y" || testY == "y");

            } while (isContinue);
            
            static int inputNumber()
            {
                bool Check = false;
                int firstNumber;

                do
                {
                    Check = int.TryParse(Console.ReadLine(), out firstNumber);
                    if (!Check)
                    {
                        Console.WriteLine("Your input is wrong");
                    }
                }
                while (!Check);
                return firstNumber;
            }
            static void Multiplication (int firstNumber,int secondNumber)
            {
                Console.WriteLine("\n Multiplication table");
                for (int i = 1; i <= secondNumber; i++)
                {
                    int result = firstNumber * i;
                    Console.WriteLine($"\t {firstNumber}*{i}={result}");
                }
            }
        }
    }
}