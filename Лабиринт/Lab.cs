using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабиринт
{
    class Lab
    {
        public Cell[,] arr;
        public int size = 0;


        public Lab(int count_cell)
        {
            this.size = count_cell * 2 + 1;
            arr = new Cell[count_cell * 2 + 1, count_cell * 2 + 1];
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    arr[i, j] = new Cell();
                }
            }
        }

        public string Shifr_Cells()
        {
            string a = "";
            string result = "";
            int n1 = 0;
            int n2 = 0;
            for (int i = 0; i < size; i++)
            {
                result = "";
                n2 = 0;
                bool f = false;
                for (int j = 0; j < size; j++)
                {
                    if (arr[i, j] != null && (!arr[i, j].Encrypt().Equals("f") || f))
                    {
                        result += arr[i, j].Encrypt();
                        f = true;
                        n2++;
                    }
                }

                if (result.Replace("f", "").Length == 0)
                {
                    result = "";
                }

                a += result;
                if (result.Length != 0)
                {
                    a += "\r\n";
                }

            }

            List<string> list_qwas = a.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string str = "";
            foreach (var num in list_qwas)
            {
                str += new String(num.Reverse()
                             .SkipWhile(x => x == 'f')
                             .Reverse()
                             .ToArray()
                             );
                str += "\r\n";
            }
            return str;
        }
    }
}
