using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_to_Argon___Beta_v._2._0
{
    internal class Harc: Random
    {
        protected readonly string[] ellensegek_nevei = { "Örült favágó", "Barbárok", "Dalnok", "Kovács", "Mike a gomba", "Kereskedő", "Szekta", "Boszorkány", "Főszekta", "Sárkány" };
        //Az ellenséges karakterek nevei.
        private readonly int elixir_ar = 50;
        private int nap = 1;
        public void Sebzes(Karakterek ellenseg, Jatekos jatekos, string taktika)
        {
            while (true) {
                if (Vedekezes() != 0 && taktika.ToLower() == "védekezés")
                {
                    int ellenseg_eletero = ellenseg.GetEletero();
                    int jatekos_eletero = jatekos.GetEletero() - 2;
                    int vedekezes_sebzese = Random(1,21);
                    ellenseg.SetEletero(ellenseg_eletero - vedekezes_sebzese);
                    jatekos.SetEletero(jatekos_eletero);
                    break;
                }
                else if(taktika.ToLower() == "támadás")
                {
                    int ellenseg_tamadas = ellenseg.GetHarciero();
                    int jatekos_tamadas = jatekos.GetHarciero();

                    int ellenseg_eletero = ellenseg.GetEletero() - jatekos_tamadas;
                    int jatekos_eletero = jatekos.GetEletero() - ellenseg_tamadas;

                    ellenseg.SetEletero(ellenseg_eletero);
                    jatekos.SetEletero(jatekos_eletero);
                    break;
                }
                else 
                {
                    Console.WriteLine("Hibás bemenet!");
                    Console.Write("Támadsz vagy védekezel (Támadás/Védekezés):");
                    taktika = Console.ReadLine();
                }
            }
        }
        public Karakterek GenerateEllenseg()
        {
            Karakterek ellenseg = new Karakterek();
            if (nap<4)
            {
                ellenseg.SetEletero(100);
                ellenseg.SetHarciero(Random(20,36));
                ellenseg.SetPenz(Random(70,86));
                ellenseg.SetPontszam(Random(800,1501));
                return ellenseg;
            }
            else if (nap!=10)
            {
                ellenseg.SetEletero(150);
                ellenseg.SetHarciero(Random(50,66));
                ellenseg.SetPenz(Random(70, 86));
                ellenseg.SetPontszam(Random(800, 1501));
                return ellenseg;
            }
            else
            {
                ellenseg.SetEletero(250);
                ellenseg.SetHarciero(Random(70,86));
                ellenseg.SetPenz(500);
                ellenseg.SetPontszam(2000);
                return ellenseg;
            }
        }
        public int Vedekezes()
        {
            int vedekezes = Random(1,3);//Egy véletlen számú pontszámot generál a védekezésnek.
            return vedekezes;
        }
        public void Gyogyitas(Jatekos jatekos)
        {
            //A jatekos, gyógyíthatja magát, ha van neki elxirje, de akár nélkülözheti is.
            if (jatekos.GYOGYITAS!=0) 
            {
                //Bemenetet kér 
                Console.WriteLine($"A játékos életereje:{jatekos.GetEletero()}");
                Console.Write("Szeretne gyógyítani (IGEN,NEM):");
                string input = Console.ReadLine();
                if (input.ToUpper() == "IGEN")
                {
                    jatekos.SetEletero(100);
                    jatekos.GYOGYITAS = jatekos.GYOGYITAS - 1;
                }
                else if(input.ToUpper() == "NEM")
                {
                    Console.WriteLine("Nem használtad az elixirt!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hibás bemenet!");

                    input = Console.ReadLine();
                }
            }
        }
        //Itt, futatjuk, le a harcot, a 10 naponta megjelenő ellenséggel szemben.
        public void Napok()
        {

            Console.Write("Saját készítésű vagy véletlenszerű karakter (OWN, AUTOMATED - any key):");
            Jatekos jatekos; //A játékos objektumot, itt lesz leképezve.
            //Két, fajta modón csinálhatsz, játékost...: Saját, kezűleg vagy automatikusan.
            string valaszt = Console.ReadLine();
            if (valaszt.ToUpper() == "OWN")
            {
                Console.Write("Név:");
                string nev = Console.ReadLine();
                Console.Write("Nem:");
                string nem = Console.ReadLine();
                Console.Write("Képpeségek:\n\t-Varázsló\n\t-Alkimista\n\t-Zsoldos\n\t-Paraszt\nBekérés:");
                string keppeseg = Console.ReadLine();
                jatekos = new Jatekos();
                jatekos.GetKeppeseg(keppeseg);
            }
            else
            {
                jatekos = new Jatekos();
            }
            do
            {
                Karakterek ellenseg = GenerateEllenseg();
                Console.WriteLine($"\t{nap}.nap: {ellensegek_nevei[nap - 1]}");
                Console.WriteLine();
                int osszesElixir = jatekos.GYOGYITAS;
                while (ellenseg.GetEletero()>0 && jatekos.GetEletero()>0)//A ciklus, aktív még egy valaki megnem hal.
                {
                    //Eltárolja, a játkos által összedett, elixireket, ha elvesztené a csatát.
                    Console.WriteLine($"A játékos életereje:{jatekos.GetEletero()}");
                    Console.WriteLine($"A karakter életerje: {ellenseg.GetEletero()}");
                    Console.WriteLine();
                    Console.Write("Támadsz vagy védekezel (Támadás/Védekezés):");
                    string taktika = Console.ReadLine();
                    Sebzes(ellenseg, jatekos, taktika);
                    if (ellenseg.GetEletero() > 0 && jatekos.GetEletero() > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Gyógyító elixir: {jatekos.GYOGYITAS}");
                        Console.WriteLine();
                        Gyogyitas(jatekos);
                    }
                }
                if (jatekos.GetEletero()>0 && ellenseg.GetEletero()<=0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Legyőzted a {ellensegek_nevei[nap - 1]}");
                    nap++;
                    Lada(jatekos, ellenseg);// A játékos objektum harci tulajdonságait, fejleszti.
                    Vasarlas(jatekos);// Növelheti, a játékos GYOGYITAS adattaghoz.
                }
                else
                {
                    Console.WriteLine("Elvesztetted a csatát!");//Újra, índitja a csatát!
                    jatekos.SetEletero(100);
                    ellenseg = GenerateEllenseg();
                    jatekos.GYOGYITAS = osszesElixir;
                }
            }while (nap<=10);

            int jatekosPontszama = jatekos.GetPontszam();
            Console.WriteLine(jatekosPontszama);
            if (jatekosPontszama>=10000)//Játékos pontszámának, értékelése.
            {
                Console.WriteLine();
                Console.WriteLine($"Gratulálok {jatekos.NEV} elérted a GOLD-szintet!");
            }
            else if (jatekosPontszama>=5000)//Játékos pontszámának, értékelése.
            {
                Console.WriteLine();
                Console.WriteLine($"Gratulálok {jatekos.NEV}elérted a SILVER-szintet!");
            }
            else if(jatekosPontszama>=1000)//Játékos pontszámának, értékelése.
            {
                Console.WriteLine();
                Console.WriteLine($"Gratulálok {jatekos.NEV} elérted a Bronz-szintet!");
            }
        }
        public void Lada(Jatekos jatekos, Karakterek ellenseg)//Megmutatja, a harci fejlesztéseket.
        {
            jatekos.SetPontszam(jatekos.GetPontszam() + ellenseg.GetPontszam());
            jatekos.SetPenz(jatekos.GetPenz() + ellenseg.GetPenz());
            jatekos.SetEletero(100);
            jatekos.SetHarciero(jatekos.GetHarciero() + Random(10, 21));
            Console.WriteLine();
            Console.WriteLine($"Kaptál egy ládát!\nHarcierőd értéke:{jatekos.GetHarciero()}");
            Console.WriteLine($"Az általad elért pontok száma:{jatekos.GetPontszam()}");
            Console.WriteLine($"Aranyaid száma:{jatekos.GetPenz()}");
        }
        public void Vasarlas(Jatekos jatekos)//A metodusban, vásároluhatunk elixirt.
        {
            if (jatekos.GetPenz() >= elixir_ar && nap<=10) //Megnézzi, a jatekosnak van-e elég pénze rá.
            {
                Console.WriteLine();
                Console.Write("Vásárolsz-e elixirt(IGEN/NEM - any key):");
                string vasarolsz_e = Console.ReadLine();
                if (vasarolsz_e.ToUpper() == "IGEN")
                {
                    Console.WriteLine();
                    Console.WriteLine($"A pénzedből ennyi elixirt vehetsz:{jatekos.GetPenz()/elixir_ar}");
                    int elixirek_szama; //Hány, elixirt tudna venni.
                    if (jatekos.GetPenz()/elixir_ar > 1)//Első bemenet: Ha, többet tudsz venni.
                    {
                        Console.Write($"Hány elixirt kérsz:");
                        elixirek_szama = int.Parse(Console.ReadLine());
                        while (elixirek_szama> jatekos.GetPenz() / elixir_ar && elixirek_szama < jatekos.GetPenz() / elixir_ar)//Ha, nem add, meg jó értéket.
                        {
                            Console.WriteLine("Ennyit, nem tudsz venni!");
                            Console.Write("Probáld, újra:");
                            elixirek_szama = int.Parse(Console.ReadLine());
                        }
                        jatekos.GYOGYITAS = jatekos.GYOGYITAS + elixirek_szama;
                        jatekos.SetPenz(jatekos.GetPenz() - elixirek_szama * elixir_ar);
                    }
                    else//Második bemenet: Ha, csak egyet tudsz venni.
                    {
                        elixirek_szama = 1;
                        jatekos.GYOGYITAS = jatekos.GYOGYITAS + elixirek_szama;
                        jatekos.SetPenz(jatekos.GetPenz() - elixirek_szama * elixir_ar);
                    }                    
                }
            }
        }
        public int Random(int start, int end)
        {
            Random random = new Random();
            return random.Next(start, end);
        }
    }
}
