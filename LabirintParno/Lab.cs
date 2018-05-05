using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab
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
            string ans = "";
            string res = "";
            int len_i = 0;
            int len_j = 0;
            for (int i = 0; i < size; i++)
            {
                res = "";
                len_j = 0;
                bool f = false;
                for (int j = 0; j < size; j++)
                {
                    if (arr[i, j] != null && (!arr[i,j].Shifr().Equals("f") || f ) )
                    {
                        res += arr[i, j].Shifr();
                        f = true;
                        len_j++;
                    }
                }

                if (res.Replace("f", "").Length == 0)
                {
                    res = "";
                }

                ans += res;
                if (res.Length != 0)
                {
                    ans += "\r\n";
                }
                
            }

            List<string> list_new_ans = ans.Split(new char[] { '\r','\n'},StringSplitOptions.RemoveEmptyEntries).ToList();
            string new_ans = "";
            foreach (var el in list_new_ans)
            {
                new_ans += new String(el.Reverse()
                             .SkipWhile(x=> x =='f')
                             .Reverse()
                             .ToArray()
                             );
                new_ans += "\r\n";
            }
            return new_ans;
        }
    }
}