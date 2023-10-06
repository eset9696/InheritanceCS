using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	internal class Teacher : Human
	{
		public string Speciality { get; set; }

		public int Experience { get; set; }

		public Teacher(string lastName, string firstName, int age, string speciality, int experience): base(lastName, firstName, age)
		{
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"TConstructor:\t{this.GetHashCode()}");
		}

		public Teacher(Human human, string speciality, int experience) : base(human)
		{
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"TConstructor:\t{this.GetHashCode()}");
		}

		public Teacher(Teacher other): base(other)
		{
			this.Speciality = other.Speciality;
			this.Experience = other.Experience;
			Console.WriteLine($"TCopyConstructor:\t{this.GetHashCode()}");
		}

		~Teacher() 
		{
			Console.WriteLine($"TDestructor:\t{this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Speciality} {Experience}";
		}

		public override void Print()
		{
			base.Print();
			Console.WriteLine("Speciality:\t" + Speciality);
			Console.WriteLine("Experience:\t" + Experience);
		}

		/*public override void Save(string path)
		{
			StreamWriter writer = new StreamWriter(path, false);
			writer.WriteLine(this);
			writer.Close();
		}*/
	}
}
