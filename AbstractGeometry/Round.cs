using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
    internal class Round : Ellipse
    {
        double radius;

        public double Radius
        { get { return radius; }
            set 
            {
                if(value < MIN_SIZE) value = MIN_SIZE;
                if(value > MAX_SIZE) value = MAX_SIZE;
                radius = value; 
            }
        }
        public Round(double radius, int start_x, int start_y, int line_width, Color color) 
            : base(radius, radius, start_x, start_y, line_width, color)
        {
            Radius = radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override void Draw(PaintEventArgs e)
        {
            base.Draw(e);
        }

        public override void Info(PaintEventArgs e) 
        {
            Console.WriteLine($"Радиус круга равен: {Radius}");
            base.Info(e);
        }
    }
}
