namespace AcademyHomework2.TheBestCalculator
{

    internal class Program
    {

        static public void Main()
        {
            Console.WriteLine("Hello, I am calculator. I can '+', '-', '/', '*', '^'");
            IsGeneralFunction();
            Console.WriteLine("\t See you later!");
        }

        static string InputMathematicalExpression()
        {
            Console.WriteLine("Enter mathematical expression...");
            var inputExpression = Console.ReadLine();
            if (string.IsNullOrEmpty(inputExpression))
            {
                Console.WriteLine("Line is empty,please enter mathematical expression");
                return InputMathematicalExpression();
            }
            return inputExpression;
        }
        
        static void IsGeneralFunction()
        {
           
            var inputExpression = InputMathematicalExpression();
            CheckInputErrors(inputExpression);
            string[] operationStack = new string[inputExpression.Length];
            double[] numbersStack = new double[inputExpression.Length];
            string[] getStringArray = GetStringArray(inputExpression);
            IsResultExpression(operationStack, numbersStack, getStringArray);
        }
       
        static string[] GetStringArray(string inputExpression)
        {
            string[] getStringArray = new string[inputExpression.Length];
            var inNumber = false;
            var operandIndex = -1;
            var SizeArray = 0;
            for (int i = 0; i < inputExpression.Length; i++)
            {
                if (CheckIfIsSymbol(inputExpression[i]))
                {
                    if (!inNumber)
                    {
                        operandIndex++;
                        getStringArray[operandIndex] = Char.ToString(inputExpression[i]);
                        inNumber = true;
                    }
                    else
                    {
                        getStringArray[operandIndex] = getStringArray[operandIndex] + inputExpression[i];
                        SizeArray--;
                    }
                    SizeArray++;
                }
                else if (CheckIfIsOperation(inputExpression[i]))
                {
                    operandIndex++;
                    getStringArray[operandIndex] = Char.ToString(inputExpression[i]);
                    inNumber = false;
                    SizeArray++;
                }
                else
                {
                    inNumber = false;
                }
            }
            string[] getTrueArray = new string[SizeArray];
            Array.Copy(getStringArray, getTrueArray, getTrueArray.Length);          
            return getTrueArray;
        }
        
        static void CheckInputErrors(string array)
        {
            var firstCounter = 0;
            var secondCounter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (CheckErorSymbol(array[0]) || CheckErorSymbol(array[array.Length-1] ))
                {
                    Console.WriteLine("Eror operation. You can not put the operation at the beginning or end");
                    IsGeneralFunction();
                }
                if (CheckErorSymbol(array[i]) && CheckErorSymbol(array[i - 1]))
                {
                    Console.WriteLine("Eror operation. More than one operation sign");
                    IsGeneralFunction();
                }
                if (i !=0 && array[i] == '(' && array[i - 1] == ')' ||
                    i != 0 && array[i] == ')' && array[i - 1] == '(' ||
                    CheckErorSymbol(array[i]) && array[i + 1] == ')')
                {
                    Console.WriteLine("Invalid parentheses");
                    IsGeneralFunction();
                }
                if (array[i] == '(')
                {
                    firstCounter++;
                }
                else if (array[i] == ')')
                {
                    secondCounter++;
                }
            }
            if (firstCounter != secondCounter)
            {
                Console.WriteLine("You entered the wrong number of parentheses");
                IsGeneralFunction();
            }
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
       
        static bool CheckIfIsOperation(char operation)
        {
            char[] arrayOperation = { '+', '-', '*', '/', '(', ')', '^' };
            for (int i = 0; i < arrayOperation.Length; i++)
            {
                if (operation == arrayOperation[i])
                {
                    return true;
                }
            }
            return false;
        }
        
        static bool CheckErorSymbol(char operation)
        {
            char[] arrayOperation = { '+', '-', '*', '/', ',', '.', '^' };
            for (int i = 0; i < arrayOperation.Length; i++)
            {
                if (operation == arrayOperation[i])
                {
                    return true;
                }
            }
            return false;
        }
       
        static bool CheckIfIsOperationString(string literal)
        {
            char c = literal.ToCharArray()[0];
            if (CheckIfIsOperation(c))
            {
                return true;
            }
            return false;
        }
       
        static int CheckPriorityOperation(string operation)
        {
            var result = 0;
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
       
        static double CalculationTwoNumbers(string operation, double penultimateNumberStack, double lastNumberStack)
        {
            double result = 0;
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
       
        static void IsResultExpression(string[] operationStack, double[] numbersStack, string[] getStringArray)
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
                        IsGeneralFunction();
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
                            numbersStack[countNumber - 1] = CalculationTwoNumbers(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
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
                        numbersStack[countNumber - 1] = CalculationTwoNumbers(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
                        countOperation--;
                        i--;
                    }
                }
                if (i == getStringArray.Length - 1)
                {
                    while (countOperation != 0)
                    {
                        countNumber--;
                        numbersStack[countNumber - 1] = CalculationTwoNumbers(operationStack[countOperation - 1], numbersStack[countNumber - 1], numbersStack[countNumber]);
                        countOperation--;
                    }
                }
            }
            Console.WriteLine($"Result:{numbersStack[0]}");
            Console.WriteLine("Press any key or 'Y' if you want to exit!");
            var testY = Console.ReadLine();
            if (testY != "Y" || testY != "y")
            {
                Console.Clear();
                IsGeneralFunction();
            }
            
        }
    }
}

