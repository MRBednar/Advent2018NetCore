using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent2018NetCore
{
    public class Day3Runner : IDay
    {
        public void Run()
        {
            List<RowData> Input = new List<RowData>();

            using (var reader = new StreamReader("Day3\\Day3Input.txt", Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var rowString = reader.ReadLine();
                    var stringParts = rowString.Split(' ');
                    var id = int.Parse(stringParts[0].Replace('#', ' ').Trim());
                    var edges = stringParts[2].Split(',');
                    var dimensons = stringParts[3].Split('x');
                    Input.Add(new RowData {
                        ID = id,
                        LeftEdge = int.Parse(edges[0]),
                        TopEdge = int.Parse(edges[1].Replace(':', ' ').Trim()),
                        Width = int.Parse(dimensons[0]),
                        Height = int.Parse(dimensons[1])
                    });
                }
            }

            Part1(Input);
        }

        private void Part1(List<RowData> inputs)
        {
            var maxHeight = inputs.Max(row => row.TopEdge + row.Height);
            var maxWidth = inputs.Max(row => row.LeftEdge + row.Width);
            int[,] grid = new int[maxWidth, maxHeight];
            var overlap = 0;
            for(var i = 0; i < inputs.Count(); i++)
            {
                for(var w = inputs[i].LeftEdge-1; i < (inputs[i].LeftEdge + inputs[i].Width); i++)
                {
                    for(var h = inputs[i].TopEdge-1; h > (inputs[i].TopEdge - inputs[i].Height); h--)
                    {
                        var test = grid[w, h];
                        grid[w, h] = test + 1;
                        if(grid[w,h] == 2)
                        {
                            overlap = overlap + 1;
                        }
                    }
                }
            }
            Console.WriteLine(overlap);
        }

        private void Part2(List<RowData> inputs)
        {

        }

        
    }

    public class RowData {

        public int ID { get; set; }
        public int LeftEdge { get; set; }
        public int TopEdge { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
