using MetodiTransponirovaniaMinEl;
using MetodiTransponirovaniaSevZap;
using MetodiTransponirovaniaDvoinoePredp;
using System;

namespace Metods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Минимальный элемент\n" +
                "2 - Северозападный угол\n" +
                "3 - Метод плюсов\n");
            int h = Convert.ToInt32(Console.ReadLine());
            if (h == 1)
            {
                MinEl minEl = new MinEl();
                Console.Write("Количество поставщиков: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Количество покупателей: ");
                int m = Convert.ToInt32(Console.ReadLine());
                minEl.MinElement(n, m);
            }
            else if (h == 2)
            {
                SevZapUgol sevZapUgol = new SevZapUgol();
                Console.Write("Количество поставщиков: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Количество покупателей: ");
                int m = Convert.ToInt32(Console.ReadLine());
                sevZapUgol.SevZap(n, m);
            }
            else if (h == 3) 
            { 
                DvoinPred dvoinPred = new DvoinPred();
                Console.Write("Количество поставщиков: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Количество покупателей: ");
                int m = Convert.ToInt32(Console.ReadLine());
                dvoinPred.DvoinoePredp(n, m);
            }
            //90,400,110
            //140,300,160
            //{2, 5, 2 },{ 4, 1, 5 },{ 3, 6, 8 };

            //14 14 14 14
            //13 5 13 12 13
            //{16 26 12 24 3} {5 2 19 27 2} {29 23 25 16 8} {2 25 14 15 21}

            //MinEl 90  0  0
            //      0  300 60
            //      50  0  60
            //      1610

            //SevZap 90  0  0
            //       50 300 50
            //       0   0  110
            //       1810


            //DvoinPred 0 0 13 0 1
            //          0 5 0 0 9
            //          0 0 0 11 3
            //          13 0 0 1 0
            //          428
        }
    }
}

