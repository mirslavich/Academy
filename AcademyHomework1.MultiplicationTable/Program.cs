namespace AcademyHomework1.MultiplicationTable
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
                int firstNumber = inputFirstNumber();
                int secondNumber = inputSecondNumber();
                Multiplication (firstNumber, secondNumber);

                Console.WriteLine("Do you want to continue Y/N");
                string testY = Console.ReadLine();
                isContinue = (bool)(testY == "Y" || testY == "y");

            } while (isContinue);

            static int inputSecondNumber()
            {
                bool Check = false;
                int secondNumber;

                do
                {
                    Console.WriteLine("Enter second number");

                    Check = int.TryParse(Console.ReadLine(), out secondNumber);
                    if (!Check)
                    {
                        Console.WriteLine("Your input is wrong");
                        continue;
                    }
                } while (!Check);
                return secondNumber;
            }

            static int inputFirstNumber()
            {
                bool Check = false;
                int firstNumber;

                do
                {
                    Console.WriteLine("Enter first number");

                    Check = int.TryParse(Console.ReadLine(), out firstNumber);
                    if (!Check)
                    {
                        Console.WriteLine("Your input is wrong");
                        continue;
                    }
                } while (!Check);
                return firstNumber;
            }

            static void Multiplication (int firstNumber,int secondNumber)
            {
                Console.WriteLine("Multiplication table");
                for (int i = 1; i <= secondNumber; i++)
                {
                    int result = firstNumber * i;
                    Console.WriteLine($"\t {firstNumber}*{i}={result}");
                }
            }
        }
    }
}