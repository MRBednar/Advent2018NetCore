using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Advent2018NetCore
{
    class DayRunner
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            var currentDir = Environment.CurrentDirectory;
            var basePath = currentDir.Contains("Debug") ? Directory.GetParent(currentDir).Parent.Parent.FullName : Directory.GetParent(currentDir).Parent.FullName;
            configBuilder.SetBasePath(basePath);
            configBuilder.AddJsonFile("appsettings.json");

            var configurationRoot = configBuilder.Build();

            // I wanted a simple way to run whatever day's
            // code in whatever order I wanted. This takes
            // the days as inputs and runs them one by one
            int day;
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out day))
                {
                    var inputUrl = String.Format(configurationRoot.GetSection("Advent").GetSection("InputUrl").Value, day);
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
                {3, new Day3Runner() },
            };
    }
}
