using System;
using System.Threading.Tasks;


namespace HomeWork4_Tymakov
{
    internal class Program
    {
        /// <summary>
        /// Возвращает наибольшее из двух чисел
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        static double Task1(double number1, double number2)
        {
            //Написать метод, возвращающий наибольшее из двух
            //чисел.Входные параметры метода – два целых числа.Протестировать метод.
            Console.WriteLine("Задание 1");
            return number1 >= number2 ? number1 : number2;
        }

        /// <summary>
        /// Меняет местами две меременные
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static string Task2(ref string x, ref string y)
        {
            //Написать метод, который меняет местами значения двух передаваемых
            //параметров.Параметры передавать по ссылке. Протестировать метод.
            (x, y) = (y, x);
            return $"{x}, {y}";
        }

        /// <summary>
        /// Возвращает true если программа способна найти факториал числа и false если нет
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        static bool Task3(int number, out long result)
        {
            //Написать метод вычисления факториала числа, результат вычислений
            //передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
            //если в процессе вычисления возникло переполнение, то вернуть значение false.Для
            //отслеживания переполнения значения использовать блок checked.
            Console.WriteLine("\nЗадание 3");
            result = 1;
            try
            {
                for (int i = 2; i<=number; i++) {
                    checked
                    {
                        result *= i;
                    }
                }
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }

        // Написать рекурсивный метод вычисления факториала числа.
        /// <summary>
        /// Рекурсивное нахождение факториала числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static long Task4(int number)
        {
            if (number == 0) return 1;

            return number * Task4(number-1);
        }

        /// <summary>
        /// Возвращает наибольший общий делитель. Принимает только положительные числа
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        //Написать метод, который вычисляет НОД двух натуральных чисел
        //(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
        //натуральных чисел.
        static int Task5(int number1, int number2)
        {
            (number1, number2) = (Math.Max(number1, number2), Math.Min(number1, number2));

            if ((double)number1 % number2 == 0) return number2;
            if (number2 <= 0 || number1 <= 0) return -1;
            
            int remainder = number1 % number2;
            return Task5(number2, remainder);
        }

        /// <summary>
        /// Возвращает число последовательности фибоначи под n номером
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Task6(int n) 
        {
            if (n == 0 || n == 1) return n;

            return Task6(n - 1) + Task6(n - 2);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Task1(3.9, 2));

            Console.WriteLine("\nЗадание 2\n\"Введите два элемента которые хотите поменять местами: \"");
            string firstFrase = Console.ReadLine();
            string secondFrase = Console.ReadLine();

            Console.WriteLine(Task2(ref firstFrase, ref secondFrase));


            Console.WriteLine(Task3(100, out _));

            Console.WriteLine("\nЗадание 4");

            long result = Task4(200);
            if (result < 1)
            {
                Console.WriteLine("Переполнение данных");
            }
            else 
            {
                Console.WriteLine(result);
            }


            Console.WriteLine("\nЗадание 5");

            if (Task5(5, 10) == -1)
            {
                Console.WriteLine("Числа должны быть положительными");
            }
            else
            {
                Console.WriteLine(Task5(5, 10));
            }


            Console.WriteLine($"\nЗадание 6\n{Task6(6)}");

            Console.ReadKey();
        }
    }
}
