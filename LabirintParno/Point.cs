using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Point
    {
        public int dl { get; set; }
        public int shir { get; set; }

        public Point(int new_x, int new_y)
        {
            this.dl = new_x;
            this.shir = new_y;
        }

        public void ToTheRight()
        {
            var tmp = this.dl;
            this.dl = this.shir * -1;
            this.shir = tmp;
        }

        public void ToTheLeft()
        {
            var tmp = this.dl;
            this.dl = this.shir;
            this.shir = tmp * -1;
        }
    }
}