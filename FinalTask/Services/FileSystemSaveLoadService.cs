using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Services
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _savePath;

        public FileSystemSaveLoadService(string path)
        {
            _savePath = path;
            Directory.CreateDirectory(path);
        }

        public void SaveData(string data, string fileName)
        {
            File.WriteAllText(Path.Combine(_savePath, $"{fileName}.txt"), data);
        }

        public string LoadData(string fileName)
        {
            return File.ReadAllText(Path.Combine(_savePath, $"{fileName}.txt"));
        }
    }
}
