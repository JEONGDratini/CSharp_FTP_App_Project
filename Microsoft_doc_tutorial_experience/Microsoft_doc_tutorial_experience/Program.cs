using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Microsoft_doc_tutorial_experience
{
    class Program
    {
        static void Main(string[] args)
        {
            // StreamWriter
            StreamWriter sw = new StreamWriter("a.txt");
            sw.Write("sw.Write()");
            sw.Write(" sw.Write()");
            sw.WriteLine(" sw.WriteLine()");
            sw.WriteLine("sw.WriteLine()");

            sw.Close();

            // StreamReader
            StreamReader sr = new StreamReader("a.txt");

            while (sr.Peek() >= 0)
            {
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            Console.ReadLine();
        }
    }
}
