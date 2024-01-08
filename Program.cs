using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq.Expressions;

namespace Path_to_Argon___Beta_v._2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition((Console.WindowWidth - "Welcome in Path to Argon".Length) / 2, Console.CursorTop);//Középre igazítja a szöveget.
            Console.WriteLine("Welcome in Path to Argon");//Ezt, majd középre igazíthatom.
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition((Console.WindowWidth - "Welcome in Path to Argon".Length) / 2, Console.CursorTop);//Középre igazíja a szöveget.
            Console.WriteLine("------------------------");//Ezt, majd középre igazíthatom.
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition((Console.WindowWidth - "BETA Version2.0".Length) / 2, Console.CursorTop);//Középre igazíja a szöveget.
            Console.WriteLine("BETA Version2.0");
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine();
            Console.WriteLine("\t-Háttér: Wilinberger országát, nagy veszedelem fenyegeti és te megprobálsz eljutni a birodalom " +
                "királyához aki, Argon városában él.\n\tA közelgő veszély miatt el is indulsz a királyhoz ,hogy szerencsét probálj viszont, " +
                "az Argonba vezető út legfejebb tíz napba kerül és azalatt sok fajta veszély le selkedik rád.");
            Console.Write("Készen állsz?(ENTER/EXIT)");
            string create = Console.ReadLine();
            while (true)
            {
                if (create.ToUpper() == "ENTER" || create == "")//A jatékba való, belépés.
                {
                    try
                    {
                        Harc harc = new Harc();
                        harc.Napok();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Valami baj van..: {ex.Message}");
                        break;
                    }
                }
                else if (create.ToUpper() == "EXIT")
                {
                    Console.WriteLine("A játék elhagyása....");
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hibás, bemenetet adott meg!");
                    Console.Write("Készen állsz?(ENTER/EXIT)");
                    create = Console.ReadLine();
                }
            }
            
        }
    }
}