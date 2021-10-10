using System;
using System.IO;

// this Class is For the program to Control every Class and to handle all errors and all technical Defficulitis 
// You can sy this is the hup of the Program it self 
namespace IncreptionTask
{
    class ProgramControler
    {
        public static void EncriptedFilesCheck()
        {
            string fileStringArray = FileOprations.ArrayToString(FileOprations.TxtFiles());
            if (KeyFileChecker() == true)
            {
                if (fileStringArray.Contains(".Hussien") == true || FileOprations.AllDataFormAllFiles().Contains(KeyGenerator.GetKeyFromKeyFile()) == true)
                {
                    Console.Write("Please Enter the Key: ");
                    string key = Console.ReadLine();
                    DecryptionRules(key);
                }
            }
            else if (fileStringArray.Contains(".Hussien") == false)
            {
                for (int i = 0; i < FileOprations.TxtFiles().Length; i++)
                {
                    Checker(FileOprations.TxtFiles()[i]);
                }
                Console.WriteLine("Done! Every File is Encrypted!");
                Console.ReadLine();
            }
        }
        static void DecryptionRules(string key)
        {
            if (RightKey(key) == true)
            {
                foreach (string path in FileOprations.TxtFiles())
                {
                    if (path.Contains(".Hussien") == true)
                    {
                        Checker(path);
                    }
                    else if (path.Contains(".Hussien") == false && KeyExsits(path) == true)
                    {
                        Checker(path);
                    }
                    else
                    {
                        //do nothing
                    }
                }
                FileOprations.DeleteKeyFile();
                Console.WriteLine("Done! Every File is Decrypted!");
                Console.ReadLine(); 
            }
            else
            {
                Program.Main();
            }
        }
        // this class it to handle and check for avrey thing first pefore deciding to Encrypt or Decrypt The File 
        //Checks if:
        //- The File That Contains the Folder is up 
        //- The File is Encrypt or Decrypt py chicking For the Key in it
        static void Checker(string fileName)
        {
            if (KeyFileChecker() == true)
            {
                KeyCheck(fileName);
            }
            else if (KeyFileChecker() == false)
            {
                KeyGenerator.KeySaveFile();
                Increbtion(fileName);
            }
            else
            {
                Environment.Exit(0);
            }
        }
        //this is the method to Chech if the Key is right or no
        static void KeyCheck(string fileName)
        {

            if (KeyExsits(fileName) == true)
            {
                
                
                Decrebtion(fileName);
            }
            else if (KeyExsits(fileName) == false)
            {
                Increbtion(fileName);
            }
            else
            {
                Environment.Exit(0);
            }
        }
        // Method to do Encryption path
        static void Increbtion(string fileName)
        {
            string input = Inc_DecData.FileData(fileName);
            string increbtedText = Inc_DecData.IncrebtedData(fileName);
            File.WriteAllText(fileName, File.ReadAllText(fileName).Replace(input, increbtedText));
            Inc_DecData.ChangeFileExtensionEnc(fileName);
        }
        // Method to do Decryption path
        static void Decrebtion(string fileName)
        {
            string input = Inc_DecData.FileData(fileName);
            string decrebtedText = Inc_DecData.DecrebtedData(fileName);
            File.WriteAllText(fileName, File.ReadAllText(fileName).Replace(input, decrebtedText));
            Inc_DecData.ChangeFileExtensionEnc(fileName);
        }
      
        // To check if the key is right
        static bool RightKey(string key)
        {
            if (key == KeyGenerator.GetKeyFromKeyFile())
            {
                return true;
            }
            else { Console.WriteLine("Wrong Key!"); return false; }
        }
        //Chechs For the File that contains the Key
        static bool KeyFileChecker()
        {
            if (File.Exists("hussien.e") == true)
            {
                return true;
            }
            else if (File.Exists("hussien.e") == false)
            {
                return false;
            }
            else 
            { 
               return false;
            } 
            
        }
        //Checks if The key is up
        static bool KeyExsits(string fileName)
        {
            string fileData = Inc_DecData.FileData(fileName);
            if (fileData.Contains(KeyGenerator.GetKeyFromKeyFile()) == true)
            {
                return true;
            }
            else if (fileData.Contains(KeyGenerator.GetKeyFromKeyFile()) == false)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
      
        
    }
} 