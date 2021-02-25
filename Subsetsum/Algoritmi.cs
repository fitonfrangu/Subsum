using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subsetsum
{
    public static class Algoritmi
    {
        static bool[,] display;
        static int[] check = new int[7];

        public static void Shfaq(List<int> array)
        {
            string arrayString = "";
            bool dp = true;

            if(check.Intersect(array).Any())
            {
                dp = false;
            }
            else
            {
                int k = check.Where(q=>q != 0).Count();

                for (int i = 0; i < array.Count; i++)
                {
                    check[i + k] = array[i];
                }
            }

            if(dp)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    arrayString += array[i] + " ";
                }

                Console.WriteLine(arrayString);
            }
        }

        public static void printoSubShumen(int[] arr, int i, int sum,
                                     List<int> p)
        {
            if (i == 0 && sum != 0 && display[0,sum])
            {
                p.Add(arr[i]);
                Shfaq(p);
                p.Clear();
                return;
            }

            // Nese shuma behet 0
            if (i == 0 && sum == 0)
            {
                Shfaq(p);
                p.Clear();
                return;
            }

            if (display[i - 1,sum])
            {
                List<int> b = new List<int>();
                b.AddRange(p);
                printoSubShumen(arr, i - 1, sum, b);
            }

            if (sum >= arr[i] && display[i - 1, sum - arr[i]])
            {
                p.Add(arr[i]);
                printoSubShumen(arr, i - 1, sum - arr[i], p);
            }
        }

        // Prints all subsets of arr[0..n-1] with sum 0. 
        public static void printoGjithaShumat(int[] arr, int n, int sum)
        {
            if (n == 0 || sum < 0)
                return;

            int m = sum + 1;
            display = new bool[n,m];

            for (int i = 0; i < n; ++i)
            {
                display[i,0] = true;
            }

            if (arr[0] <= sum)
                display[0, arr[0]]= true;

            for (int i = 1; i < n; ++i)
                for (int j = 0; j < sum + 1; ++j)
                    display[i,j] = (arr[i] <= j) ? (display[i - 1,j] ||
                                               display[i - 1, j - arr[i]])
                                             : display[i - 1,j];
            if (display[n - 1,sum] == false)
            {
                Console.WriteLine("There are no subsets with" +
                                                      " sum " + sum);
                return;
            }

            List<int> p = new List<int>();
            printoSubShumen(arr, n - 1, sum, p);
        }
    }
}
