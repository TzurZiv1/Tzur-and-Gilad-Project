using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class Ac
        {
            int a; int b;

            public int A { get => a; set => a = value; }
            public int B { get => b; set => b = value; }
             public Ac() { A = b = 2;  }
            public override string ToString()
            {
                return "a " + a + " b " + b   ; 
            }
        }
        static void Main(string[] args)
        {
            Ac v = new Ac { A = 1, B = 1 };
            Console.WriteLine(v  );
            Console.ReadKey();
        }
    }
}
