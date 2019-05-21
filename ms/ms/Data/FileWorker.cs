using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ms.Data
{
    //[assembly: Dependency(typeof(ms.Data.FileWorker))]
    class FileWorker
    {
        public string filePath;

        string getDocsPath() => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string getFilePath(string fileName) => Path.Combine(getDocsPath(), fileName);

        public Task<bool> existsAsync(string fileName)
        {
            filePath = getFilePath(fileName);

            bool exists = File.Exists(filePath);
            return Task<bool>.FromResult(exists);
        }

        public async Task<string> loadTextAsync(string fileName)
        {
            filePath = getFilePath(fileName);

            using (StreamReader reader = File.OpenText(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task saveTextAsync(string fileName, string text)
        {
            filePath = getFilePath(fileName);

            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(text);
            }
        }
    }
}
