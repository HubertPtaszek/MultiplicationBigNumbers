using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationBigNumbers
{
    public class RandomNumber : Interface
    {
        private string number = "";
        private CharEnumerator numberEnumerator;
        private Random random = new Random(DateTime.Now.Millisecond);

        public int Count => number.Length;

        public RandomNumber()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 0)  //zabezpieczenie zeby pierwsza cyfra liczby nie wynosiła 0
                {
                    int tmp = random.Next(1, 9);
                    number = number.Insert(i, tmp.ToString());
                }
                else  //kolejne cyfry liczby z przedziału od 0 do 9
                {
                    int tmp = random.Next(0, 9);
                    number = number.Insert(i, tmp.ToString());
                }
            }
            numberEnumerator = number.GetEnumerator();
        }

        public string Get_number()
        {
            if (numberEnumerator.MoveNext())
                return numberEnumerator.Current.ToString();
            else
                throw new IndexOutOfRangeException(); //błąd gdy przekroczymy indeks kolekcji
        }
    }
}
