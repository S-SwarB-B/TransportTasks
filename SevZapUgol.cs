using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiTransponirovaniaSevZap
{
    internal class SevZapUgol
    {
        public int[] MassPostavsh(int n)
        {
            int[] Postavshiki = new int[n];
            int a;
            Console.WriteLine("Поставщики");
            for (int i = 0; i < n; i++)
            {
                a = Convert.ToInt32(Console.ReadLine());
                Postavshiki[i] = a;
            }
            return Postavshiki;
        }
        public int[] MassPokupat(int m)
        {
            int[] Pokupateli = new int[m];
            int a;
            Console.WriteLine("Покупатели");
            for (int i = 0; i < m; i++)
            {
                a = Convert.ToInt32(Console.ReadLine());
                Pokupateli[i] = a;
            }
            return Pokupateli;
        }
        public int[,] MassCost(int n, int m)
        {
            int[,] Cost = new int[n, m];
            int a;
            Console.WriteLine("Стоимость");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    Cost[i, j] = a;
                }
                Console.Write("\n");
            }
            return Cost;
        }
        public void SevZap(int n, int m)
        {
            int[] Postavshiki = MassPostavsh(n);
            int[] Pokupateli = MassPokupat(m);
            int[,] Cost = MassCost(n, m);
            int[,] GlavMass = new int[n, m];
            int LX = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Postavshiki[i] >= Pokupateli[j])
                    {
                        GlavMass[i, j] = Pokupateli[j];
                        Postavshiki[i] = Postavshiki[i] - Pokupateli[j];
                        Pokupateli[j] = 0;
                        LX = LX + GlavMass[i, j] * Cost[i, j];
                    }
                    else
                    {
                        GlavMass[i, j] = Postavshiki[i];
                        Pokupateli[j] = Pokupateli[j] - Postavshiki[i];
                        Postavshiki[i] = 0;
                        LX = LX + GlavMass[i, j] * Cost[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(GlavMass[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine(LX);
        }
    }
}
