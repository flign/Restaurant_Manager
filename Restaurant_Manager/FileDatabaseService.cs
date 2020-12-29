using System;
using System.IO;
using Restaurant_Manager;

namespace Restaurant_Manager
{
   public class FileDatabaseService
    {
        private string filePath;
        public FileDatabaseService()
        {
            filePath = Environment.CurrentDirectory + @"\" + Constants.fileName1;
        }
        public string[] ReadStock()
        {
            if (File.Exists(filePath))
                return File.ReadAllLines(filePath);
            else
                return null;
        }

        public void UpdateFile(string data)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
