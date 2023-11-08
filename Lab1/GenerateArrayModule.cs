using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class GenerateArrayModule
    {
        //The default largest array size is 200000.
        private const int m_iBigestArraySize = 200000;
        private static string m_strMark = "----------------------------------------------------------------";
        public static EnumResult GenerateArray(ref int[]arr, out bool bValid)
        {
            bValid = false;
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("1)Generate by input  2)Generate random array by system  3)Generate sorted array by system  p)Previous  m)Main menu  e)Exit");
                Console.WriteLine("Please choose which method you want to generate array:");

                string strOption = Console.ReadLine().ToLower();

                EnumResult enumValue;
                switch (strOption)
                {
                    case "1":
                        enumValue = GenerateArrayByInput(ref arr, out bValid);
                        break;
                    case "2":
                        enumValue = GenerateRandomArrayBySystem(ref arr, out bValid);
                        break;
                    case "3":
                        enumValue = GenerateSortedArrayBySystem(ref arr, out bValid);
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
                if (enumValue == EnumResult.PREVIOUS || enumValue == EnumResult.FAILED)
                    continue;                    
                return enumValue;//Other value means that there is no need to stay in this module.
            }
        }

        private static EnumResult GenerateArrayByInput(ref int[] arr, out bool bValid)
        {
            //When user does not want to continue input the value or the array is too large to input, in this way it can prevent change the original array.
            int[] arrTemp = { };
            bValid = false;
            int iCount;

            EnumResult enumValue = DealWithArraySizeInput(out iCount);
            if (enumValue != EnumResult.SUCCEED)
                return enumValue;

            while (true)
            {
                try
                {//in case of no success.
                   arrTemp = new int[iCount];
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("The input number is too large.(Note: The largest size is " + m_iBigestArraySize.ToString() + ")");
                    return EnumResult.PREVIOUS;
                }

                Console.WriteLine("The values are:");

                for (int i = 0; i < iCount; i++)
                {
                    string strInput2 = Console.ReadLine().ToLower();
                    if (strInput2.ToLower() == "p")
                        return EnumResult.PREVIOUS;
                    else if (strInput2.ToLower() == "e")
                        return EnumResult.EXIT;
                    else if (strInput2.ToLower() == "m")
                        return EnumResult.MAINMENU;

                    bool bValue = int.TryParse(strInput2, out int iValue);
                    if (bValue == false)
                    {
                        --i;
                        Console.WriteLine("This value is invalid. Please input again.(Note: The input will continue.)");
                        continue;
                    }
                    else
                    {
                        arrTemp[i] = iValue;
                    }
                }
                bValid = true;
                arr = arrTemp;//It's time to change the original array.
                break;
            }
            Console.WriteLine("The input array has generated.");
            return EnumResult.SUCCEED;
        }

        private static EnumResult GenerateRandomArrayBySystem(ref int[] arr, out bool bValid)
        {
            bValid = false;

            int iCount;
            int[] arrTemp = { };
            EnumResult enumValue = DealWithArraySizeInput(out iCount);
            if (enumValue != EnumResult.SUCCEED)
                return enumValue;

            try
            {
                arrTemp = Tools.CreateRandomArray(iCount);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("The input number is too large.(Note: The largest size is " + m_iBigestArraySize.ToString() + ")");
                return EnumResult.PREVIOUS;
            }

            bValid = true;
            arr = arrTemp;
            Console.WriteLine("The random array has generated.");
            return EnumResult.SUCCEED;
        }

        private static EnumResult GenerateSortedArrayBySystem(ref int[] arr, out bool bValid)
        {
            bValid = false;

            int iCount;
            int[] arrTemp = { };

            EnumResult enumValue = DealWithArraySizeInput(out iCount);
            if (enumValue != EnumResult.SUCCEED)
                return enumValue;

            try
            {
                arrTemp = Tools.CreateSortedArray(iCount);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("The input number is too large.(Note: The largest size is " + m_iBigestArraySize.ToString() + ")");
                return EnumResult.PREVIOUS;
            }
            
            bValid = true;
            arr = arrTemp;
            Console.WriteLine("The sorted array has generated.");
            return EnumResult.SUCCEED;
        }

        private static EnumResult DealWithArraySizeInput(out int iCount)
        {
            iCount = 0;
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("p)Previous  m)MainMenu  e)Exit");
                Console.WriteLine("Please input the array size.(Note: The largest size is " + m_iBigestArraySize.ToString() +"): ");
                string strInput = Console.ReadLine().ToLower();
                switch (strInput)
                {
                    case "p":
                        return EnumResult.PREVIOUS;
                    case "m":
                        return EnumResult.MAINMENU;
                    case "e":
                        return EnumResult.EXIT;
                    default:
                        break;
                }
                if (int.TryParse(strInput, out iCount) == false || iCount <= 0 || iCount > m_iBigestArraySize)
                {
                    Console.WriteLine("The input is invalid!");
                    continue;
                }
                else
                    return EnumResult.SUCCEED;
            }
        }

    }
}
