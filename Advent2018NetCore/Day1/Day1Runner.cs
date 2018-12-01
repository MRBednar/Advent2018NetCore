using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2018NetCore.Day1
{
    public class Day1Runner : IDay
    {
        public void Run()
        {
            List<int> Input = new List<int>();

            using (var reader = new StreamReader("Day1\\Day1Input.txt", Encoding.UTF8))
            {
                Console.WriteLine("Day 1");
                while (!reader.EndOfStream)
                {
                    Input.Add(int.Parse(reader.ReadLine()));
                }
                Part1(Input);
                Part2(Input);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private void Part1(List<int> inputs)
        {
            int frequency = 0;
            Console.WriteLine("Part 1");

            foreach (int input in inputs)
            {
                frequency = frequency + input;
            }
            Console.WriteLine(frequency);
            Console.WriteLine();
        }

        private void Part2(List<int> inputs)
        {
            var frequencyHistory = new List<int>();
            var freaqTwice = false;
            int frequency = 0;
            Console.WriteLine("Part 2");
            while(!freaqTwice)
            {
                foreach (int input in inputs)
                {
                    frequency = frequency + input;
                    if (frequencyHistory.Contains(frequency))
                    {
                        Console.WriteLine(frequency);
                        freaqTwice = true;
                        break;
                    }
                    else
                    {
                        frequencyHistory.Add(frequency);
                    }
                }
            }            
        }
    }
}
