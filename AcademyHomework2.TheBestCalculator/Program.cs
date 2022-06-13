namespace AcademyHomework2.TheBestCalculator
{

    internal class Program
    {

        static public void Main()
        {

            Console.WriteLine("Hello, I am calculator");
            string something;
            something= InputMathematicalExpression();


            string[] operationStack=  new string[something.Length];
            double[] numbersStack= new double[something.Length];
            string[] getStringArray = GetStringArray(something);


            //if (!CheckParentheses(getStringArray))
            //{
                IsResultCalculation(operationStack, numbersStack, getStringArray);
           // }
            



        }

        static string InputMathematicalExpression()
        
        {
            
           
            Console.WriteLine("Enter mathematical expression...");
            string something = Console.ReadLine();
            //string something = "8-7.40+892/35-(85+89*3/7-750+(431))-70/(2+(-4+(-17)+18/3-2))/15";
            return something;
        }

        static string[] GetStringArray(string something)
        {
            string[] getStringArray = new string[something.Length];
            var inNumber = false;
            var operandIndex = -1;
            var SizeArray = 0;
            for (int i = 0; i < something.Length; i++)
            {
                
                if (CheckIfIsSymbol(something[i]))
                {

                    if (!inNumber)
                    {
                        operandIndex++;
                        getStringArray[operandIndex] = Char.ToString(something[i]);
                        inNumber = true;
                    }
                    else
                    {
                        getStringArray[operandIndex] = getStringArray[operandIndex] + something[i];
                        SizeArray--;
                    }
                    SizeArray++;
                }
                else if (CheckIfIsOperation(something[i]))
                {
                    operandIndex++;
                    getStringArray[operandIndex] = Char.ToString(something[i]);
                    inNumber = false;
                    SizeArray++;
                }
                else
                {
                    Console.WriteLine("Input error symbol : " + something[i]);
                    inNumber = false;
                }
            }

            string[] secondArrayGet = new string[SizeArray];
            Array.Copy(getStringArray, secondArrayGet, secondArrayGet.Length);

           /* var y = 0;
            foreach (var item in secondArrayGet)
            {
                y++;
                Console.WriteLine($"[{y}]={item}");
            }
           */
            return secondArrayGet;



        }
        static bool CheckParentheses(char[] secondArrayGet)
        {
            var firstCounter = 0;
            var secondCounter = 0;
            bool parenthes = true;

            for (int i = 0; i < secondArrayGet.Length; i++)
            {
                if ((secondArrayGet[i] == '(' && secondArrayGet[i - 1] == ')') || (secondArrayGet[i] == ')' && secondArrayGet[i - 1] == '('))
                {
                    Console.WriteLine("Invalid parentheses");
                    parenthes = false;
                }
                if (secondArrayGet[i] == '(')
                {
                    firstCounter++;
                }
                else if (secondArrayGet[i] == ')')
                {
                    secondCounter++;
                }
            }
            if (firstCounter != secondCounter)
            {
                Console.WriteLine("You entered the wrong number of parentheses");
            }
            return firstCounter == secondCounter && parenthes;

        }

        static bool CheckIfIsSymbol(char symbol)
        {
            char[] arrayNumbers = { '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (symbol == arrayNumbers[i])
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckIfIsOperation(char symbol)
        {
            char[] arrayOperation = { '+', '-', '*', '/', '(', ')','^' };
            for (int i = 0; i < arrayOperation.Length; i++)
            {
                if (symbol == arrayOperation[i])
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckIfIsOperationString(string literal )
        {
            char c=literal.ToCharArray()[0];
            if (CheckIfIsOperation(c))
            {
                return true;
            }
            return false;
        }

        static int CheckPriorityOperation(string operation)
        {
            var result=0;
            char literal = operation.ToCharArray()[0];
            switch (literal)
            {
                case '+':
                case '-':
                    result = 1;
                    break;
                case '*':
                case '/':
                    result = 2;
                    break;
                case '^':
                    result = 3;
                    break;

            }
            return result;

        }

        static double IsResultOperation(string operation, double penultimateNumberStack,double lastNumberStack)

        {   double result=0;
            char literal = operation.ToCharArray()[0];

            switch (literal)
            {
                case '+':
                    result = penultimateNumberStack + lastNumberStack;
                    break;
                case '-':
                    result = penultimateNumberStack - lastNumberStack;
                    break;
                case '*':
                    result = penultimateNumberStack * lastNumberStack;
                    break;
                case '/':
                    result = penultimateNumberStack / lastNumberStack;
                    break;
                case '^':
                    result = Math.Pow(penultimateNumberStack, lastNumberStack);
                    break;

            }
            return result;

        }

        static void IsResultCalculation (string[] operationStack, double[] numbersStack,  string [] getStringArray)
        {
            var countNumber = 0;
            var countOperation = 0;
            var testNumber = false;

            for (int i = 0; i < getStringArray.Length; i++)
            {
                if (!CheckIfIsOperationString(getStringArray[i]))
                {
                    testNumber = double.TryParse(getStringArray[i], out numbersStack[countNumber]);
                    countNumber++;
                    if (!testNumber)
                    {
                        Console.WriteLine("You put more than one dot in the number");
                        return;
                    }
                }
                else if (CheckIfIsOperationString(getStringArray[i]))
                {
                    if (countOperation == 0 || CheckPriorityOperation(getStringArray[i]) > CheckPriorityOperation(operationStack[countOperation - 1]))
                    {
                        operationStack[countOperation] = getStringArray[i];
                        countOperation++;
                    }

                    else if (getStringArray[i].ToCharArray()[0] == ')')
                    {

                        while (operationStack[countOperation - 1].ToCharArray()[0] != '(')
                        {
                            countNumber--;
                            numbersStack[countNumber - 1] = IsResultOperation(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
                            countOperation--;
                        }
                        countOperation--;
                    }
                    else if (getStringArray[i].ToCharArray()[0] == '(')
                    {
                        if (getStringArray[i + 1].ToCharArray()[0] == '-' && getStringArray[i + 3].ToCharArray()[0] == ')')
                        {

                            numbersStack[countNumber] = -(double.Parse(getStringArray[i + 2]));
                            countNumber++;
                            i = i + 3;
                        }
                        else if (getStringArray[i + 1].ToCharArray()[0] == '+' && getStringArray[i + 3].ToCharArray()[0] == ')')
                        {
                            numbersStack[countNumber] = double.Parse(getStringArray[i + 2]);
                            countNumber++;
                            i = i + 3;
                        }
                        else if (getStringArray[i + 1].ToCharArray()[0] == '+' && getStringArray[i + 3].ToCharArray()[0] != ')')
                        {
                            operationStack[countOperation] = getStringArray[i];
                            numbersStack[countNumber] = double.Parse(getStringArray[i + 2]);
                            countOperation++;
                            countNumber++;
                            i = i + 2;

                        }
                        else if (getStringArray[i + 1].ToCharArray()[0] == '-' && getStringArray[i + 3].ToCharArray()[0] != ')')
                        {
                            operationStack[countOperation] = getStringArray[i];
                            numbersStack[countNumber] = -(double.Parse(getStringArray[i + 2]));
                            countOperation++;
                            countNumber++;
                            i = i + 2;
                        }
                        else
                        {
                            operationStack[countOperation] = getStringArray[i];
                            countOperation++;
                        }
                    }
                    else
                    {
                        countNumber--;
                        numbersStack[countNumber - 1] = IsResultOperation(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
                        countOperation--;
                        i--;
                    }
                }
                if (i == getStringArray.Length - 1)
                {
                    while (countOperation != 0)
                    {
                        countNumber--;
                        numbersStack[countNumber - 1] = IsResultOperation(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
                        countOperation--;
                    }
                }
            }
            Console.WriteLine($"Result:{numbersStack[0]}");
            Console.WriteLine("Press any key or 'Y' if you want to exit!");
            var testY = Console.ReadLine();
            if (testY == "Y" || testY == "y")
            {
                return;
            }
            else
            {
                Console.Clear();
               // InputMathematicalExpression(); Expression for recursii
            }

        }





    }
}

