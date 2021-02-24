using System;

namespace Subsetsum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 3, 2, 1, 5, 4, 8, 9, 10 };
            int n = arr.Length;
            int sum = 25;
            Algoritmi.printAllSubsets(arr, n, sum);
        }
    }
}
