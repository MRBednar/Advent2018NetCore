using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent2018NetCore.Day2
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
            List<char[]> multipleLetters = new List<char[]>();
            List<char[]> matchLetters = new List<char[]>();
            List<char[]> singleLetters = new List<char[]>();

            var charArrays = alphaArray.Select(row => row.ToCharArray()).ToArray();
            var maxLen = inputs.Max(row => row.Length);
            
            for (var i = 0; i < maxLen; i++)
            {
                var test = charArrays.GroupBy(row => row[i], (key, result) => return new Dictionary<char, char[][]> {key, results}));

            }
        }

        private static IEnumerable<string> FindAllSubstrings(string s)
        {
        List<string> list = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string ss = s.Substring(i, j - i + 1);
                    list.Add(ss);
                }
            }
            return list;
        }
    }
}
