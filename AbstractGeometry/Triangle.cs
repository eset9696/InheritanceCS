using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Triangle : Shape
	{
		double side_a;
		double side_b;
		double side_c;

		/*double altitude_a;
		double altitude_b;
		double altitude_c;*/

		public double SideA 
		{ 
			get { return side_a; }
			set 
			{
				if(value < MIN_SIZE) value = MIN_SIZE;
				if(value > MAX_SIZE) value = MAX_SIZE;
				side_a = value; 
			}
		}

		public double SideB
		{ 
			get { return side_b; }
			set 
			{
				if(value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				side_b = value;
			}
		}
		public double SideC
		{ 
			get { return side_c; } 
			set 
			{
				if (value > SideA + SideB) value = SideA + SideB - 1;
				if (value < MIN_SIZE) value = MIN_SIZE;
				if (value > MAX_SIZE) value = MAX_SIZE;
				side_c = value;
			} 
		}

		public Triangle(double side_a, double side_b, double side_c, int start_x, int start_y, int line_width, Color color) : base(start_x, start_y, line_width, color)
		{ 
			SideA = side_a;
			SideB = side_b;
			SideC = side_c;
		}

		public PointF[] GetPoints()
		{
			Point point_a = new Point(StartX, StartY);
			Point point_b = new Point(StartX + (int) GetAltitude(side_b), StartY + (int) (side_b - GetDistanceFromHtoVertex(GetAltitude(side_b), side_a)));
			Point point_c = new Point(StartX, StartY + (int)side_b);

			PointF[] points = new PointF[] { point_a, point_b, point_c };
			return points;
		}

		public override double GetPerimeter() 
		{
			return side_a + side_b + side_c;
		}

		public override double GetArea()
		{
			double half_per = GetPerimeter() / 2;
			return Math.Sqrt(half_per * (half_per - SideA) * (half_per - SideB) * (half_per - SideC));
		}

		public double GetAltitude(double side)
		{
			return 2 * GetArea() / side;
		}

		public double GetDistanceFromHtoVertex(double Altitude, double side)
		{
			return Math.Sqrt(Math.Pow(side, 2) - Math.Pow(Altitude, 2));
		}

		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawPolygon(pen, GetPoints());
		}

		public override void Info(PaintEventArgs e)
		{
            Console.WriteLine($"Стороны треугольника равны: a = {SideA}, b = {SideB}, c = {SideC}");
            Console.WriteLine($"Высоты треугольника равны: a = {GetAltitude(SideA)}, b = {GetAltitude(SideB)}, c = {GetAltitude(SideC)}");
            Console.WriteLine($"Высоты треугольника равны: a = {GetDistanceFromHtoVertex(GetAltitude(side_b), side_b)}");
            base.Info(e);
		}

	}
}
