
using System;
using System.Collections;
using System.IO;
namespace delegate_2_
{
    class Program
    {
        //Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        //а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
        //б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
        //в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
        //возвращает минимум через параметр.
        public delegate double function(double x);

        
        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x  - 50 * x + 10;
        }

        public static double F3(double x)
        {
            return x * x + 10;
        }


        static function[] delegates = new function[]{ //б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
                new function( Program.F ),
                new function( Program.F2 ),
                new function( Program.F3 ),
        };

        public static void SaveFunc(function f, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static ArrayList Load(string fileName, string param)//в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
        //возвращает минимум через параметр.
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            ArrayList list = new ArrayList();
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                if (param == "Min")
                {
                    d = bw.ReadDouble();
                    if (d < min) min = d;
                    list.Clear();
                    list.Add(d);
                }

                else if (param == "Array")
                {
                    d = bw.ReadDouble();
                    list.Add(d);
                }
            }
            bw.Close();
            fs.Close();
            return list;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введие необходимую функцию. Варианты: Sin, Cos, F, F2, F3");
            string nowfunct = Console.ReadLine();
            Console.WriteLine("Введие координату начала отрезка, на котором нужно найти минимум функции");
            int otr1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введие координату окончания отрезка, на котором нужно найти минимум функции");
            int otr2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите параметр Min, чтобы получить минимум функции, или Array, чтобы получить массив");
            string param = Console.ReadLine();

            if (nowfunct == "F")
            {
                SaveFunc(delegates[0], "data.bin", otr1, otr2, 0.5) ;
            }
            else if (nowfunct == "F2")
            {
                SaveFunc(delegates[1], "data.bin", otr1, otr2, 0.5);
            }
            else if (nowfunct == "F3")
            {
                SaveFunc(delegates[2], "data.bin", otr1, otr2, 0.5);
            }
            else if (nowfunct == "Sin")
            {
                SaveFunc(Math.Sin, "data.bin", otr1, otr2, 0.5);
            } else if (nowfunct == "Cos")
            {
                SaveFunc(Math.Cos, "data.bin", otr1, otr2, 0.5);
            }
            foreach(double num in Load("data.bin", param))
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}

