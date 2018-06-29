using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationBigNumbers
{
    public class MultiplicationNumber
    {
        public static string Multiplication_Number(string n1, string n2)
        {
            int lenght1 = n1.Length;
            int lenght2 = n2.Length;
            if (lenght1 == 0 || lenght2 == 0)
                return "0";

            int[] intResult = new int[lenght1 + lenght2];
            //List<int> intResult = new List<int>(lenght1 + lenght2);

            int i_lenght1 = 0;
            int i_lenght2 = 0;

            for(int i = lenght1 - 1; i >= 0; i--)
            {
                int tmp = 0;
                int number1 = n1[i] - '0';  //rzutowanie string na int
                i_lenght2 = 0;
                for (int j = lenght2 - 1; j >= 0; j--)
                {
                    int number2 = n2[j] - '0';  //rzutowanie string na int
                    int product = number1 * number2 + intResult[i_lenght1 + i_lenght2] + tmp;
                    tmp = product / 10;
                    intResult[i_lenght1 + i_lenght2] = product % 10;
                    i_lenght2++;
                }
                if (tmp > 0)
                    intResult[i_lenght1 + i_lenght2] += tmp;
                i_lenght1++;
            }

            int  size = intResult.Length - 1;
            Console.WriteLine(size);
            while (size >= 0 && intResult[size] == 0)
                size--;
            if (size == -1)
                return "0";

            string result = "";
            while (size >= 0)
                result += string.Join("", intResult[size--]);   //rzutowanie tablicy int na string z odwroceniem kolejnosci liczb
            return result;
        }
    }
}
