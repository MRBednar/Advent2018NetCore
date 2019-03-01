using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Google.Cloud.Storage.V1;

namespace Advent2018NetCore
{
    public class Day4Runner : AbstractDay
    {
        override public void Run()
        {
            List<LogEntry> Input = new List<LogEntry>();

            using (var reader = new StreamReader("Test.txt", Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var rowString = reader.ReadLine();
                    var stringParts = rowString.Split(' ');
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