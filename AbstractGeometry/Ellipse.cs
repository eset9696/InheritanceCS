using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;
using System.Security.Policy;

namespace AbstractGeometry
{
	internal class Ellipse : Shape
	{

		double radius_a;
		double radius_b;
		public double RadiusA
		{
			get { return radius_a; }
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				radius_a = value;
			}
		}

		public double RadiusB
		{
			get { return radius_b; }
			set
			{
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				radius_b = value;
			}
		}

		public Ellipse(double radius_a, double radius_b, int start_x, int start_y, int line_width, Color color) : base(start_x, start_y, line_width, color)
		{
			RadiusA = radius_a;
			RadiusB = radius_b;
		}

		public override double GetArea()
		{
			return Math.PI * radius_a * radius_b;
		}

		public override double GetPerimeter()
		{
			return Math.PI * Math.Sqrt(2 * (Math.Pow(radius_a, 2) + Math.Pow(radius_b, 2)));
		}

		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (int)RadiusA, (int)RadiusB);
		}

		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Длина полуоси А: {RadiusA}");
			Console.WriteLine($"Длина полуоси Б: {RadiusB}");
			base.Info(e);
		}
	}
}
