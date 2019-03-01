using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;

namespace Advent2018NetCore
{
    class DayRunner
    {
        public static IConfigurationRoot ConfigRoot;
        public static GoogleCredential GoogleCreds;
        public static int Day;
        public static string BucketName;
        public static string FileName;

        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            var currentDir = Environment.CurrentDirectory;
            var basePath = currentDir.Contains("Debug") ? Directory.GetParent(currentDir).Parent.Parent.FullName : Directory.GetParent(currentDir).Parent.FullName;
            configBuilder.SetBasePath(basePath);
            configBuilder.AddJsonFile("appsettings.json");

            ConfigRoot = configBuilder.Build();
            BucketName = ConfigRoot.GetSection("Google").GetSection("BucketName").Value;
            FileName = ConfigRoot.GetSection("Google").GetSection("FileName").Value;

            var path = Environment.GetEnvironmentVariable("gCredFilePath");

            GoogleCreds = GoogleCredential.FromFile(path);
            // I wanted a simple way to run whatever day's
            // code in whatever order I wanted. This takes
            // the days as inputs and runs them one by one
            foreach (string arg in args)
            {
                if (int.TryParse(arg, out Day))
                {
                    dayArgument[Day].Run();
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
                {4, new Day4Runner() },
            };
    }
}
