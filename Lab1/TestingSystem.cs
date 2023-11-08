using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*This TestingSystem is divided into four moudules including "Generate Array" module, "Print Fortmat" module, "Searching Test" module
 * and "Sorting Test" module. Cui_20230401*/
namespace Lab1
{
    enum EnumResult{
        FAILED = -1,
        EXIT = 0,
        SUCCEED,
        PREVIOUS,
        CONTINUE,
        MAINMENU,       
    }
    enum EnumDataStructrue
    {
        ARRAY = 0,
        LIST,
    }
    sealed class TestingSystem
    {
        private EnumDataStructrue m_enumCurrentDataStructure = EnumDataStructrue.ARRAY;//default is array.
        private int[] m_array = { };
        private static string m_strMark = "----------------------------------------------------------------";
        public TestingSystem() { }
        public void Launch()
        {
            Console.WriteLine(m_strMark);
            Console.WriteLine("          Welcome to the testing system of Lab1.");
            Console.WriteLine("Note: The test module always manipulate the latest generated array.");
            Console.WriteLine(m_strMark);

            while (true)
            {
                Console.WriteLine(m_strMark);
                string strOption;
                Console.WriteLine("1)Seaching Test  2)Sorting Test  3)Generate Array  4)Print formatted Array  e)Exit");
                strOption = Console.ReadLine().ToLower();
                EnumResult enumResult;
                switch (strOption)
                {
                    case "1":
                        enumResult = SearchingTestModule.SearchingTest(m_array);
                        break;
                    case "2":
                        enumResult = SortingTestModule.SortingTest(m_array);
                        break;
                    case "3":
                        enumResult = GenerateArrayModule.GenerateArray(ref m_array, out bool bValid);
                        break;
                    case "4":
                        enumResult = PrintModule.Print(m_array);
                        break;
                    case "e":
                        enumResult = EnumResult.EXIT;
                        break;
                    default:
                    {
                        Console.WriteLine("The input is invalid. Please enter a valid instruction.");
                        continue;
                    }
                }
                //Other status value shouldn't make the system exit except EnumResult.EXIT.
                if (enumResult == EnumResult.EXIT)
                    break;
/*                else if (enumResult == EnumResult.PREVIOUS || enumResult == EnumResult.SUCCEED || enumResult == EnumResult.MAINMENU)
                    continue;*/
            }
        }      
    }
}
