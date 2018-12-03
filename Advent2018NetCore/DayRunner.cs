using System;
using System.Collections.Generic;
using Advent2018NetCore.Day1;
using Advent2018NetCore.Day2;

namespace Advent2018NetCore
{
    class DayRunner
    {
        public static void Main(string[] args)
        {
            // I wanted a simple way to run whatever day's
            // code in whatever order I wanted. This takes
            // the days as inputs and runs them one by one
            int day;
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out day))
                {
                    dayArgument[day].Run();
                }
                Console.ReadKey();
            }
        }

        public static Dictionary<int, IDay>
            dayArgument = new Dictionary<int, IDay>
            {
                {1, new Day1Runner() },
                {2, new Day2Runner() },
            };
    }
}
