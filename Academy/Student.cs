using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Student: Human
	{
		public string Speciality { get; set; }
		public string Group { get; set; }
		public double Raiting { get; set; }
		public double Attendance { get; set; }

		public Student
			(
			string lastName, string firstName, int age, 
			string speciality, string group, double raiting, double attendance
			): base(lastName, firstName, age)
		{
			Speciality = speciality;
			Group = group;
			Raiting = raiting;
			Attendance = attendance;
			Console.WriteLine($"SConstructor:\t{this.GetHashCode()}");
		}

		public Student(Human human, string speciality, string group, double raiting, double attendance) : base(human)
		{
			Speciality = speciality;
			Group = group;
			Raiting = raiting;
			Attendance = attendance;
			Console.WriteLine($"SConstructor:\t{this.GetHashCode()}");
		}

		public Student(Student other) : base(other)
		{
			this.Speciality = other.Speciality;
			this.Group = other.Group;
			this.Raiting = other.Raiting;
			this.Attendance = other.Attendance;
			Console.WriteLine($"SCopyConstructor:\t{this.GetHashCode()}");
		}
		~Student() 
		{ 
			Console.WriteLine($"SDestructor:\t{this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Speciality} {Group} {Raiting} {Attendance}";
		}

		public override void Print()
		{
			base.Print() ;
			Console.WriteLine("Speciality:\t" + Speciality);
			Console.WriteLine("Group:\t" + Group);
			Console.WriteLine("Raiting:\t\t" + Raiting);
			Console.WriteLine("Attendance:\t\t" + Attendance);
		}
	}
}
