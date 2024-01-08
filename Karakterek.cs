using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_to_Argon___Beta_v._2._0
{
    internal class Karakterek : Random
    {
        private int eletero { get; set; }
        private int harciero { get; set; }
        private int penz { get; set; }
        private int pontszam = 0;
        public void SetEletero(int Eletero)
        {
            eletero= Eletero;
        }
        public int GetEletero()
        {
            return eletero;
        }
        public void SetHarciero(int Harciero) 
        { 
            harciero= Harciero;
        }
        public int GetHarciero()
        {
            return harciero;
        }
        public void SetPontszam(int Pontszam)
        {
            pontszam = Pontszam;
        }
        public int GetPontszam()
        {
            return pontszam;
        }
        public void SetPenz(int Penz) 
        {
            penz = Penz;
        }
        public int GetPenz() 
        { 
            return penz;
        }
        public int Random(int start, int end)
        {
            Random random = new Random();
            return random.Next(start, end);
        }
    }
}
