using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6//1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
{
    delegate double function(double arg);
    class Program
    {
        //static void Plot(function f, int min, int max)
        //{
        //    for (double x = min; x <= max; x++)
        //    {
        //        Console.WriteLine($"f({x}) = {Math.Round(f(x), 2)}");
        //    }
        //    Console.WriteLine();
        //}
        static void MulPlot(function f, double min, double max, double mul)
        {
            for (double x = min; x <= max; x++)
            {
                Console.WriteLine($"f({x}) = {mul*(f(x)), 2}");
            }
            Console.WriteLine();
        }

        static double pa(double q)
        {
            return q * q;
        }

        static void Main(string[] args)
        {
            MulPlot(Math.Sin, -10.55, 10.74, 5.54);
            MulPlot(pa, -10.64, 10.72, 5.24);
            Console.ReadLine();
        }
    }
}
