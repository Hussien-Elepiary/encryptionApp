using System;
using System.IO;
namespace IncreptionTask
{
    class KeyGenerator
    {
         static string KeyGen(string fileName)
        {
            char[] text =  Inc_DecData.FileData(fileName).ToCharArray();
            char[] Extension = ".Hussien".ToCharArray();
            char[] path = fileName.ToCharArray();

            Random random = new Random();
            int randomNumber = random.Next(0, Extension.Length);
            string Key = $"({Convert.ToString(text[randomNumber])}{Convert.ToString(text[randomNumber])}{Convert.ToString(Extension[randomNumber])}{Convert.ToString(path[randomNumber])}.hussien)";
            return Key;
        }
        public static void KeySaveFile()
        {   
            string key = KeyGen(FileOprations.TxtFiles()[RandomNumber()]);
            File.WriteAllText("hussien.e", key);
        }
        private static int RandomNumber() 
        {
            Random random = new Random();
            int randomNumber = random.Next(0, FileOprations.TxtFiles().Length);
            return randomNumber;
        }
        public static string GetKeyFromKeyFile()
        {
            string key = File.ReadAllText("hussien.e");
            return key;
        }
    }
}
 