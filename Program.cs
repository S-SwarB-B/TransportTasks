using TransportTasks;
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
            try
            {
                int h = Convert.ToInt32(Console.ReadLine());

                int countSupplier = 0, countBuyer = 0;
                if (h == 1)
                {
                    MinEl minEl = new MinEl();
                    CountParticipants(ref countSupplier, ref countBuyer);
                    minEl.Solve(countSupplier, countBuyer);
                }
                else if (h == 2)
                {
                    NorthWest northWest = new NorthWest();
                    CountParticipants(ref countSupplier, ref countBuyer);
                    northWest.Solve(countSupplier, countBuyer);
                }
                else if (h == 3)
                {
                    DoublePreference doublePreference = new DoublePreference();
                    CountParticipants(ref countSupplier, ref countBuyer);
                    doublePreference.Solve(countSupplier, countBuyer);
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }

        private static void CountParticipants(ref int countSupplier, ref int countBuyer)
        {
            Console.Write("Количество поставщиков: ");
            countSupplier = Convert.ToInt32(Console.ReadLine());
            Console.Write("Количество покупателей: ");
            countBuyer = Convert.ToInt32(Console.ReadLine());
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

