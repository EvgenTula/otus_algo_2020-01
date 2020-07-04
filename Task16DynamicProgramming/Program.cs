using System;
using System.Collections.Generic;

namespace Task16DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> p;
            //Раз/два горох
            Console.WriteLine(task1.Solution("2/100+3/100"));
            //Цифровая ёлочка
            p = new List<string>() { "4", "1", "2 3", "4 5 6", "9 8 0 3" };
            Console.WriteLine(task2.Solution(p));
            //Пятью-восемь
            Console.WriteLine(task3.Solution("3"));
            //Острова
            p = new List<string>() { "3", "1 0 1", "0 1 0", "1 0 1"};
            Console.WriteLine(task4.Solution(p));
        }
    }
}
