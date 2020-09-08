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

            int jatekosValasz;

            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válassz: ");
            jatekosValasz = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Játékos választása: {0}", lehetoseg[jatekosValasz]);



            Console.ReadKey();
        }
    }
}
