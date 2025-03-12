using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MetodiTransponirovaniaDvoinoePredp
{
    internal class DvoinPred
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
        public void DvoinoePredp(int n, int m) 
        {
            int[] Postavshiki = MassPostavsh(n);
            int[] Pokupateli = MassPokupat(m);
            int[,] Cost = MassCost(n,m);
            int[,] GlavMass = new int[n, m];
            int[,] PlusMass = new int[n, m];
            int LX = 0;
            int PromEl = 0;
            int MinElInCost = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                for (int j = 0;j < m; j++)
                {
                    if (Cost[i,j] < MinElInCost)
                    {
                        MinElInCost=Cost[i,j];
                        PromEl = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if(Cost[i, j] == MinElInCost && j != PromEl)
                    {
                        PlusMass[i,j]++;
                    }
                }
                MinElInCost = int.MaxValue;
                PlusMass[i, PromEl]++;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Cost[j, i] < MinElInCost)
                    {
                        MinElInCost = Cost[j, i];
                        PromEl = j;
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    if (Cost[j, i] == MinElInCost && j!=PromEl)
                    {
                        PlusMass[j, i]++;
                    }
                }
                MinElInCost = int.MaxValue;
                PlusMass[PromEl, i]++;
            }

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if(PlusMass[i, j] == 2)
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
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (PlusMass[i, j] == 1)
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
            }
            int min = int.MaxValue;
            int countI = int.MinValue;
            int countJ = int.MinValue;
            for (int i = 0; i < n * m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                       if (min > Cost[j, k] && Cost[j, k] > 0 && PlusMass[j,k] == 0)
                       {
                         min = Cost[j, k];
                         countI = j;
                         countJ = k;
                       }
                    }               
                }
                if(countI == int.MinValue || countJ == int.MinValue)
                {
                    break;
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
                    LX = LX + GlavMass[countI, countJ] * Cost[countI, countJ];
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
