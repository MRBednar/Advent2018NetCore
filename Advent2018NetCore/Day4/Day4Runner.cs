using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2018NetCore
{
    public class Day4Runner : IDay
    {
        public void Run()
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