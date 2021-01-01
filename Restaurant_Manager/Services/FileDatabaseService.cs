using System;
using System.IO;
using Restaurant_Manager;

namespace Restaurant_Manager
{
   public class FileDatabaseService
    {
        private string filePath1, filePath2, filePath3;
        public FileDatabaseService()
        {
            filePath1 = Environment.CurrentDirectory + @"\" + Constants.fileName1;
            filePath2 = Environment.CurrentDirectory + @"\" + Constants.fileName2;
            filePath3 = Environment.CurrentDirectory + @"\" + Constants.fileName3;
        }
        public string[] ReadStock()
        {
            if (File.Exists(filePath1))
                return File.ReadAllLines(filePath1);
            else
                return null;
        }
        public string[] ReadMenu()
        {
            if (File.Exists(filePath2))
                return File.ReadAllLines(filePath2);
            else
                return null;
        }
        public string[] ReadOrders()
        {
            if (File.Exists(filePath3))
                return File.ReadAllLines(filePath3);
            else
                return null;
        }
        public void UpdateFile1(string data)
        {
            File.WriteAllText(filePath1, data);
        }
        public void UpdateFile2(string data)
        {
            File.WriteAllText(filePath2, data);
        }
        public void UpdateFile3(string data)
        {
            File.WriteAllText(filePath3, data);
        }
    }
}
