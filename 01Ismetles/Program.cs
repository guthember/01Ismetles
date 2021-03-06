﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01Ismetles
{
    class Program
    {
        static string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };

        static int gepNyer = 0;
        static int jatekosNyer = 0;
        static int menet = 0;

        static int GepValasztas() 
        {
            Random vel = new Random();
            return vel.Next(0, 3);
        }

        static int JatekosValasztas()
        {
            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válassz: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void EredmenyKiiras(int gep, int ember)
        {
            Console.WriteLine("Gép: {0} --- Játékos: {1}",
                                lehetoseg[gep], lehetoseg[ember]
                    );

            switch (EmberNyer(gep, ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen!");
                    break;
                case 1:
                    Console.WriteLine("Skynet nyert!");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert!");
                    break;
            }
        }

        static int EmberNyer(int gep, int ember)
        {
            if (ember == gep) 
            {
                return 0; // Döntetlen
            }
            else if (
                        (ember == 0 && gep == 1)
                        ||
                        (ember == 1 && gep == 2)
                        ||
                        (ember == 2 && gep == 0)
                    ) 
            {
                gepNyer++;
                return 1; // Gép nyer
            }
            else 
            {
                jatekosNyer++;
                return 2; // Játékos nyer
            }
        }

        private static bool AkarJatszani()
        {
            Console.WriteLine("----------------------------");
            Console.Write("Tovább? [i/n]:");
            string valasz = Console.ReadLine().ToLower();
            Console.WriteLine("\n----------------------------");

            if (valasz == "i")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static void StatisztikaFajlba()
        {
            string adat = menet.ToString() + ";" +
                            jatekosNyer.ToString() + ";" +
                            gepNyer.ToString();
            //FileStream ki = new FileStream("statisztika.txt", FileMode.Append);
            StreamWriter sKi = new StreamWriter("statisztika.txt", true);
            sKi.WriteLine(adat);
            sKi.Close();
        }

        private static void StatisztikaFajlbol()
        {
            StreamReader stat = new StreamReader("statisztika.txt");
            Console.WriteLine("---->  Statisztika   <-----");
            Console.WriteLine("| Menet | Játékos |  Gép  |");
            Console.WriteLine("---------------------------");
            while (!stat.EndOfStream)
            {
                string[] szovegAdat = stat.ReadLine().Split(';');
                int[] adat = new int[3];

                for (int i = 0; i < adat.Length; i++)
                {
                    adat[i] = int.Parse(szovegAdat[i]);
                }
                Console.WriteLine("|    {0,2} |     {1,2}  |    {2,2} |",
                    adat[0], adat[1], adat[2]);
                Console.WriteLine("---------------------------");
            }

            stat.Close();

            Console.WriteLine("---->Statisztika vége<-----");
            Console.WriteLine("\nBármilyen billentyűre tovább...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void StatisztikaKiiras()
        {
            Console.WriteLine(" Menetek száma: {0}" +
                "\tJátékos győzelmémek száma: {1}" +
                "\tGép győzelmének száma: {2}", menet, jatekosNyer, gepNyer);
        }

        static void Main()
        {
            StatisztikaFajlbol();

            bool tovabb = true;
            while (tovabb)
            {
                menet++;
                int gepValasz = GepValasztas();
                int jatekosValasz = JatekosValasztas();
                EredmenyKiiras(gepValasz, jatekosValasz);
                tovabb = AkarJatszani();
            }

            StatisztikaKiiras();
            StatisztikaFajlba();
            Console.ReadKey();
        }

    }
}
