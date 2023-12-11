namespace Puzzles
{
    public class Day02
    {
        public static int Part1Solution(string[] input)
        {
            // Returns the sum of all valid games acoording to the rule:
            // games must have at maximmum12 red cubes, 13 green cubes,
            // and 14 blue cubes
            int validGameNumbersSum = 0;
            
            foreach(string gameLine in input)
            {
                int gameNumber = GetGameNumber(gameLine);
                Dictionary<string, int> numberOfGameCubes = new()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                CountGameCubes(numberOfGameCubes, gameLine);

                if(ValidateGame(numberOfGameCubes))
                {
                    validGameNumbersSum += gameNumber;
                }
            }
            return validGameNumbersSum;
        }

        public static int Part2Solution(string[] input)
        {
            // Returns the sum of the multiplication of the minimum
            // amount of game cubes per game
                        
            int multiplicationSum = 0;

            foreach(string gameLine in input)
            {
                Dictionary<string, int> numberOfGameCubes = new()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                CountGameCubes(numberOfGameCubes, gameLine);

                multiplicationSum += numberOfGameCubes["red"] * 
                                     numberOfGameCubes["green"] * 
                                     numberOfGameCubes["blue"];

            }

            return multiplicationSum;
        }

        static int GetGameNumber(string gameLine)
        {
            if(int.TryParse(gameLine.Split(":")[0].Split(" ")[1], out int gameNumber))
            {
                return gameNumber;
            }
            throw new FormatException("Game formated incorrectely in: " + gameLine);
        }

        private static void CountGameCubes(Dictionary<string, int> numberOfGameCubes, string gameLine)
        {
            // detaches the game id from the game contents and
            // makes an array of the cube sets in said game
            string[] cubeSets = gameLine
                                .Split(":")[1]
                                .Split(";");
            
            foreach(string set in cubeSets)
            {
                // separates the game sets and and updates
                // the number of cubes (if necessary)
                string[] pulls = set.Split(",");

                foreach(string pull in pulls)
                {
                    String[] pullData = pull.Trim().Split(" ");

                    if(numberOfGameCubes[pullData[1]] < Convert.ToInt32(pullData[0]))
                    {
                        numberOfGameCubes[pullData[1]] = Convert.ToInt32(pullData[0]);
                    }
                }
            }
        }

        static bool ValidateGame(Dictionary<string, int> gameCubes)
        {
            return (gameCubes["red"] <= 12 && gameCubes["green"] <= 13 && gameCubes["blue"] <= 14);
        }
    }
}