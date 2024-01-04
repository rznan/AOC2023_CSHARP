using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Transactions;

namespace Puzzles
{
    public class Day05
    {
        public static long Part1Solution(String[] input)
        {
            long[] seeds = input[0].Split(":")[1]
                .Split(" ")
                .Skip(1)  // first string is blank
                .Select(long.Parse)
                .ToArray();

            List<long[]> ranges = new List<long[]>();

            // iterates throught every map and updates seed values according to every map in order
            for(int i = 3; i < input.Length; i++)
            {
                if(!string.IsNullOrEmpty(input[i]))
                {
                    // inserting the map's range values
                    ranges.Add(input[i].Split(" ").Select(long.Parse).ToArray()); 
                    // adds: destinationRangeStart, sourceRangeStart and rangeLength respectively

                    if(i != input.Length -1) continue;
                }

                // uptades seeds after reading the map
                
                List<long> newSeeds = [];

                foreach(long seed in seeds)
                {
                    // checks if the seed is inside any range from the map
                    if(ranges.Any(range => range[1] <= seed && seed <= range[1] + range[2])) // : sourceRangeStart <= seed <= sourceRangeStart + rangeLength
                    {
                        // returns the first range in ranges where the seed is inside the range
                        long[] rangeValues = ranges.Where(range => range[1] <= seed && seed <= range[1] + range[2]).ToArray().First(); 
                        newSeeds.Add(seed - rangeValues[1] + rangeValues[0]); // : seed - sourceRangeStart + destinationRangeStart
                        continue;
                    }
                    else
                    {
                        newSeeds.Add(seed);
                    }
                }
                seeds = newSeeds.ToArray();
                ranges.Clear();
                i++;
            }

            return seeds.Min();
        }

    }
}