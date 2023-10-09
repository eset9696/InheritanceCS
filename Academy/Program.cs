//#define WRITE_TO_FILE
#define READ_FROM_FILE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Academy
{
	internal class Program
	{
		public static readonly string delimeter = "\n------------------------------------------------------------\n";
		static void Main(string[] args)
		{
			Directory.SetCurrentDirectory("..\\..");
			string currentDirectory = Directory.GetCurrentDirectory();
#if WRITE_TO_FILE
			Human human = new Human("Vercetty", "Tommy", 30);
			//Console.WriteLine(human);
			//Console.WriteLine(delimeter);

			Student student = new Student("Pinkman", "Jassie", 25, "Chemistry", "WW_220", 90, 99);
			//Console.WriteLine(student);
			//Console.WriteLine(delimeter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			//Console.WriteLine(teacher);
			//Console.WriteLine(delimeter);

			Graduate graduate = new Graduate("Schrader", "Hank", 40, "Criminalistic", "OBN", 80, 70, "\"How to catch Heisenberg\"");
			//Console.WriteLine(graduate);
			//Console.WriteLine(delimeter);

			Student tommy = new Student(human, "Theft", "Vice", 70, 60);
			//Console.WriteLine(tommy);
			//Console.WriteLine(delimeter);

			Console.WriteLine(delimeter);

			Human[] group = new Human[] { student, teacher, graduate, tommy, new Teacher("Diaz", "Ricardo", 50, "Weaopons distribution", 20),
			new Graduate("Rosenberg", "Ken", 35, "Lower", "Vide", 44, 22, "\"Get money back\"")};
			/*for (int i = 0; i < group.Length; i++)
			{
				group[i].Print();
				Console.WriteLine(delimeter);
			}*/

			string filename = "group.txt";
			Console.WriteLine(delimeter);
			Save(group, filename);

			Human[] group1 = Load(filename);
			for (int i = 0; i < group1.Length; i++)
			{
				group1[i].Print();
                Console.WriteLine(delimeter);
			}
			Console.WriteLine(delimeter);
#endif
			Human[] group = Load("group.txt");
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]); ;
                Console.WriteLine(delimeter);
            }
		}

		public static void Save(Human[] human, string filename)
		{
			//Directory.SetCurrentDirectory("..\\..");
			//string currentDirectory = Directory.GetCurrentDirectory();
			StreamWriter writer = new StreamWriter(filename, false);
			for (int i = 0;i < human.Length;i++)
			{
				writer.WriteLine($"{human[i].GetType()}: {human[i]}");
			}
			writer.Close();
			string cmd = $"{filename}";
			System.Diagnostics.Process.Start(cmd);
		}

		public static Human HumanFactory(string type) 
		{
			Human human = null;
			if (type == typeof(Academy.Human).ToString()) human =  new Human("", "", 0);
			else if (type == typeof(Academy.Student).ToString()) human =  new Student("", "", 0, "", "", 0, 0);
			else if (type == typeof(Academy.Teacher).ToString()) human = new Teacher("", "", 0, "", 0);
			else if (type == typeof(Academy.Graduate).ToString()) human = new Graduate("", "", 0, "", "", 0, 0, "");
			return human;
		}

		public static Human[] Load(string filename) 
		{
			
			List<Human> group = new List<Human>();
			StreamReader sr = new StreamReader(filename);
			while(!sr.EndOfStream) 
			{
				string buffer = sr.ReadLine();
				string[] values = buffer.Split(':', ',');
				group.Add(HumanFactory(values[0]));
				group.Last().Init(values);
			}
			sr.Close();
			return group.ToArray();
		}
	}

}
