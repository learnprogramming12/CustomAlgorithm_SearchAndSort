using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Tools
    {
        public static void CreateRandomArray(int[] arr, int iMin = 0, int iMax = int.MaxValue - 1)
        {
            Random ran = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ran.Next(iMin, iMax);
            }
        }

        public static int[] CreateRandomArray(int iSize, int iMin = 0, int iMax = int.MaxValue - 1)
        {
            int[] arr = new int[iSize];
            CreateRandomArray(arr, iMin, iMax);
            return arr;
        }

        public static int[] CreateSortedArray(int iSize)
        {
            int[] arr = new int[iSize];
            Random rand = new Random();
            int iLast = 0;

            for (int i = 0; i < iSize; i++)
            {
                iLast = arr[i] = rand.Next(++iLast, iLast + 10);
            }
            return arr;
        }
        //Selection sort. Its complexity is O(n2);
        public static void selectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int iMinIndex = i;//assume the i index represents where the smallest value is.
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //if the j represents a smaller value, then assign it to the variable represents the smallest value.
                    if (arr[j] < arr[iMinIndex])
                    {
                        iMinIndex = j;
                    }
                }
                if (iMinIndex != i)//if the 2 indexes represent 2 different elements, then swap the two values.
                {
                    int iTemp = arr[i];
                    arr[i] = arr[iMinIndex];
                    arr[iMinIndex] = iTemp;
                }
            }
        }

        //Quick sort. The complexity of it is O(n*logn).
        /*Created by Cui_20230402.*/
        /*This method tries to avoid the StackOverflow caused by large sorted array(not including one which is equal or a large partly
         * equal between elements. Although it is tested by myself, but it still may cause problems.------Cui.*/
        public static void quickSort(int[] arr, int iLow, int iHigh)
        {
            if (iLow >= iHigh)
                return;
            int i = iLow, j = iHigh;
            int iMid = (iLow + iHigh) / 2;//in order to deal with sorted or large partly sorted array because of StackOverflow.
            int iKey = arr[iMid];
            //find the index of a greater or equal value from the left. Then find the index of a smaller value from the right.
            for (; i < j;)
            {
                if (arr[i] < iKey)
                {
                    ++i;
                    continue;
                }
                if (arr[j] >= iKey)
                {
                    --j;
                    continue;
                }
                int iTemp = arr[i];
                arr[i] = arr[j];
                arr[j] = iTemp;
                ++i;
            }
            if (j < iMid)
            {//in order to avoid the situation when Key is in the larger part(right of j), in this case it is smaller than arr[i] but is omitted by j.
                int iTemp = arr[j];
                arr[j] = arr[iMid];
                arr[iMid] = iTemp;
            }
            int iSeparatePoint = i - 1;//the left part of arr[i] is definitely smaller than Key value.
            if (i == iLow)
                iSeparatePoint = i;//In this case, we should NOT use the left part of i. And it avoid indefinite loop when invoke the larger part funciton.

            //invoke the function itself by specifying smaller part and larger part separately.
            quickSort(arr, iLow, iSeparatePoint);
            quickSort(arr, iSeparatePoint + 1, iHigh);
        }
        public static bool IsArrayAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        //Linear Search. Return the number of iterations needed to find the first occurence in the array of the specified value.
        //Return -1 if not found.
        //The complexity is O(n).
        public static int LinearSearch(int[] arr, int iValue)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //Return the number of iterations needed to find the value.
                if (arr[i] == iValue)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        //Binary Search. Return the number of iterations needed to find the specified value.(Note: The array must be ascending array.)
        //Return -1 if not found.
        //The complexity is logN.
        public static int BinarySearch(int[] arr, int iValue)
        {
            int iCount = 0, iMinIndex = 0, iMaxIndex = arr.Length - 1;

            for (; iMinIndex <= iMaxIndex;)
            {
                ++iCount;
                int iMid = (iMinIndex + iMaxIndex) / 2;//caculate the middle index of the low index and high index.
                if (arr[iMid] == iValue)
                    return iCount;
                else if (arr[iMid] < iValue)//If the element is smaller, then search its right part by assigning the low index..
                {
                    iMinIndex = iMid + 1;
                }
                else
                {
                    iMaxIndex = iMid - 1;//if the element is larger, then search its left part by assigning the high index.
                }
            }
            return -1;
        }
        //Linear Recursive Search. Return the index of value in array. Return -1 if not found
        public static int ArrayRecursiveLinearSearch(int[] arr, int iIndex, int iValue)
        {
            if (iIndex >= arr.Length)
                return -1;
            if (arr[iIndex] == iValue)
                return iIndex;
            return ArrayRecursiveLinearSearch(arr, iIndex + 1, iValue);
        }

        //Binary Recursive Search. Return the index of value in array. Return -1 if not found.
        public static int ArrayRecursiveBinarySearch(int[] arr, int iLow, int iHigh, int iValue)
        {

            if (iLow > iHigh)
                return -1;

            int iMid = (iLow + iHigh) / 2;
            if (arr[iMid] == iValue)
                return iMid;
            else if (arr[iMid] < iValue)
                iLow = iMid + 1;
            else
                iHigh = iMid - 1;
            return ArrayRecursiveBinarySearch(arr, iLow, iHigh, iValue);
        }
    }
}
