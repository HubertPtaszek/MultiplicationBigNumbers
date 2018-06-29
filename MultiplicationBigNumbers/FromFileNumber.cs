using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiplicationBigNumbers
{
    public class FromFileNumber : Interface
    {
        public string FilePath { get; set; }

        private string number;
        private CharEnumerator numberEnumerator;

        public int Count => number.Length;

        public FromFileNumber(string fileName, int i)
        {
            FilePath = fileName;
            FileInfo file = new FileInfo(fileName);
            long lenght = file.Length / 1000;
            if (i <= lenght)
            {
                string tmp = File.ReadAllText(FilePath);
                string[] numbers = new string[1];
                numbers = tmp.Split('\t');
                number = numbers[i - 1];
                numberEnumerator = number.GetEnumerator();
            }
        }

        public string Get_number()
        {
            if (numberEnumerator.MoveNext())
                return numberEnumerator.Current.ToString();
            else
                throw new IndexOutOfRangeException();  //błąd gdy przekroczymy indeks kolekcji
        }
    }
}
