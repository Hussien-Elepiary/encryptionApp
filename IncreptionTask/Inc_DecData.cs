using System;
using System.IO;
using System.Text;

namespace IncreptionTask
{
    class Inc_DecData
    {
        public static string DecrebtedData(string fileName)
        {
            string fileData = FileData(fileName);
            fileData = fileData.Replace(KeyGenerator.GetKeyFromKeyFile(), " ");
            byte[] bytes = Encoding.ASCII.GetBytes(fileData);

            int CountForCTB = 0;

            foreach (var item in bytes)
            {
                bytes[CountForCTB] = Convert.ToByte((item) - 1);
                CountForCTB++;
            }
            fileData = Encoding.ASCII.GetString(bytes);
            string DecrebtedText = new string(fileData);
            return DecrebtedText;
        }
        public static string IncrebtedData(string fileName)
        {
            string fileData = FileData(fileName);
         
            byte[] bytes = Encoding.ASCII.GetBytes(fileData);
         
            int CountForCTB = 0;
          
            foreach (var item in bytes)
            {
                bytes[CountForCTB] = Convert.ToByte((item) + 1);
                CountForCTB++;
            }
            fileData = Encoding.ASCII.GetString(bytes);
            string increbtedText = new string(fileData) + KeyGenerator.GetKeyFromKeyFile();
            
            return increbtedText;
        }
        public static string FileData(string fileName)
        {
                StreamReader reader = new StreamReader(fileName);
                string input = reader.ReadToEnd();
                reader.Close();
                return input;
        }
        public static void ChangeFileExtensionEnc (string path)
        {
            if (path.Contains(".Hussien") == false && FileData(path).Contains(KeyGenerator.GetKeyFromKeyFile()) == true)
            {
                string directoryDirection = path.Replace(Path.GetFileName(path), $"{Path.GetFileName(path)}.Hussien");
                File.Move(path, directoryDirection);
            }
            else if (path.Contains(".Hussien") == false && FileData(path).Contains(KeyGenerator.GetKeyFromKeyFile()) == false) 
            { 
                
            }
            else if (path.Contains(".Hussien") == true || FileData(path).Contains(KeyGenerator.GetKeyFromKeyFile()) == false)
            {
                string directoryDirection = path.Replace(Path.GetFileName(path), $"{Path.GetFileNameWithoutExtension(path)}");
                File.Move(path, directoryDirection);
            }
        }
    }
}
