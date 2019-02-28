using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018NetCore
{
    public class Day1Runner : IDay
    {
        public void Run()
        {
            List<int> Input = new List<int>();

            var gStorageClient = StorageClient.Create(DayRunner.GoogleCreds);

            using (var inputFile = new MemoryStream())
            {
                gStorageClient.DownloadObject("bednar_test_bucket", "Day1Input.txt", inputFile);

                using (var gReader = new StreamReader(inputFile))
                {
                    gReader.ReadToEnd();
                    while (!gReader.EndOfStream)
                    {
                        Input.Add(int.Parse(gReader.ReadLine()));
                        Console.WriteLine("Day 1");
                        Part1(Input);
                        Part2(Input);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }

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
