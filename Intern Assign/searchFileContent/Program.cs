using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace searchFileContent
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath;
          
  label:    Console.WriteLine("\nEnter name of the directory: ");
            dirPath = Console.ReadLine();

            //Directory Path validation
            if (Directory.Exists(dirPath))
            {
                string[] temp = Directory.GetDirectories(dirPath);
                if (temp.Length == 0)
                    lookUp.searchFiles(dirPath);
                else
                    lookUp.searchDir(dirPath);
            }
            else
            {
                Console.WriteLine("Path Invalid. Kindly Re-enter path.");
                goto label;
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}

//A class to look sub-directoires within specified directory using recursion
class lookUp
{
    public static void searchDir(string dirPath)
    {
        try
        {
            //recursively iterating through directories
            foreach(string subDir in Directory.GetDirectories(dirPath))
            {
                //getting the specified file 
                foreach(string file in Directory.GetFiles(subDir, "*.txt"))
                {
                    readFile.fileContent(file);
                    Console.WriteLine(file);
                }
                searchDir(subDir);
            }
        }
        catch(System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void searchFiles(string dirPath)
    {
        foreach (string file in Directory.GetFiles(dirPath, "*.txt"))
        {
            readFile.fileContent(file);
        }
    }
 }

class readFile
{
    public static void fileContent(string fileName)
    {
      
        Regex mobileNumber = new Regex(@"^[789]*\d{9}");
        foreach (string number in File.ReadLines(fileName))
        {
            Match match = mobileNumber.Match(number);
            if (match.Success)
                Console.WriteLine(match);
            else
                continue;
        }
    }
}
