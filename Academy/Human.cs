using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Human
	{
		string LastName { get; set; }
		string FirstName { get; set; }
		int Age { get; set; }

		public Human(string lastName, string firstName, int age) 
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
            //Console.WriteLine($"HConstructor:\t\t{this.GetHashCode()}");
        }

		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			//Console.WriteLine($"H Copy Constructor:\t{this.GetHashCode()}");
		}
		~Human() 
		{
            //Console.WriteLine($"HDestructor:\t\t{this.GetHashCode()}");
		}
		public override string ToString()
		{
			return $"{LastName} {FirstName} {Age}";
		}
		
		public virtual void Print()
		{
            Console.WriteLine(this.GetType());
            Console.WriteLine("LastName:\t" + LastName);
            Console.WriteLine("FirstName:\t" + FirstName);
            Console.WriteLine("Age:\t\t" + Age);
        }

		public virtual string Scan(ref string line)
		{
			int pos = line.IndexOf(": ");
			line = line.Substring(pos + 2);
			pos = line.IndexOf(" ");
			this.LastName = line.Substring(0, pos);
			line = line.Substring(pos + 1);
			pos = line.IndexOf(" ");
			this.FirstName = line.Substring(0, pos);
			line = line.Substring(pos + 1);
			pos = line.IndexOf(" ");
			this.Age = Convert.ToInt32(line.Substring(0, pos));
			return line;
		}
	}
}
