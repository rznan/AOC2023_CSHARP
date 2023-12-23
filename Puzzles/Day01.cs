namespace Puzzles
{
    // Trebuchet?!
    public class Day01
    {
        private static readonly Dictionary<string, int> SpelledDigits = new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        public static int Part1Solution(String[] input)
        {
            // For each string in a array of strings, finds the first
            // and last number(digits) and creates a new number composed of the first
            // followed by the last. 
            // Returns the sum of all the numbers created in each string

            int result = 0;

            foreach(string line in input)
            {
                List<int> numbersFound = [];
                for(int i = 0; i < line.Length; i++)
                {
                    if(int.TryParse(line[i].ToString(), out int t))
                    {
                        numbersFound.Add(t);       
                    }
                }
                if(numbersFound.Count > 0)
                    result += (numbersFound[0] * 10) + numbersFound.Last();
            }

            return result;
        }

        public static int Part2Solution(String[] input)
        {
            // For each string in a array of strings, finds the first
            // and last number (digits and spelled numbers) and creates
            // a new number composed of the first followed by the last.
            // Returns the sum of all the numbers created in each string

            int result = 0;

            foreach(string line in input)
            {
                List<int> numbersFound = [];
                

                string letterBuffer = "";

                foreach(char simbol in line)
                {
                    letterBuffer += simbol.ToString();
                    if (letterBuffer.Length > 5)
                    {
                        letterBuffer = letterBuffer[1..];
                    }

                    foreach(string spelledNumber in SpelledDigits.Keys)
                    {
                        if(letterBuffer.Contains(spelledNumber))
                        {
                            numbersFound.Add(SpelledDigits[spelledNumber]);
                            // removes all but the last character of the spelled number
                            // (and previous characters) from  the buffer - prevents 
                            // adding the same number multiple times and still handles 
                            // cases similar to 'twone'
                            letterBuffer = letterBuffer[(letterBuffer.IndexOf(spelledNumber)
                                                         + spelledNumber.Length
                                                         - 1)..];
                            break;
                        }
                    }

                    if(int.TryParse(simbol.ToString(), out int t))
                    {
                        numbersFound.Add(t);       
                    }
                }

                if(numbersFound.Count > 0)
                    result += (numbersFound[0] * 10) + numbersFound.Last();
            }

            return result;
        }
    }
}