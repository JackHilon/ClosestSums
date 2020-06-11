using System;
using System.Collections.Generic;

namespace ClosestSums
{
    class Program
    {
        static void Main(string[] args)
        {
            // Closest Sums problem (for me it is solved, but it has run time error in kattis.com)
            // https://open.kattis.com/problems/closestsums

            // this list to store answers only
            List<string> answers = new List<string>();

            for (int myCounter = 1; myCounter < 4; myCounter++)
            {
                // 1 < n <= 1000
                var n = int.Parse(Console.ReadLine());

                var arr = new int[n];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }

                //  0 < m < 25
                var m = int.Parse(Console.ReadLine());

                var query = new int[m];
                for (int i = 0; i < query.Length; i++)
                {
                    query[i] = int.Parse(Console.ReadLine());
                }


                answers.Add($"Case {myCounter}:");

                int closestSum = 0;
                for (int e = 0; e < query.Length; e++)
                {
                    closestSum = FindClosestSum(arr, query[e]);
                    answers.Add($"Closest sum to {query[e]} is {closestSum}.");
                }
            } // -- end big for

            PrintList(answers);

        } // -- end main


        // -- find closet sum to (a) from two items in an array 
        private static int FindClosestSum(int[] array, int a)
        {
            int[] TwoOperands = { 0, 0 };

            int residue = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    if (k == i)
                        continue;
                    if (Math.Abs(array[k] + array[i] - a) < residue)
                    {
                        TwoOperands[0] = i;
                        TwoOperands[1] = k;
                        residue = Math.Abs(array[k] + array[i] - a);
                    }
                }
            }
            var result = array[TwoOperands[0]] + array[TwoOperands[1]];
            return result;
        }

        private static int ParseConverter(string str)
        {
            int num = 0;

            try
            {
                num = int.Parse(str);

                //if( )
                //    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} || {ex.GetType().FullName}");
                str = Console.ReadLine();
                num = ParseConverter(str);
                return num;
            }
            return num;
        }
        private static void PrintList(List<string> list)
        {
            // this --{FOR LOOP}-- for print puposes only
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
