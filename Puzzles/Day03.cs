using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzles
{
    public class Day03
    {
        public static int Part1Solution(string[] input)
        {
            int partNumberSum = 0;
            int lineAmmount = input.Length;
            List<int> digitsBuffer = [];

            for(int lineNumber = 0; lineNumber < lineAmmount; lineNumber++)
            {
                int lineLength = input[lineNumber].Length;

                for(int cursorPosition = 0; cursorPosition < lineLength; lineNumber++)
                {
                    // Finds the digits in a line and store in digitsBuffer. After a
                    // sequence of 1 or more number ends, or its the last char in a line,
                    // it checks if its a part number, if it is then it adds to the sum
                    if(int.TryParse(input[lineNumber][cursorPosition].ToString(), out int valor))
                    {
                        digitsBuffer.Add(valor);
                        if(!(cursorPosition == lineLength -1)) continue;
                    }

                    // case found a non-digit char or last position in line
                    if(digitsBuffer.Count > 0)
                    {
                        if(IsPartNumber(lineNumber:lineNumber, numberEndPositon:cursorPosition-1, numberLenght:digitsBuffer.Count, input:input))
                            partNumberSum += AssembleNumber(digitsBuffer);
                        digitsBuffer.Clear();
                    }
                }
            }
            throw new NotImplementedException();
        }

        private static bool IsPartNumber(int lineNumber, int numberEndPositon, int numberLenght, string[] input)
        {
            throw new NotImplementedException();
        }

        private static int AssembleNumber(List<int> digits)
        {
            throw new NotImplementedException();
        }

        public static int Part2Solution(string[] input)
        {
            
            throw new NotImplementedException();
        }
    }
}