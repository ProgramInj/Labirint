using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class FileRead
    {
        

        public void Run(string size_test)
        {
            StreamReader reader = new StreamReader(size_test + "-test.in.txt");
            StreamWriter sw = new StreamWriter(size_test + "-test.out.txt");

            string[] splitN = { "\r\n" };
            int couStrFile = int.Parse(reader.ReadLine());

            var result = reader.ReadToEnd().Split(splitN, couStrFile, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(couStrFile);
            for (int j = 0; j < couStrFile; j++)
            {
                var enter = result[j].Split(' ')[0];
                var exit = result[j].Split(' ')[1];
                MainClass builder = new MainClass();
                builder.Generate(enter, exit);
                Console.WriteLine("Case #" + (j+1));
                Console.WriteLine(builder.GetLabEncryption());

                
                sw.WriteLine("Case #" + (j + 1));
                sw.WriteLine(builder.GetLabEncryption());
                
            }
            sw.Close();
            Console.ReadLine();
        }
    }
}