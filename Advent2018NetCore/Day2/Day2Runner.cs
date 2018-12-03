using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent2018NetCore
{
    public class Day2Runner : IDay
    {
        public void Run()
        {
            List<string> Input = new List<string>();

            using (var reader = new StreamReader("Day2\\Day2Input.txt", Encoding.UTF8))
            {
                Console.WriteLine("Day 2");
                while (!reader.EndOfStream)
                {
                    Input.Add(reader.ReadLine());
                }
                Part1(Input);
                Part2(Input);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void Part1(List<string> inputs)
        {
            var twoCountCheck = 0;
            var threeCountCheck = 0;

            foreach(var input in inputs)
            {
                var lineArray = new List<char>(input.ToCharArray());

                var twoFound = false;
                var threeFound = false;

                lineArray.Sort();

                foreach(var character in lineArray)
                {
                    var found = (lineArray.FindAll(ch => ch == character)).Count;

                    if(found == 2)
                    {
                        twoFound = true;
                    }

                    if (found == 3)
                    {
                        threeFound = true;
                    }
                }

                if (twoFound)
                {
                    twoCountCheck++;
                }

                if (threeFound)
                {
                    threeCountCheck++;
                }
            }

            var checksum = twoCountCheck * threeCountCheck;
            Console.WriteLine("Part 1: " + checksum);
        }

        private void Part2(List<string> inputs)
        {
            var alphaArray = inputs.ToArray();
            Array.Sort(alphaArray);
            var compareDict = new Dictionary<int, char[]>();

            var charArrays = alphaArray.Select(row => row.ToCharArray()).ToArray();
            var maxLen = inputs.Max(row => row.Length);
            var rowCount = inputs.Count();

            for(var i = 0; i < rowCount; i++)
            {
                for(var z = i+1; z < rowCount; z++)
                {
                    var hasDifferentChar = false;

                    for (var x = 0; x < maxLen; x++)
                    {
                        var topChar = charArrays[i][x];
                        var compareChar = charArrays[z][x];
                        if (topChar != compareChar)
                        {
                            if (hasDifferentChar)
                            {
                                break;
                            }
                            hasDifferentChar = true;
                        }
                        if( x == maxLen-1)
                        {
                            Console.WriteLine(new String(charArrays[i]));
                            Console.WriteLine(new String(charArrays[z]));
                        }
                    }
                }
            }
        }
    }
}
