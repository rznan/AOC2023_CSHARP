using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Puzzles
{
    public class Day03
    {
        public static long Part1Solution(string[] input)
        {
            long partNumberSum = 0;
            int lineAmmount = input.Length;
            List<int> digitsBuffer = [];

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
                        digitsBuffer.Add(valor);
                        if(cursorPosition < lineLength -1) continue;
                    }

                    // case found a non-digit char or last position in line
                    if(digitsBuffer.Count != 0)
                    {
                        if(IsPartNumber(numberLine:lineNumber, numberStartPositon:numberStartPositon, numberLenght:digitsBuffer.Count, input:input))
                            partNumberSum += AssembleNumber(digitsBuffer);
                        digitsBuffer.Clear();
                        //Console.WriteLine(partNumberSum);
                    }
                }
            }

            return partNumberSum;
        }

        private static bool IsPartNumber(int numberLine, int numberStartPositon, int numberLenght, string[] input)
        {
            // percorre os arredores de um número em busca de algum simbolo
            // caso encontre um simbolo então o número inserido é valido
            
            // percorre desde uma linha antes até uma linha depois
            for(int currentLine = numberLine-1; currentLine <= numberLine+1; currentLine++)
            {
                if(currentLine >= 0 && currentLine < input.Length)
                {
                    // percorre desde um caráctere antes até um caractére depois
                    for(int cursorPosition = numberStartPositon - 1; cursorPosition <= numberStartPositon + numberLenght; cursorPosition++)
                    {
                        if(cursorPosition >= 0 && cursorPosition < input[currentLine].Length)
                        {
                            // checa se o caractére atual é um simbolo válido
                            if(input[currentLine][cursorPosition] != '.' && !int.TryParse(input[currentLine][cursorPosition].ToString(), out int _))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public static int AssembleNumber(List<int> digits)
        {
            int result = 0;
            for(int cont = 0; cont < digits.Count; cont++)
            {
                result += digits[cont];
                result = cont < digits.Count - 1 ? result * 10 : result;
            }

            return result;
        }

        public static int Part2Solution(string[] input)
        {
            
            throw new NotImplementedException();
        }
    }
}