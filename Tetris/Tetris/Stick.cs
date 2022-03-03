using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Stick : Figure
    {
        
        public Stick(int x, int y, char sym)
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x, y + 1, sym);
            points[2] = new Point(x, y + 2, sym);
            points[3] = new Point(x, y + 3, sym);
            Draw();
        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
            {
                SetHorizontal();
            }
            else
            {
                SetVertical();
            }
        }

        private void SetVertical()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y + i;
                points[i].x = points[0].x;
            }
           
        }

        private void SetHorizontal()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }
    }
}
