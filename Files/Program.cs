//#define WRITE_TO_FILE
#define READ_FROM_FILE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if WRITE_TO_FILE
			Directory.SetCurrentDirectory("..\\..");
			string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);
			string filename = "File.txt";
            StreamWriter sw = new StreamWriter(filename, append:true);
			sw.WriteLine("Hello world!");
			sw.Close();
			string cmd = $"{currentDirectory}\\{filename}";
			System.Diagnostics.Process.Start("notepad", cmd);
#endif
#if READ_FROM_FILE
			Directory.SetCurrentDirectory("..\\..");
			string filename = "File.txt";
			StreamReader sr = new StreamReader(filename);
			string line = sr.ReadToEnd();
            Console.WriteLine(line);
            sr.Close();

#endif
		}
	}
}
