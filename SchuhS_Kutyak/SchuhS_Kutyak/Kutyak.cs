using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Kutyak
{
    class Kutyak
    {
        //id;fajta_id;név_id;életkor;utolsó orvosi ellenőrzés
        public int ID;
        public int Fajta_ID;
        public int Nev_ID;
        public int Eletkor;
        public string UtolsoEllenorzes;

        public Kutyak(string sor)
        {
            var dbok = sor.Split(';');
            this.ID = int.Parse(dbok[0]);
            this.Fajta_ID = int.Parse(dbok[1]);
            this.Nev_ID = int.Parse(dbok[2]);
            this.Eletkor = int.Parse(dbok[3]);
            this.UtolsoEllenorzes =dbok[4];
        }
    }
}
