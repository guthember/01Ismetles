using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Ismetles
{
    class Program
    {
        static void Main()
        {
            Random vel = new Random();
            string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };

            int gepValasz = vel.Next(0, 3 );

            Console.WriteLine("Gép választása: {0}", lehetoseg[gepValasz]);


            Console.ReadKey();
        }
    }
}
