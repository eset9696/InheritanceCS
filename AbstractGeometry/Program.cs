using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
			//Rectangle rect = new Rectangle(200, 150, 100, 100, 5, Color.AliceBlue);
			//rect.Info(e);
			/*Ellipse el = new Ellipse(200, 200, 100, 150, 5, Color.Red);
			el.Info(e);*/

			Triangle triangle = new Triangle(150, 200, 150, 100, 150, 5, Color.Green);
			triangle.Info(e);
		}
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
