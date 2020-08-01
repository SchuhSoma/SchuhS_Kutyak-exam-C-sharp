using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Kutyak
{
    class KutyaFajtak
    {
        //id;név;eredeti név
        public int ID;
        public string Nev;
        public string EredetiNev;

        public KutyaFajtak(string sor)
        {
            var dbok = sor.Split(';');
            this.ID = int.Parse(dbok[0]);
            this.Nev = dbok[1];
            this.EredetiNev = dbok[2];
        }
    }
}
