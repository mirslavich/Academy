namespace AcademyHomework1.Days
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = false;
            do
            {
                Console.Clear();
                var isNumberDay = SelectNumber();
                CheckOfTheDay(isNumberDay);
                                             
                Console.WriteLine("Do you want to continue Y/N");
                string testY = Console.ReadLine();
                isContinue = (bool)(testY == "y" || testY == "Y");

            } 
            while (isContinue);
        }

        static int SelectNumber()
        {
            Console.WriteLine("Hello, enter the number of day from 1 to 7");
            int resultInput = 0;
            var isOperation = int.TryParse(Console.ReadLine(), out resultInput);

            if (resultInput <= 7 && resultInput >= 1)
            {
                return resultInput;
            }
            else if (!isOperation)
            {
                return 8;
            }
            return 0;
        }

        static void CheckOfTheDay(int isNumberDay)
        {
            switch (isNumberDay)
            {
                case 1:
                    Console.WriteLine($"Your input {isNumberDay} it is Sunday");
                    break;
                case 2:
                    Console.WriteLine($"Your input {isNumberDay} it is Monday");
                    break;
                case 3:
                    Console.WriteLine($"Your input {isNumberDay} it is Tuesday");
                    break;
                case 4:
                    Console.WriteLine($"Your input {isNumberDay} it is Wednesday");
                    break;
                case 5:
                    Console.WriteLine($"Your input {isNumberDay} it is Thursday");
                    break;
                case 6:
                    Console.WriteLine($"Your input {isNumberDay} it is Friday");
                    break;
                case 7:
                    Console.WriteLine($"Your input {isNumberDay} it is Saturday");
                    break;
                case 8:
                    Console.WriteLine($"You didn't enter a number");
                    break;

                default:
                    Console.WriteLine($"Your input is not correct.You need to enter the number of day from 1 to 7!");
                    break;
            }
        }
    }
}
