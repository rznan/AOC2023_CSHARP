using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzles
{
    public class Day04
    {
        public static int Part1Solution(string[] input)
        {
            int result = 0;

            foreach(string line in input)
            {
                Card card = new Card(line);
                int cardResult = 0;

                foreach(int number in card.playersNumbers)
                {
                    if(card.winningNumbers.Contains(number))
                    {
                        cardResult = cardResult > 0 ? cardResult * 2 : 1;
                    }
                }

                result += cardResult;
            }

            return result;
        }

        public static object Part2Solution(string[] input)
        {
            throw new NotImplementedException();
        }
    }

    class Card
    {
        public int CardId { get; set; }
        public List<int> playersNumbers = new List<int>();
        public List<int> winningNumbers = new List<int>(); 

        public Card(string gameLine)
        {
            string[] sectionedLine = gameLine.Split(":");
            if(int.TryParse(sectionedLine[0].Split("d")[1].Trim(), out int cardId))
            {
                CardId = cardId;
            } // throw error case dont find a card number

            sectionedLine = sectionedLine[1].Split("|");

            GetSectionNumbers(sectionedLine[0], playersNumbers);
            GetSectionNumbers(sectionedLine[1], winningNumbers);
            
        }

        private void GetSectionNumbers(string NumbersSection, List<int> Target)
        {
            foreach(string number in NumbersSection.Split(" "))
            {
                if(string.IsNullOrEmpty(number))
                {
                    continue;
                }
                else if(int.TryParse(number, out int value))
                {
                    Target.Add(value);
                }
            }
        }
    }
}