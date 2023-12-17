namespace Puzzles
{
    public class Day03
    {
        public static long Part1Solution(string[] input)
        {
            long partNumberSum = 0;
            int lineAmmount = input.Length;
            Queue<int> digitsBuffer = [];

            for(int lineNumber = 0; lineNumber < lineAmmount; lineNumber++)
            {
                int lineLength = input[lineNumber].Length;
                int numberStartPositon = 0;

                for(int cursorPosition = 0; cursorPosition < lineLength; cursorPosition++)
                {
                    // Finds the digits in a line and store in digitsBuffer. After a
                    // sequence of 1 or more number ends, or its the last char in a line,
                    // it checks if its a part number, if it is then it adds to the sum
                    if(int.TryParse(input[lineNumber][cursorPosition].ToString(), out int valor))
                    {
                        if(digitsBuffer.Count == 0)
                            numberStartPositon = cursorPosition;
                        digitsBuffer.Enqueue(valor);
                        if(cursorPosition < lineLength -1) continue; //check if is last char in line
                    }

                    // case found a non-digit char or last position in line
                    if(digitsBuffer.Count != 0)
                    {
                        if(IsPartNumber(numberLine:lineNumber, numberStartPositon:numberStartPositon, numberLenght:digitsBuffer.Count, input:input))
                            partNumberSum += AssembleNumber(digitsBuffer);
                        digitsBuffer.Clear();
                    }
                }
            }
            return partNumberSum;
        }

        public static int Part2Solution(string[] input)
        {
            // find the gear ratio of the engine. Searches for any '*' and checks
            // the numbers arround it to get the gear ratio of the engine
            int gearRatio = 0;
            int lineAmmount = input.Length;

            for(int lineNumber = 0; lineNumber < lineAmmount; lineNumber++)
            {
                int lineLength = input[lineNumber].Length;
                for(int cursorPosition = 0; cursorPosition < lineLength; cursorPosition++)
                { 
                    if(input[lineNumber][cursorPosition].Equals('*'))
                    {
                        gearRatio += GetGearRatio(yPosition:lineNumber, xPosition:cursorPosition, input:input);
                    }
                }
            }
            return gearRatio;
        }

        private static int GetGearRatio(int yPosition, int xPosition, string[] input)
        {
            // uses the coordinates of a '*' to check for a gear ratio.
            // to be a gear ratio there must be only 2 numbers around 
            // the '*'. Their multiplication is the gear ratio
            Queue<int> numberBuilder = new();
            int numberCount = 0;
            int gearRatio = 1;

            for(int line = yPosition-1; line <= yPosition+1; line++)
            {
                for(int cursorPosition = xPosition-1; cursorPosition <= xPosition+1; cursorPosition++)
                {
                    try
                    {
                        // Check it current char is a number. If true checks the next char. 
                        if(int.TryParse(input[line][cursorPosition].ToString(), out int digit))
                        {
                            cursorPosition = GetNumberDigits(numberBuilder, line, cursorPosition, input); // sets the cursor to the end of the number
                            if(cursorPosition <= xPosition && cursorPosition < input[line].Length-1) continue; // check if is last char in the sorroundings
                        }
                    }
                    catch(IndexOutOfRangeException){} 
                    finally
                    {
                        // builds a number and adds it to the gear ratio
                        if(numberBuilder.Count > 0)
                        {
                            gearRatio *= AssembleNumber(numberBuilder);
                            numberCount++;
                            numberBuilder.Clear();
                        }
                    }
                }
            }
            return numberCount == 2 ? gearRatio : 0;
        }

        private static int GetNumberDigits(Queue<int> numberBuilder, int yPosition, int xPosition, string[] input)
        {   
            // fill the numberBuilder with the number specified by the given
            // coordinates. The coordinate can be any digit of the number.
            // returns the position of the number's last digit
            int lastDigitPosition = xPosition;
            int reverseIterator = xPosition;

            Stack<int> digitsBefore = new();

            // adds any digit before the provided coordinates
            try
            {
                while(int.TryParse(input[yPosition][reverseIterator].ToString(), out int digit))
                {
                    digitsBefore.Push(digit);
                    reverseIterator--;
                }
            }
            catch(IndexOutOfRangeException){}
            finally
            {
                while(digitsBefore.Count > 0)
                {
                    numberBuilder.Enqueue(digitsBefore.Pop());
                }
            }

            // ads any digit after the provided coordinates
            try
            {
                while(int.TryParse(input[yPosition][lastDigitPosition+1].ToString(), out int digit))
                {
                    numberBuilder.Enqueue(digit);
                    lastDigitPosition++;
                }
            }
            catch(IndexOutOfRangeException){}

            return lastDigitPosition;
        }

        private static bool IsPartNumber(int numberLine, int numberStartPositon, int numberLenght, string[] input)
        {
            // iterates throgh the number's surrounding characters
            for(int currentLine = numberLine-1; currentLine <= numberLine+1; currentLine++)
            {
                if(currentLine >= 0 && currentLine < input.Length)
                {
                    for(int cursorPosition = numberStartPositon - 1; cursorPosition <= numberStartPositon + numberLenght; cursorPosition++)
                    {
                        try
                        {
                            // checks if current char is valid
                            if(input[currentLine][cursorPosition] != '.' && !int.TryParse(input[currentLine][cursorPosition].ToString(), out int _))
                            {
                                return true;
                            }
                        }
                        catch(IndexOutOfRangeException){continue;}
                    }
                }
            }

            return false;
        }

        public static int AssembleNumber(Queue<int> digits)
        {
            int result = 0;
            while(digits.Count > 0)
            {
                result = (result * 10) + digits.Dequeue();
            }
            return result;
        }

    }
}