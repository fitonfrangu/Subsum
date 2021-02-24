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

        public static void printSubsetsRec(int[] arr, int i, int sum,
                                     List<int> p)
        {
            // If we reached end and sum is non-zero. We print 
            // p[] only if arr[0] is equal to sun OR dp[0][sum] 
            // is true. 
            if (i == 0 && sum != 0 && display[0,sum])
            {
                p.Add(arr[i]);
                Shfaq(p);
                p.Clear();
                return;
            }

            // If sum becomes 0 
            if (i == 0 && sum == 0)
            {
                Shfaq(p);
                p.Clear();
                return;
            }

            // If given sum can be achieved after ignoring 
            // current element. 
            if (display[i - 1,sum])
            {
                // Create a new vector to store path 
                List<int> b = new List<int>();
                b.AddRange(p);
                printSubsetsRec(arr, i - 1, sum, b);
            }

            // If given sum can be achieved after considering 
            // current element. 
            if (sum >= arr[i] && display[i - 1, sum - arr[i]])
            {
                p.Add(arr[i]);
                printSubsetsRec(arr, i - 1, sum - arr[i], p);
            }
        }

        // Prints all subsets of arr[0..n-1] with sum 0. 
        public static void printAllSubsets(int[] arr, int n, int sum)
        {
            if (n == 0 || sum < 0)
                return;

            // Sum 0 can always be achieved with 0 elements 
            int m = sum + 1;
            display = new bool[n,m];

            for (int i = 0; i < n; ++i)
            {
                display[i,0] = true;
            }

            // Sum arr[0] can be achieved with single element 
            if (arr[0] <= sum)
                display[0, arr[0]]= true;

            // Fill rest of the entries in dp[][] 
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

            // Now recursively traverse dp[][] to find all 
            // paths from dp[n-1][sum] 
            List<int> p = new List<int>();
            printSubsetsRec(arr, n - 1, sum, p);
        }
    }
}
