using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Google.Cloud.Storage.V1;

namespace Advent2018NetCore
{
    public class Day4Runner : AbstractDay
    {
        Dictionary<int, int> guardTotalSleep = new Dictionary<int, int>();
        Dictionary<int, Dictionary<int, int>> minSlept = new Dictionary<int, Dictionary<int, int>>();

        override public void Run()
        {
            List<LogEntry> Input = new List<LogEntry>();
            var unsortedList = new Dictionary<DateTime, string>();
            Regex cleanTimeString = new Regex(@"\[");
            Regex guardId = new Regex(@"Guard #");
            Regex startSleep = new Regex(@"falls");
            Regex wakeTime = new Regex(@"wakes");
            DateTime sleepTime = new DateTime();
            int currentGuard = 0;

            var gStorageClient = StorageClient.Create(DayRunner.GoogleCreds);
            using (var gReader = GetInputs())
            {
                while (!gReader.EndOfStream)
                {
                    var rowString = gReader.ReadLine();
                    var stringParts = rowString.Split("] ");
                    var timestamp = stringParts[0];
                    var action = stringParts[1];
                    var rowDateTime = DateTime.Parse(cleanTimeString.Replace(timestamp, ""));
                    unsortedList.Add(rowDateTime, action);
                }
            }

            var sortedInput = new SortedDictionary<DateTime, string>(unsortedList);
            foreach (var rowData in sortedInput)
            {
                if (guardId.IsMatch(rowData.Value))
                {
                    var guardSplit = guardId.Replace(rowData.Value, "").Split(" ");
                    currentGuard = int.Parse(guardSplit[0]);
                    sleepTime = DateTime.MinValue;
                }
                if (startSleep.IsMatch(rowData.Value))
                {
                    sleepTime = rowData.Key;
                }
                if (wakeTime.IsMatch(rowData.Value))
                {
                    if (!sleepTime.Equals(DateTime.MinValue))
                    {
                        var sleepInMin = (rowData.Key - sleepTime).Minutes;
                        if (guardTotalSleep.TryGetValue(currentGuard, out var currentSleep))
                        {
                            guardTotalSleep[currentGuard] = currentSleep + sleepInMin;
                        }
                        else
                        {
                            guardTotalSleep.Add(currentGuard, sleepInMin);
                        }

                        for (var i = sleepTime.Minute; i < rowData.Key.Minute; i++)
                        {
                            if (!minSlept.TryGetValue(currentGuard, out var guardSleepMin))
                            {
                                minSlept.Add(currentGuard, new Dictionary<int, int> { { i, 1 } });
                                continue;
                            }

                            if (guardSleepMin.TryGetValue(i, out var minCount))
                            {
                                minSlept[currentGuard][i] = minCount + 1;
                            }
                            else
                            {
                                minSlept[currentGuard].Add(i, 1);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Day4:");
            Part1();
            Part2();
        }

        private void Part1()
        {
            var lazestGuard = guardTotalSleep.OrderByDescending(x => x.Value).First().Key;
            minSlept.TryGetValue(lazestGuard, out var minValues);
            var minSleptMost = minValues.OrderByDescending(x => x.Value).First().Key;

            Console.WriteLine("Part1");
            Console.WriteLine("Lazest Guard: {0}", lazestGuard);
            Console.WriteLine("Minute Asleep Most Often: {0}", minSleptMost);
            Console.WriteLine("Result: {0}", lazestGuard * minSleptMost);
            Console.WriteLine();
        }

        private void Part2()
        {
            var mostSleptMin = new List<(int, int, int)>();
            foreach (var guard in minSlept)
            {
                var gMostSlept = guard.Value.OrderByDescending(x => x.Value).First();
                mostSleptMin.Add((guard.Key, gMostSlept.Key, gMostSlept.Value));
            }

            var mostSlept = mostSleptMin.OrderByDescending(x => x.Item3).First();
            Console.WriteLine("Part2");
            Console.WriteLine("Minute Most Frequently Asleep: {0}", mostSlept.Item2);
            Console.WriteLine("Guard ID: {0}", mostSlept.Item1);
            Console.WriteLine("Result: {0}", mostSlept.Item1 * mostSlept.Item2);
            Console.WriteLine();
        }
    }

    public class LogEntry
    {
        public enum ActionType
        {
            GuardChange,
            FallsAsleep,
            WakesUp,
        }

        public int GuardId { get; set; }

        public ActionType LogAction { get; set; }

        public DateTime LogTime { get; set; }
    }
}