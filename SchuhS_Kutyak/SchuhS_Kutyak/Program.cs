using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_Kutyak
{
    class Program
    {
        static List<Kutyak> KutyakList;
        static List<KutyaFajtak> KutyaFajtakList;
        static List<KutyaNevek> KutyaNevekList;
        static Dictionary<string, int> ElofordulasokStat;
        static List<string> Idopontok;
        static List<string> NevekList;
        static Dictionary<string, int> NevekStatisztika;
        static List<int> NevekIDList;
        static Dictionary<int, int> NevIDStat;
        static void Main(string[] args)
        {
            Feladat2Beolvasas(); Console.WriteLine("\n----------------------------\n");
            Feladat3KutyakSzama(); Console.WriteLine("\n----------------------------\n");
            Feladat6AtlagEletkor(); Console.WriteLine("\n----------------------------\n");
            Feladat7Legidosebb(); Console.WriteLine("\n----------------------------\n");
            Feladat8Elofordulas(); Console.WriteLine("\n----------------------------\n");
            Feladat9MAxLeterheltseg(); Console.WriteLine("\n----------------------------\n");
            Feladat10NevekStatisztika();
            Console.ReadKey();
        }

        private static void Feladat10NevekStatisztika()
        {
            Console.WriteLine("10.Feladat: Nevek statisztikája");
            var sw = new StreamWriter(@"NevStatisztika.csv", false, Encoding.UTF8);
            NevekList = new List<string>();
            NevekStatisztika = new Dictionary<string, int>();
            NevIDStat = new Dictionary<int, int>();
            NevekIDList = new List<int>();
            foreach (var k in KutyakList)
            {
                if(!NevekIDList.Contains(k.Nev_ID))
                {
                    NevekIDList.Add(k.Nev_ID);
                }                
            }
            foreach (var n in NevekIDList)
            {
                int db = 0;
                foreach (var k in KutyakList)
                {
                    if(n==k.Nev_ID)
                    {
                        db++;
                    }                    
                }
                NevIDStat.Add(n, db);
            }
            foreach (var ns in NevIDStat)
            {
                foreach (var kn in KutyaNevekList)
                {
                    if(ns.Key==kn.ID)
                    {
                        Console.WriteLine("\t{0} : {1}", kn.Kutyanev, ns.Value);
                        sw.WriteLine("{0};{1}", kn.Kutyanev, ns.Value);
                    }
                }
                
            }
            sw.Close();
           /* 
            foreach (var k in KutyakList)
            {
                foreach (var kn in KutyaNevekList)
                {
                    if (k.Nev_ID ==kn.ID)
                    {
                        if(!NevekList.Contains(kn.Kutyanev))
                        {
                            NevekList.Add(kn.Kutyanev);
                        }
                    }
                }                
            }
            foreach (var n in NevekList)
            {
                Console.WriteLine("\t{0}",n);
            }
            */

        }

        private static void Feladat9MAxLeterheltseg()
        {
            Console.WriteLine("9.Feladat: határozza meg melyik nap volt a rendelőnek a legnagyobb leterheltsége");
            ElofordulasokStat = new Dictionary<string, int>();
            Idopontok = new List<string>();
            foreach (var k in KutyakList)
            {
                if(!Idopontok.Contains(k.UtolsoEllenorzes))
                {
                    Idopontok.Add(k.UtolsoEllenorzes);
                }
            }
            Idopontok.Sort();
            foreach (var i in Idopontok)
            {
                //Console.WriteLine("\t{0}",i);
            }
            foreach (var i in Idopontok)
            {
                int db = 0;
                foreach (var k in KutyakList)
                {
                    if(i==k.UtolsoEllenorzes)
                    {
                        db++;
                        
                    }                   
                }
                ElofordulasokStat.Add(i, db);
            }
            int MaxDB = int.MinValue;
            string MaxIdopont = " ";
            foreach (var e in ElofordulasokStat)
            {
               if(MaxDB<e.Value)
               {
                    MaxDB = e.Value;
                    MaxIdopont = e.Key;
               }
            }
            Console.WriteLine("\tLegtöbb előfordulás időpontja:\n\tidőpont {0} : vizsgálat száma {1}", MaxIdopont, MaxDB);
        }

        private static void Feladat8Elofordulas()
        {
            Console.WriteLine("8.Feladat:2018.01.10-én fajtánként hány kutya fordult elő ");
            foreach (var k in KutyakList)
            {
               if(k.UtolsoEllenorzes.Contains("2018.01.10"))
               {
                    int db = 0;              
                    foreach (var kf in KutyaFajtakList)
                    {
                        if(k.Fajta_ID==kf.ID)
                        {
                            db++;
                            Console.WriteLine("\t{0} : {1} kutya", kf.Nev, db);
                        }                        
                    }
               }
            }           
        }

        private static void Feladat7Legidosebb()
        {
            Console.WriteLine("7.Feladat: Legidősebb kutya adatai");
            int MaxEletkor = int.MinValue;
            int MaxID = 0;
            int MaxNevID = 0;
            int MaxFajtaID = 0;
            string MaxNev = "cica";
            string MaxFajta = " ";
            foreach (var k in KutyakList)
            {
                if(MaxEletkor<k.Eletkor)
                {
                    MaxEletkor = k.Eletkor;
                    MaxID = k.ID;
                    MaxFajtaID = k.Fajta_ID;
                    MaxNevID = k.Nev_ID;
                }
                foreach (var kn in KutyaNevekList)
                {
                    if(MaxNevID == kn.ID)
                    {
                        MaxNev = kn.Kutyanev;
                    }
                }
                foreach (var kf in KutyaFajtakList)
                {
                    if(MaxFajtaID==kf.ID)
                    {
                        MaxFajta = kf.Nev;
                    }    
                }

            }
            Console.WriteLine("\tA legidősebb kutya adatai:\n\tID: {0}\n\téletkor: {1}\n\tnév: {2}\n\tfajta: {3}", MaxID, MaxEletkor, MaxNev, MaxFajta);
            //id;fajta_id;név_id;életkor;utolsó orvosi ellenőrzés
        }

        private static void Feladat6AtlagEletkor()
        {
            Console.WriteLine("6.Feladat: Átlag életkora a kutyáknak");
            double Osszeg = 0;
            double Atlag = 0;
            foreach (var k in KutyakList)
            {
                Osszeg += k.Eletkor;
                Atlag = Osszeg / KutyakList.Count;
            }
            Console.WriteLine("\tA kutyák átlag életkora: {0:0.00}", Atlag);
        }

        private static void Feladat3KutyakSzama()
        {
            Console.WriteLine("3.Feladat: Kutyák száma");
            Console.WriteLine("\tKutyanevek száma: {0}", KutyaNevekList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: Adatok beolvasása");
            KutyaFajtakList = new List<KutyaFajtak>();
            KutyakList = new List<Kutyak>();
            KutyaNevekList = new List<KutyaNevek>();
            int db1 = 0;
            int db2 = 0;
            int db3 = 0;
            var sr1 = new StreamReader(@"KutyaFajtak.csv", Encoding.UTF8);
            while(!sr1.EndOfStream)
            {
                db1++;
                KutyaFajtakList.Add(new KutyaFajtak(sr1.ReadLine()));
            }
            if(db1>0)
            { 
                Console.WriteLine("\tKutyafajták sikeresen beolvasva: {0}", db1); 
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
            var sr2 = new StreamReader(@"Kutyak.csv", Encoding.UTF8);
            while (!sr2.EndOfStream)
            {
                db2++;
                KutyakList.Add(new Kutyak(sr2.ReadLine()));
            }
            if (db2 > 0)
            {
                Console.WriteLine("\tKutyak sikeresen beolvasva: {0}", db2);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
            var sr3 = new StreamReader(@"KutyaNevek.csv", Encoding.UTF8);
            while (!sr3.EndOfStream)
            {
                db3++;
                KutyaNevekList.Add(new KutyaNevek(sr3.ReadLine()));
            }
            if (db3 > 0)
            {
                Console.WriteLine("\tKutyaNevek sikeresen beolvasva: {0}", db3);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
        }
    }
}
