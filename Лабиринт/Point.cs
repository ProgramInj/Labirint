using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабиринт
{
    class Point
    {
        public int dl { get; set; }
        public int shir { get; set; }

        public Point(int a, int b)
        {
            this.dl = a;
            this.shir = b;
        }

        public void StrRight()
        {
            var tmp = this.dl;
            this.dl = this.shir * -1;
            this.shir = tmp;
        }

        public void StrLeft()
        {
            var tmp = this.dl;
            this.dl = this.shir;
            this.shir = tmp * -1;
        }
    }
}
