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

			Human[] group = new Human[] { student, teacher, graduate, tommy, new Teacher("Diaz", "Ricardo", 50, "Weaopons_distribution", 20) };
			for (int i = 0; i < group.Length; i++)
			{
				group[i].Print();
				Console.WriteLine(delimeter);
			}
			Console.WriteLine(delimeter);
			Save(group, "Human.txt");
			int size = 0;
			Human[] group1 = Load("Human.txt", ref size);
			Console.WriteLine(delimeter);
			for (int i = 0; i < size; i++)
			{
				group1[i].Print();
				Console.WriteLine(delimeter);
			}
		}

		public static void Save(Human[] human, string path)
		{
			StreamWriter writer = new StreamWriter(path, false);
			for (int i = 0;i < human.Length;i++)
			{
				writer.WriteLine($"Class {human[i].GetType()}: {human[i]}");
			}
			writer.Close();
		}

		public static Human Factory(string type) 
		{
			if (type.Contains("Class Academy.Human:")) return new Human("", "", 0);
			else if (type.Contains("Class Academy.Student:")) return new Student("", "", 0, "", "", 0, 0);
			else if (type.Contains("Class Academy.Teacher:")) return new Teacher("", "", 0, "", 0);
			else if (type.Contains("Class Academy.Graduate:")) return new Graduate("", "", 0, "", "", 0, 0, "");
			return null;
		}

		public static Human[] Load(string path, ref int size) 
		{
			StreamReader reader = new StreamReader(path);
			string line;
			for (size = 0; (line = reader.ReadLine()) != null; size++);
			reader.BaseStream.Seek(0, SeekOrigin.Begin);
			Human [] result = new Human[size];
			for (int i = 0; i < size; i++)
			{
				line = reader.ReadLine();
				result[i] = Factory(line);
				if (result[i] != null) result[i].Scan(ref line);
			}
			reader.Close();
			return result;
		}
	}

}
