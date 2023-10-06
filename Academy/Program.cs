using System;
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

			Human[] group = new Human[] { student, teacher, graduate, tommy, new Teacher("Diaz", "Ricardo", 50, "Weaopons distribution", 20) };
			for (int i = 0; i < group.Length; i++)
			{
				group[i].Print();
				Console.WriteLine(delimeter);
			}
			Console.WriteLine(delimeter);
			Save(group, "Human.txt");
			Console.WriteLine(delimeter);
		}

		public static void Save(Human[] human, string path)
		{
			StreamWriter writer = new StreamWriter(path, false);
			for (int i = 0;i < human.Length;i++)
			{
				writer.WriteLine(human[i].GetType() + " " + human[i]);

			}
			writer.Close();
		}
	}
}
