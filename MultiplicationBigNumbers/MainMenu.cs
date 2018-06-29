using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationBigNumbers
{
    static class MainMenu
    {
        static string[] Menu_position = { "Wygeneruj liczby", "Wczytaj liczby z pliku", "Wyjście" };
        static int Active_position = 0;

        public static void Start_menu()
        {
            Console.Title = "Mnożenie liczb wielo cyfrowych";
            Console.CursorVisible = false;
            while (true)
            {
                Show_menu();
                Get_choice();
                Start_choice();
            }
        }

        static void Show_menu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Mnożenie liczb wielo cyfrowych");
            Console.WriteLine();
            for (int i = 0; i < Menu_position.Length; i++)
            {
                if (i == Active_position)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0, -35}", Menu_position[i]);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                    Console.WriteLine(Menu_position[i]);
            }
        }

        static void Get_choice()
        {
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.UpArrow)
                {
                    Active_position = (Active_position + (Menu_position.Length - 1)) % Menu_position.Length;
                    Show_menu();
                }
                else if (choice.Key == ConsoleKey.DownArrow)
                {

                    Active_position = (Active_position + 1) % Menu_position.Length;
                    Show_menu();
                }
                else if (choice.Key == ConsoleKey.Escape)
                {
                    Active_position = Menu_position.Length - 1;
                    break;
                }
                else if (choice.Key == ConsoleKey.Enter)
                    break;
            } while (true);
        }

        static void Start_choice()
        {
            string number1 = "";
            string number2 = "";
            switch (Active_position)
            {
                case 0:
                    Console.Clear();

                    RandomNumber randomNumber1 = new RandomNumber();
                    number1 = Operations.ConvertNumbers(randomNumber1);
                    Console.WriteLine($"Pierwsza liczba: {number1}");

                    RandomNumber randomNumber2 = new RandomNumber();
                    number2 = Operations.ConvertNumbers(randomNumber2);
                    Console.WriteLine($"\nDruga liczba: {number2}");

                    Console.WriteLine($"\nIloczyn liczb: {MultiplicationNumber.Multiplication_Number(number1, number2)}");

                    Console.ReadKey();
                    break;
                case 1:
                    Console.Clear();

                    FromFileNumber fileNumber1 = new FromFileNumber("data.txt", 1);
                    number1 = Operations.ConvertNumbers(fileNumber1);
                    Console.WriteLine($"Pierwsza liczba: {number1}");

                    FromFileNumber fileNumber2 = new FromFileNumber("data.txt", 2);
                    number2 = Operations.ConvertNumbers(fileNumber2);
                    Console.WriteLine($"\nDruga liczba: {number2}");

                    Console.WriteLine($"\nIloczyn liczb: {MultiplicationNumber.Multiplication_Number(number1, number2)}");

                    Console.ReadKey();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
