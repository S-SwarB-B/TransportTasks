using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTasks
{
    internal class MinEl
    {
        private int[] Supplier(int countSupplier)
        {
            int[] supplierArr = new int[countSupplier];
            int supplierUnit;
            Console.WriteLine("Поставщики");
            for (int i = 0; i < countSupplier; i++)
            {
                supplierUnit = Convert.ToInt32(Console.ReadLine());
                supplierArr[i] = supplierUnit;
            }
            return supplierArr;
        }
        private int[] Buyer(int countBuyer)
        {
            int[] buyerMass = new int[countBuyer];
            int buyerUnit;
            Console.WriteLine("Покупатели");
            for (int i = 0; i < countBuyer; i++)
            {
                buyerUnit = Convert.ToInt32(Console.ReadLine());
                buyerMass[i] = buyerUnit;
            }
            return buyerMass;
        }
        private int[,] Cost(int countSupplier, int countBuyer)
        {
            int[,] costArr = new int[countSupplier, countBuyer];
            int costUnit;

            Console.WriteLine("Стоимость");

            for (int i = 0; i < countSupplier; i++)
            {
                for (int j = 0; j < countBuyer; j++)
                {
                    costUnit = Convert.ToInt32(Console.ReadLine());
                    costArr[i, j] = costUnit;
                }
                Console.Write("\n");
            }
            return costArr;
        }

        private int CheckData(ref int[] supplierArr, ref int[] buyersArr, ref int[,] costArr, int countSupplier, int countBuyer)
        {
            try
            {
                supplierArr = Supplier(countSupplier);
                buyersArr = Buyer(countBuyer);
                costArr = Cost(countSupplier, countBuyer);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        public void Solve(int countSupplier, int countBuyer)
        {
            int[] supplierArr = null;
            int[] buyerArr = null;
            int[,] costArr = null;

            int check = CheckData(ref supplierArr, ref buyerArr, ref costArr, countSupplier, countBuyer);

            if (check == 0)
            {
                int[,] mainArr = new int[countSupplier, countBuyer];
                int fullCost = 0;

                CalculatingData(supplierArr, buyerArr, costArr, ref mainArr, ref fullCost, countSupplier, countBuyer);

                for (int i = 0; i < countSupplier; i++)
                {
                    for (int j = 0; j < countBuyer; j++)
                    {
                        Console.Write(mainArr[i, j] + " ");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine(fullCost);
            }
            else
            {
                Console.WriteLine("Ошибка при получении данных");
            }
        }

        private void CalculatingData(int[] supplierArr, int[] buyerArr, int[,] costArr, ref int[,] mainArr, ref int fullCost, int countSupplier, int countBuyer)
        {

            int min = int.MaxValue;
            int numberI = 0;
            int numberJ = 0;
            for (int i = 0; i < countSupplier*countBuyer; i++)
            {
                for (int j = 0; j < countSupplier; j++)
                {
                    for (int k = 0; k < countBuyer; k++)
                    {
                        if (min > costArr[j, k] && costArr[j, k] > 0)
                        {
                            min = costArr[j, k];
                            numberI = j;
                            numberJ = k;
                        }
                    }
                }
                min = int.MaxValue;
                if (supplierArr[numberI] >= buyerArr[numberJ])
                {
                    mainArr[numberI, numberJ] = buyerArr[numberJ];
                    supplierArr[numberI] = supplierArr[numberI] - buyerArr[numberJ];
                    buyerArr[numberJ] = 0;
                    fullCost = fullCost + mainArr[numberI, numberJ] * costArr[numberI, numberJ];
                }
                else
                {
                    mainArr[numberI, numberJ] = supplierArr[numberI];
                    buyerArr[numberJ] = buyerArr[numberJ] - supplierArr[numberI];
                    supplierArr[numberI] = 0;
                    fullCost = fullCost + mainArr[numberI, numberJ] * costArr[numberI,numberJ];
                } 
                costArr[numberI, numberJ] = 0;
            }
        }
    }
}
