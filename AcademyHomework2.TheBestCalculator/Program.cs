namespace AcademyHomework2.TheBestCalculator
{

    internal class Program
    {

        static public void Main()
        {
            ////////////  PART 1 ARRAY
            string something = "12.5678+15/16(-16+23)";
            
            string[] operationStack=  new string[something.Length];
            string[] numbersStack= new string[something.Length];

            string[] getStringArray = GetStringArray(something);


            //CheckParentheses(secondArrayGet);




            ////////////////// PART 2 

            var n = 0;
            var op = 0;
            var result = 0;
            for (int i = 0; i <getStringArray.Length; i++)
            {
                

                if (!CheckIfIsOperationString(getStringArray[i]))
                {   
                    numbersStack[n]=getStringArray[i];
                    n++;
                }
                else
                    
                {
                    if (CheckPriorityOperation(getStringArray[i]) > CheckPriorityOperation(operationStack[op]))
                    {
                        operationStack[op] = getStringArray[i];
                        op++;
                    }
                    else
                    { 
                        
                    }
                }
                

            }

            
        }

        static string[] GetStringArray(string something)
        {
            string[] getStringArray = new string[something.Length];
            var inNumber = false;
            var operandIndex = -1;
            var SizeArray = 0;
            for (int i = 0; i < something.Length; i++)
            {
                //ctrl +k+d
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

            var y = 0;
            foreach (var item in secondArrayGet)
            {
                y++;
                Console.WriteLine($"[{y}]={item}");
            }

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
            char[] arrayOperation = { '+', '-', '*', '/', '(', ')' };
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

        





    }
}

