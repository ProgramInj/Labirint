using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабиринт
{
    class Cell
    {
        public bool topWall = true;
        public bool bottomWall = true;
        public bool leftWall = true;
        public bool rightWall = true;
        public int condition = 0;

        public string Encrypt()
        {
            var s = "0123456789abcdefgh";
            int enc_idx = 0;
            if (rightWall)
                enc_idx += 8;
            if (leftWall)
                enc_idx += 4;
            if (bottomWall)
                enc_idx += 2;
            if (topWall)
                enc_idx += 1;

            return s[enc_idx].ToString();
        }
    }
}
