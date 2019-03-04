using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Google.Cloud.Storage.V1;

namespace Advent2018NetCore
{
    public class Day4Runner : AbstractDay
    {
        override public void Run()
        {
            List<LogEntry> Input = new List<LogEntry>();
            var guardTotalSleep = new Dictionary<int, int>();
            var unsortedList = new Dictionary<DateTime, string>();
            Regex cleanTimeString = new Regex(@"\[");
            Regex guardId = new Regex(@"Guard #");
            Regex startSleep = new Regex(@"falls");
            Regex wakeTime = new Regex(@"wakes");
            DateTime sleepTime = new DateTime();
            int currentGuard = 0;
            using (var reader = new StreamReader("Test.txt", Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var rowString = reader.ReadLine();
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
                        var minSlept = (rowData.Key - sleepTime).Minutes;
                        if (guardTotalSleep.TryGetValue(currentGuard, out var currentSleep))
                        {
                            guardTotalSleep[currentGuard] = currentSleep + minSlept;
                        }
                        else
                        {
                            guardTotalSleep.Add(currentGuard, minSlept);
                        }
                    }
                }
            }

            var gStorageClient = StorageClient.Create(DayRunner.GoogleCreds);
            using (var gReader = GetInputs())
            {

            }
        }

        private void Part1(List<LogEntry> inputs)
        {

        }

        private void Part2(List<LogEntry> inputs)
        {

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