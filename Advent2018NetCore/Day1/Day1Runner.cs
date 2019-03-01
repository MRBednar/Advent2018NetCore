using System;
using System.Collections.Generic;
using System.IO;
using Google.Cloud.Storage.V1;

namespace Advent2018NetCore
{
    public class Day1Runner : AbstractDay
    {
        override public void Run()
        {
            List<int> Input = new List<int>();

            var gStorageClient = StorageClient.Create(DayRunner.GoogleCreds);

            using (var gReader = GetInputs())
            {
                while (!gReader.EndOfStream)
                {
                    Input.Add(int.Parse(gReader.ReadLine()));
                }

                Console.WriteLine("Day 1");
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
            while (!freaqTwice)
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
