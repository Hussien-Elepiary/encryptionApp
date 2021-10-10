using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IncreptionTask
{
    class FileOprations
    {
        public static string[] TxtFiles() 
        {
            DirectoryInfo direction = new DirectoryInfo(Environment.CurrentDirectory);
            string[] filePaths = (Directory.GetFiles($"{direction}\\", "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".Hussien") || s.EndsWith(".txt") )).ToArray();
            return filePaths;
        }
        public static string ArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }
        public static void DeleteKeyFile ()
        {
            File.Delete("hussien.e");
        }
        public static string AllDataFormAllFiles ()
        {
            string[] dataArr = new string[TxtFiles().Length];
            for (int i = 0; i < TxtFiles().Length; i++)
            {
                dataArr[i] = Inc_DecData.FileData(TxtFiles()[i]);
            }
            string allDataString = ArrayToString(dataArr);
            return allDataString;
        }
    }
}
