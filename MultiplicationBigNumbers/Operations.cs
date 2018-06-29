using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationBigNumbers
{
    public class Operations
    {
        public static void PrintNumbers(Interface numberProvider)
        {
            for (int i = 0; i < numberProvider.Count; i++)
                Console.Write($"{numberProvider.Get_number()}");
        }

        public static string ConvertNumbers(Interface numberProvider)
        {
            string number = "";
            for (int i = 0; i < numberProvider.Count; i++)
            {
                int tmp = int.Parse(numberProvider.Get_number());
                number += tmp.ToString();
            }
            return number;
        }
    }
}
