using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRead mainApp = new FileRead();
            mainApp.Run("small");
            Console.WriteLine("\r\n");
            //mainApp.Run("large");
        }
    }
}