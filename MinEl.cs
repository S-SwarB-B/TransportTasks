using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiTransponirovaniaMinEl
{
    internal class MinEl
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
        public int[,] MassPokupat(int n, int m)
        {
            int[,] Cost = new int[n,m];
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
        public void MinElement(int n, int m) 
        {
            int[] Postavshiki = MassPostavsh(n);
            int[] Pokupateli = MassPokupat(m);
            int[,] Cost = MassPokupat(n,m);
            int[,] GlavMass = new int[n, m];
            int min = int.MaxValue;
            int LX = 0;
            int countI = 0;
            int countJ = 0;
            for (int i = 0; i < n*m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        if (min > Cost[j, k] && Cost[j, k] > 0)
                        {
                            min = Cost[j, k];
                            countI = j;
                            countJ = k;
                        }
                    }
                }
                min = int.MaxValue;
                if (Postavshiki[countI] >= Pokupateli[countJ])
                {
                    GlavMass[countI, countJ] = Pokupateli[countJ];
                    Postavshiki[countI] = Postavshiki[countI] - Pokupateli[countJ];
                    Pokupateli[countJ] = 0;
                    LX = LX + GlavMass[countI, countJ] * Cost[countI, countJ];
                }
                else
                {
                    GlavMass[countI, countJ] = Postavshiki[countI];
                    Pokupateli[countJ] = Pokupateli[countJ] - Postavshiki[countI];
                    Postavshiki[countI] = 0;
                    LX = LX + GlavMass[countI, countJ] * Cost[countI,countJ];
                } 
                Cost[countI, countJ] = 0;
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
