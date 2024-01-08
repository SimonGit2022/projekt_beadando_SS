using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Path_to_Argon___Beta_v._2._0
{
    internal class Jatekos : Karakterek
    {
        public string NEV { get; set; }
        private string NEM { get; set; }
        private string KEPPESEG { get; set; }
        public int GYOGYITAS = 0;

        private readonly string[] nevek = new string[4] { "Guest001", "Guest002", "Guest003", "Guest004" };
        private readonly string[] nemek = new string[2] { "Férfi", "Nő" };
        private readonly string[] keppesegek = new string[4] { "Alkimista", "Varázsló", "Zsoldos", "Paraszt" };
        public Jatekos()
        {
            Generate_player();
        }
        public Jatekos(string nev, string nem, string keppeseg){
            NEV = nev;
            NEM = nem;
            KEPPESEG = keppeseg;
        }
        public void Generate_player()
        {
            int nev_valaszt = Random(0, nevek.Length);
            int nem_valaszt = Random(0, nemek.Length);
            int keppesegek_valaszt = Random(0, keppesegek.Length);

            NEV = nevek[nev_valaszt];
            NEM = nemek[nem_valaszt];
            KEPPESEG = keppesegek[keppesegek_valaszt];
            GetKeppeseg(KEPPESEG);
        }
        public void GetKeppeseg(string keppeseg)
        {
            while (true)
            {
                if (keppeseg == "Alkimista")
                {
                    SetEletero(100);
                    SetHarciero(35);
                    break;
                }
                else if (keppeseg == "Varázsló")
                {
                    SetEletero(100);
                    SetHarciero(60);
                    break;
                }
                else if (keppeseg == "Zsoldos")
                {
                    SetEletero(100);
                    SetHarciero(70);
                    break;
                }
                else if (keppeseg == "Paraszt")
                {
                    SetEletero(100);
                    SetHarciero(80);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hibás, bemenet!");
                    Console.Write("Képpeségek:\n\t-Varázsló\n\t-Alkimista\n\t-Zsoldos\n\t-Paraszt\nBekérés:");
                    keppeseg = Console.ReadLine();
                }

            }
        }
    }
}
