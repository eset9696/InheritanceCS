using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
    internal class Square : Rectangle
    {
        double side;

        public double Side
        { 
            get { return side; } 
            set 
            {  
                if(value < MIN_SIZE) value = MIN_SIZE;
                if(value >  MAX_SIZE) value = MAX_SIZE; 
                side = value; 
            } 
        }

        public Square(double side, int start_x, int start_y, int line_width, Color color) : base(side, side, start_x, start_y, line_width, color)
        {
            Side = side;
        }

        public override double GetArea()
        {
            return Math.Pow(Side, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }

        public override void Draw(PaintEventArgs e)
        {
            base.Draw(e);
        }

        public override void Info(PaintEventArgs e)
        {
            base.Info(e);
        }
    }
}
