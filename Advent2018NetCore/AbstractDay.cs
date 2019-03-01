using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2018NetCore
{
    public abstract class AbstractDay : IDay
    {
        public abstract void Run();

        public StreamReader GetInputs()
        {
            var gStorageClient = StorageClient.Create(DayRunner.GoogleCreds);
            var inputFile = new MemoryStream();
            gStorageClient.DownloadObject(DayRunner.BucketName, string.Format(DayRunner.FileName, DayRunner.Day), inputFile);
            inputFile.Position = 0;
            return new StreamReader(inputFile);            
        }
    }

}
