namespace AcademyHomework2.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  + - * / ^ F
            
            Console.WriteLine("Hello, I am calculator");
            GeneralFunction();
            
        }

        static void GeneralFunction()
        {   
            Console.WriteLine("Please enter operation '+' '-' '*' '/' '^' 'F'");

            switch (Console.ReadLine ())
            {
                case "+":
                    AdditionNumbers(GetFirstNumbers(), GetSecondNumbers());
                    break;
                case "-":
                    SubtractionNumbers(GetFirstNumbers(), GetSecondNumbers());
                    break;
                case "*":
                    MultiplicationNumbers(GetFirstNumbers(), GetSecondNumbers());
                    break;
                case "/":
                    {
                        var firstNumber = GetFirstNumbers();
                        var secondNumber = GetSecondNumbers();
                        if (secondNumber == 0)
                        {
                            Console.WriteLine("This is a rhetorical question!");
                        }
                        else
                        {
                            DivideNumbers(firstNumber, secondNumber);
                        }
                    }
                    break;
                case "^":
                    {   var firstNumber=GetFirstNumbers();
                        var secondNumber= GetSecondNumbers();
                        var result = Math.Pow(firstNumber, secondNumber);
                        Console.WriteLine($"Result: \nResult: {firstNumber}^{secondNumber}={result}");
                    }
                    break;
                case "F":
                case "f":
                    {
                        var someNumber = GetFirstNumbers();
                        if (someNumber % 1 == 0 && someNumber >= 0 && someNumber <= 65)
                        {
                            ulong someNumberInt = (ulong)someNumber;
                            var result = FactorialNumbers(someNumberInt);
                            Console.WriteLine($"Result: {someNumberInt}!={result}");
                        }
                        else
                        {
                            Console.WriteLine("Factorial can only be a positive integer no greater than 65!");
                        }
                    }
                    break;
                
                default:
                    Console.WriteLine("Your input is wrong!");
                    GeneralFunction();
                    break;
            }
            Console.WriteLine("Press any key or 'Y' if you want to exit!");
            var testY = Console.ReadLine();
            if (testY == "Y" || testY == "y")
            {
                return;
            }
            else
            {
                Console.Clear();
                GeneralFunction();
            }
        }
        static double GetFirstNumbers()
        {
            double firstNumber;
            bool check;
            do
            {
                Console.WriteLine("Enter first a number");
                check = double.TryParse(Console.ReadLine(), out firstNumber);
                if (!check)
                {
                    Console.WriteLine("Your input is wrong");
                }
            }
            while (!check);
            return firstNumber;
        }
        static double GetSecondNumbers()
        {
            double secondNumber;
            bool check;
            do
            {
                Console.WriteLine("Enter second a number");
                check = double.TryParse(Console.ReadLine(), out secondNumber);
                if (!check)
                {
                    Console.WriteLine("Your input is wrong");
                }

            }
            while (!check);
            return secondNumber;
        }
        static void AdditionNumbers(double firstNumbers, double secondNumbers) //+
        {
            var result = firstNumbers + secondNumbers;
            Console.WriteLine($"\nResult: {firstNumbers}+{secondNumbers}={result}");  
        }
        static void SubtractionNumbers(double firstNumbers, double secondNumbers) //-
        {
            var result = firstNumbers - secondNumbers;
            Console.WriteLine($"\nResult: {firstNumbers}-{secondNumbers}={result}");
        }
        static void MultiplicationNumbers(double firstNumbers, double secondNumbers) //*
        {
            var result = firstNumbers * secondNumbers;
            Console.WriteLine($"\nResult: {firstNumbers}*{secondNumbers}={result}");
        }
        static void DivideNumbers(double firstNumbers, double secondNumbers) // /
        {
            var result = firstNumbers / secondNumbers;
            Console.WriteLine($"\nResult: {firstNumbers}/{secondNumbers}={result}");
        }
        
        static ulong FactorialNumbers(ulong  someNumbers) // n!
        {
            ulong result=1;
            for (ulong i = 2; i <= someNumbers; i++)
            {
               result = result * i;
            }
            return result;
        }

        

        

        



    }
}

        
    