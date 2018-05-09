using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorC.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string operator_ = "";
            bool flag = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Калькулятор");
                Console.WriteLine("2 - Возвести число в степень");
                Console.WriteLine("3 - Количество цифр в числе");
                Console.WriteLine("Любой другой символ - Выход");

                Console.Write("Выберите пункт меню: ");
                operator_ = Console.ReadLine();
                switch (operator_)
                {
                    case "1":
                        {
                            Console.Clear();
                            double sum = 0, x, y;
                            Console.WriteLine("Для чисел с плавающей точкой используйте \",\"!");
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите первое число: ");
                                    x = Double.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: Вы ввели неверное число!");
                                    continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите второе число: ");
                                    y = Double.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: Вы ввели неверное число!");
                                    continue;
                                }
                                break;
                            }
                            bool CycleFlag = true;
                            while (CycleFlag)
                            {
                                Console.Write("Введите оператор: ");
                                operator_ = Console.ReadLine();
                                switch (operator_)
                                {
                                    case "+":
                                        sum = x + y;
                                        CycleFlag = false;
                                        break;
                                    case "-":
                                        sum = x - y;
                                        CycleFlag = false;
                                        break;
                                    case "*":
                                        sum = x * y;
                                        CycleFlag = false;
                                        break;
                                    case "/":
                                        if (y != 0)
                                            sum = x / y;
                                        else
                                        {
                                            y = 1;
                                            sum = x / y;
                                            Console.WriteLine("Делить на 0 нельзя, выполнено деление на 1");
                                        }
                                        CycleFlag = false;
                                        break;
                                    default:
                                        continue;
                                }
                            }
                            Console.WriteLine("{0} {1} {2} = {3}", x, operator_, y, sum);
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            int tmp, x, i;                            
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите целое число: ");
                                    tmp = x = Int32.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: Вы ввели неверное число!");
                                    continue;
                                }
                                break;
                            }
                            for (i = 1; tmp >= 10; i++)
                            {
                                tmp /= 10;
                            }                            
                            Console.WriteLine("В числе {0} {1} цифр", tmp, i);
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            int degree;
                            double x, tmp;
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите целое число: ");
                                    tmp = x = Double.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: Вы ввели неверное число!");
                                    continue;
                                }
                                break;
                            }
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Введите степень, в которую нужно возвести число {0}: ", tmp);
                                    degree = Int32.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: Вы ввели неверное число!");
                                    continue;
                                }
                                break;
                            }
                            if (degree == 0)
                            {
                                x = 1;
                            }
                            else if (degree > 0)
                            {
                                for (int i = 1; i < degree; i++)
                                {
                                    x *= x;
                                }
                            }
                            else if (degree < 0)
                            {
                                for (int i = 1; i < degree; i++)
                                {
                                    x *= x;
                                }
                                x = 1 / x;
                            }
                            Console.WriteLine("Число {0} в степени {1} равно {2}", tmp, degree, x);
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        flag = false;
                        break;
                }
            } while (flag);
        }
    }
}
