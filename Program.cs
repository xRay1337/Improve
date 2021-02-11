using System;
using System.Collections.Generic;

namespace TestTaskForIMPROVE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter natural number: ");
            var inputNumer = Convert.ToInt32(Console.ReadLine());

            int[][] result = ImproveFunction(inputNumer);

            //Array.Sort(result, (arr1, arr2) => arr1.Length - arr2.Length);

            for (var i = 0; i < result.Length; i++)
            {
                Console.WriteLine();
                Console.Write($"Array[{i}]:");

                foreach (var element in result[i])
                {
                    Console.Write($" {element}");
                }
            }
        }

        static int[][] ImproveFunction(int naturalNumber)
        {
            if (naturalNumber < 0)
            {
                throw new ArgumentException("Natural number cannot be less than zero", nameof(naturalNumber));
            }

            var random = new Random(DateTime.Now.Millisecond);
            var cache = new HashSet<int>();
            var result = new int[naturalNumber][];
            var maxLength = 100;    //можно выставить "int.MaxValue" или вовсе убрать
            var maxValue = 1000;    //можно выставить "int.MaxValue" или вовсе убрать
            int arraySize;

            for (var arrayIndex = 0; arrayIndex < naturalNumber; arrayIndex++)
            {
                do
                {
                    arraySize = random.Next(0, maxLength);
                }
                while (cache.Contains(arraySize));

                cache.Add(arraySize);

                var currentArray = new int[arraySize];

                for (var elementIndex = 0; elementIndex < arraySize; elementIndex++)
                {
                    currentArray[elementIndex] = random.Next(maxValue);
                }

                if (arrayIndex % 2 == 0)
                {
                    Array.Sort(currentArray, (num1, num2) => num1 - num2);
                }
                else
                {
                    Array.Sort(currentArray, (num1, num2) => num2 - num1);
                }

                result[arrayIndex] = currentArray;
            }

            return result;
        }
    }
}