using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class SortingTestModule
    {
        private static string m_strMark = "----------------------------------------------------------------";
        public static EnumResult SortingTest(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Warning: No element in the array.");
                return EnumResult.PREVIOUS;
            }
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("Please choose which method you want to use to sort array");
                Console.WriteLine("1)Selection Sort  2)Quick Sort  p)Previous  m)Main Menu  e)Exit");
                string strInput = Console.ReadLine().ToLower();

                switch (strInput)
                {
                    case "1":
                        TestSelectionSorting(arr);
                        break;
                    case "2":
                        TestQuickSorting(arr);
                        break;
                    case "p":
                        return EnumResult.PREVIOUS;
                    case "m":
                        return EnumResult.MAINMENU;
                    case "e":
                        return EnumResult.EXIT;
                    default:
                        {
                            Console.WriteLine("The input is invalid. Please enter a valid instruction.");
                            continue;
                        }
                }
            }
        }
        private static EnumResult TestSelectionSorting(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Tools.selectionSort(arr);
            stopwatch.Stop();
            long iTimespan = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Milliseconds spent(Selection Sort): {0}", iTimespan);   
            
            return EnumResult.SUCCEED;
        }
        private static EnumResult TestQuickSorting(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Tools.quickSort(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            long iTimespan = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Milliseconds spent(Quick Sort): {0}", iTimespan);

            return EnumResult.SUCCEED;
        }
    }
}
