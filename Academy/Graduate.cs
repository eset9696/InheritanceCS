using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy
{
	internal class Graduate : Student
	{
		public string Subject { get; set; }

		public Graduate
			(
			string lastName, string firstName, int age,
			string speciality, string group, double raiting, double attendance, string subject
			)
			: base(lastName, firstName, age, speciality, group, raiting, attendance)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:\t{this.GetHashCode()}");
		}

		public Graduate(Student student, string subject) : base(student)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:\t{this.GetHashCode()}");
		}

		public Graduate(Graduate other) : base(other)
		{
			this.Subject = other.Subject;
			Console.WriteLine($"GCopyConstructor:\t{this.GetHashCode()}");
		}

		~Graduate() 
		{
			Console.WriteLine($"GDestructor:\t{this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Subject}";
		}

		public override void Print()
		{
			base.Print();
			Console.WriteLine("Subject:\t" + Subject);
		}
	}
}
