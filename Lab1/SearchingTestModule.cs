using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class SearchingTestModule
    {
        private static string m_strMark = "----------------------------------------------------------------";
        public static EnumResult SearchingTest(int[] arr)
        {
            if(arr == null || arr.Length == 0)
            {
                Console.WriteLine("Warning: No element in the array.");
                return EnumResult.PREVIOUS;
            }
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("Please choose which method you want to use to search value.(Note: This system will firstly check whether the array " +
                    "is ascending if you choose Binary Search in case of invalidity");
                Console.WriteLine("1)Linear Search  2)Binary Search  3)Print formatted Array  p)Previous  m)Main Menu  e)Exit");
                string strInput = Console.ReadLine().ToLower();
                string strMethod;
                switch (strInput)
                {
                    case "1":
                        strMethod = "Linear Search";
                        break;
                    case "2":
                        strMethod = "Binary Search";
                        break;
                    case "3":
                        EnumResult enumResult = PrintModule.Print(arr);
                        if (enumResult == EnumResult.MAINMENU || enumResult == EnumResult.EXIT)
                            return enumResult;
                        continue;//Other returned values from PrintModule should continue this step.
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
                int iValue = 0;
                bool bValid = false;
                while (true)
                {
                    Console.WriteLine(m_strMark);
                    Console.WriteLine("p)Previous  m)Main Menu  e)Exit");
                    Console.WriteLine("Please specify the value to search" + "(" + strMethod + "):");
                    string strValue = Console.ReadLine().ToLower();
                    if (strValue == "p")
                        break;
                    else if (strValue == "m")
                        return EnumResult.MAINMENU;
                    else if (strValue == "e")
                        return EnumResult.EXIT;

                    bValid = int.TryParse(strValue, out iValue);
                    if (bValid == false)
                    {
                        Console.WriteLine("The value is invalid. Please input again:");
                        continue;
                    }
                    if (strInput == "1")
                    {
                        TestLinearSearch(arr, iValue);
                    }
                    else if (strInput == "2")
                    {
                        if (EnumResult.FAILED == TestBinarySearch(arr, iValue))
                            break;
                    }
                }
            }
        }
        private static EnumResult TestLinearSearch(int[] arr, int iValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int iIterations = Tools.LinearSearch(arr, iValue);
            stopwatch.Stop();
            long iTimespan = stopwatch.ElapsedMilliseconds;
            if (iIterations > 0)
            {
                Console.WriteLine("Iteration count(Linear Search): {0}", iIterations);
                Console.WriteLine("Milliseconds spent(Linear Search): {0}", iTimespan);

            }
            else if (iIterations == -1)
            {
                Console.WriteLine("The value is not found.");
            }
            return EnumResult.SUCCEED;
        }
        private static EnumResult TestBinarySearch(int[] arr, int iValue)
        {
            if (Tools.IsArrayAscending(arr) == false)
            {
                Console.WriteLine("Warning: The array is not ascending. Binary search can not be used.");
                return EnumResult.FAILED;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int iIterations = Tools.BinarySearch(arr, iValue);
            stopwatch.Stop();
            long iTimespan = stopwatch.ElapsedMilliseconds;
            if (iIterations > 0)
            {
                Console.WriteLine("Iteration count(Binary Search): {0}", iIterations);
                Console.WriteLine("Milliseconds spent(Binary Search): {0}", iTimespan);

            }
            else if (iIterations == -1)
            {
                Console.WriteLine("The value is not found.");
            }
            return EnumResult.SUCCEED;
        }
    }
}
