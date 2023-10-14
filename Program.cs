using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Saldainis_Laboras2
{

    class Saldainis
    {
        string pavadinimas;
        string tipas;
        double kgKaina;
        double kiekKg;
     

        public Saldainis(string pavadinimas, string tipas, double kgKaina, double kiekKg )
        {
            this.pavadinimas = pavadinimas;
            this.tipas = tipas;
            this.kgKaina = kgKaina;
            this.kiekKg = kiekKg;
          
   
        }   
   public string imtiPavadinima() { return pavadinimas; }
            public string imtiTipa() { return tipas; }
            public double imtikgKaina() { return kgKaina; }
        public double ImtiKg() { return kiekKg; }
       

    }
    internal class Program
    {
       
        
        static void Main(string[] args)
        {  
            
            const int Cn = 100;
        const int Cf = 100;
         string fv1 = "TextFile1.txt";
      string fv2 = "TextFile2.txt";

  
            int n1, n2;
            double kiekis1, kiekis2;
            string pav1, vard1;    
            string pav2, vard2;
            int vard11, brangindeks;
                
                Saldainis[] S1 = new Saldainis[Cn];
            Saldainis[] S2 = new Saldainis[Cf];

       
           

            skaityti(fv1, S1, out n1, out kiekis1, out vard1);

            spausdinti(S1, kiekis1, vard1);

           kiekkainuoja(S1, kiekis1);
           



      }
        
       
        
     static void skaityti( string FD,  Saldainis[] S1, out int n, out double kiekis, out string vardas )
    
{ 
            string pavadinimas;
            string tipas;
            double kgKaina;
            double kiekKg;
          


            using (StreamReader reader = new StreamReader(FD))
            {
                string[] parts;
                string line;
                 line = reader.ReadLine();
                vardas = line;
                line = reader.ReadLine();
              kiekis = double.Parse(line);
                    
                for (int i=0; i<kiekis; i++)
                {
                    line = reader.ReadLine();
                    parts =line.Split(';');
                    pavadinimas= parts[0];
                    tipas = parts[1];
                    kgKaina= double.Parse(parts[2]);
                    kiekKg= double.Parse(parts[3]);
                    
                   

                    S1[i] = new Saldainis(pavadinimas, tipas, kgKaina, kiekKg);
                    
                }
                line = reader.ReadLine();
                n = int.Parse(line);
              


            }

        }

        static void kiekkainuoja(Saldainis[] S1, double kiekis)
        {
            int brangindeks = 0;
            double brangiausias = S1[0].imtikgKaina() * S1[0].ImtiKg();

            for (int i = 0; i < kiekis; i++)
            {
                Console.WriteLine(S1[i].imtiPavadinima() + " | " + "  Saldainiai kainuoja  " + S1[i].imtikgKaina() * S1[i].ImtiKg());


            }
            for (int i = 0; i < kiekis; i++)
            {
                if (brangiausias < S1[i].imtikgKaina() * S1[i].ImtiKg() )
                {
                    brangiausias = S1[i].imtikgKaina() * S1[i].ImtiKg();
                    brangindeks =i;
                }
        
            }
            Console.WriteLine("Brangiausiu saldainiu tipas: " + S1[brangindeks].imtiTipa());
          

            }
                
       
    static int Indeksas(Saldainis[] S1, int kiekis)
        {

            int brangindeks = 0;
           
            for (int i =0; i < kiekis; i++)
            {
                if (S1[i].imtikgKaina() * S1[i].ImtiKg() > S1[i + 1].imtikgKaina() * S1[i + 1].imtikgKaina())
                {
                   brangindeks = i;

                }
                else  brangindeks = i + 1;

            }
            return brangindeks;
        }
 static void spausdinti(Saldainis[] S1, double kiekis, string vard1 )
    {

        const string virsus =
          "|-----------------|------------|---------------|---------|\r\n"
          + "| Pavadinimas | Tipas | Kaina kilogramui | esamas kiekis (kg) | \r\n"
          + "|-----------------|------------|---------------|---------|";
            Console.WriteLine("PRADINIAI DUOMENYS :");
            Console.WriteLine(vard1);
            Console.WriteLine(virsus);

            for (int i = 0; i < kiekis; i++)
            {
                Console.WriteLine("| {0,-12} | {1,8} | {2,5} | {3,13} |",
                  S1[i].imtiPavadinima(), S1[i].imtiTipa(), S1[i].imtikgKaina(), S1[i].ImtiKg());

            }     
    }

    } 
  
}
