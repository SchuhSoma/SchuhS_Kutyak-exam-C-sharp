using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Kutyak
{
    class KutyaNevek
    {
        //id;kutyanév
        public int ID;
        public string Kutyanev;

        public KutyaNevek(string sor)
        {
            var dbok = sor.Split(';');
            this.ID = int.Parse(dbok[0]);
            this.Kutyanev = dbok[1];
        }
    }
}
