using System;
using System.Linq;


namespace HomeWork4_File
{


    internal class Program
    {
        /// <summary>
        /// Меняет местами два элемента массива по индексам
        /// </summary>
        /// <returns></returns>
        // Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
        //которые нужно поменять местами.Вывести на экран получившийся массив.
        static int[] Task1()
        {
            Random rnd = new Random();
            int[] RandomInts = new int[20];
            for (int i = 0; i < RandomInts.Length; i++)
            {
                RandomInts[i] = rnd.Next(0, 1000);
            }

            foreach (int i in RandomInts)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\nВведите два номера от 0 до 19");

            if (!byte.TryParse(Console.ReadLine(), out byte firstIndex) || firstIndex>19 || firstIndex<0)
            {
                Console.WriteLine("Вы не ввели коректное число поэтому первый индекс будет 0");
                firstIndex = 0;
            }

            if (!byte.TryParse(Console.ReadLine(),out byte secondIndex) || secondIndex > 19 || secondIndex < 0)
            {
                Console.WriteLine("Вы не ввели коректное число поэтому второй индекс будет 1");
                secondIndex = 1;
            }

            (RandomInts[firstIndex], RandomInts[secondIndex]) = (RandomInts[secondIndex], RandomInts[firstIndex]);
            return RandomInts;
        }

        /// <summary>
        /// Возврает сумму элементов массива, изменяет переменную произведения элементов массива, и среднего арифмитического
        /// </summary>
        /// <param name="product"></param>
        /// <param name="average"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        // Написать метод, где в качества аргумента будет передан массив (ключевое слово
        //params). Вывести сумму элементов массива(вернуть). Вывести(ref) произведение
        //массива.Вывести(out) среднее арифметическое в массиве.
        static int Task2(ref int product, out double average, params int[] numbers)
        {
            Console.WriteLine("\n\nЗадание 2");
            foreach (int i in numbers)
            {
                product *= i;
            }
            average = numbers.Average();
            return numbers.Sum();
        }


        /// <summary>
        /// Выводит рисунки цифр на экран
        /// </summary>
        // Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
        //изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
        //должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке.Если
        //пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
        //завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
        //должны сработать) - консоль закроется.
        static void Task3()
        {
            Console.WriteLine("\nЗадание 3");
            string? readline;
            bool isExit = false;

            while (!isExit)
            {
                Console.WriteLine("Введите цифру \nЧтобы выйти из программы введите \"exit\" или \"закрыть\"");

                readline = Console.ReadLine().ToLower();
                if (readline == "exit" || readline == "закрыть")
                {
                    isExit = true;
                }
                else if (!int.TryParse(readline, out int number))
                {
                    Console.WriteLine("Вы ввели не число");
                }
                else
                {
                    switch (number)
                    {
                        case 0:
                            Console.WriteLine("  ##  \n #  # \n#    #\n#    #\n #  # \n  ##  ");
                            break;
                        case 1:
                            Console.WriteLine("  ##\n ###\n  ##\n  ##\n  ##\n  ##");
                            break;
                        case 2:
                            Console.WriteLine(" ## \n#  #\n  # \n #  \n####");
                            break;
                        case 3:
                            Console.WriteLine(" ## \n   #\n  # \n   #\n ## ");
                            break;
                        case 4:
                            Console.WriteLine("#  #\n#  #\n####\n   #\n   #");
                            break;
                        case 5:
                            Console.WriteLine("####\n#   \n### \n  # \n##  ");
                            break;
                        case 6:
                            Console.WriteLine(" ## \n#   \n### \n#  #\n ## ");
                            break;
                        case 7:
                            Console.WriteLine("####\n  # \n #  \n #  \n#   ");
                            break;
                        case 8:
                            Console.WriteLine(" ## \n#  #\n ## \n#  #\n ## ");
                            break;
                        case 9:
                            Console.WriteLine(" ## \n#  #\n ## \n   #\n ## ");
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.Red;
                            System.Threading.Thread.Sleep(3000);
                            Console.WriteLine("ERROR цифра - это от 0 до 9");
                            Console.ResetColor();
                            break;
                    }
                }             
                
            }
            return;
        }


        /// <summary>
        /// Возможные уровни: light, medium, hard, epic
        /// </summary>
        public enum GrumpinessLevel
        {
            light,
            medium,
            hard,
            epic
        }
        /// <summary>
        /// Дед имеет имя, уровень ворчливости, словарный запас, жену
        /// </summary>
        struct Ded
        {
            public string name;
            public GrumpinessLevel level; 
            /// <summary>
            /// Матерные слова деда
            /// </summary>
            public string[] cursWords;
            /// <summary>
            /// Кол-во синяков зависит от матерных слов
            /// </summary>
            public int bruiseCount;
            /// <summary>
            /// Возвращает кол-во фингалов у деда
            /// </summary>
            /// <param name="curses"></param>
            /// <returns></returns>
            public int bruiseMaker(string[] curses)
            {
                return curses.Length;
            }
        }

        //Создать структуру Дед.У деда есть имя, уровень ворчливости(перечисление), массив
        //фраз для ворчания(прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
        //бабки = 0 по умолчанию.Создать 5 дедов.У каждого деда - разное количество фраз для
        //ворчания.Напишите метод (внутри структуры), который на вход принимает деда,
        //список матерных слов (params). Если дед содержит в своей лексике матерные слова из
        //списка, то бабка ставит фингал за каждое слово.Вернуть количество фингалов.
        static int Task4()
        {
            Ded Valera = new Ded()
            {
                name = "Валера",
                level = GrumpinessLevel.light,
                cursWords = ["C#ка", "Бл#ть", "Н#гр"],
            };
            Valera.bruiseCount = Valera.bruiseMaker(Valera.cursWords);

            Ded Sergey = new Ded()
            {
                name = "Cергей",
                level = GrumpinessLevel.medium,
                cursWords = ["C#ка", "Бл#ть", "Н#гр", "Х#й", "Зал#па", "П#нис"],
            };
            Sergey.bruiseCount = Sergey.bruiseMaker(Sergey.cursWords);

            Ded Petrovich = new Ded()
            {
                name = "Петрович",
                level = GrumpinessLevel.hard,
                cursWords = ["C#ка", "Бл#ть", "Н#гр", "Х#й", "Зал#па", "П#нис", "Выбл#док", "Г#ндон"],
            };
            Petrovich.bruiseCount = Petrovich.bruiseMaker(Petrovich.cursWords);

            Ded Nikitich = new Ded()
            {
                name = "Никита",
                level = GrumpinessLevel.epic,
                cursWords = ["C#ка", "Бл#ть", "Н#гр", "Х#й", "Зал#па", "П#нис", "Выбл#док", "Г#ндон", "Челип#здрк", "Подз#лупышь"],
            };
            Nikitich.bruiseCount = Nikitich.bruiseMaker(Nikitich.cursWords);

            Ded Procofevih = new Ded()
            {
                name = "Прокофьевич",
                level = GrumpinessLevel.epic,
                cursWords = ["C#ка", "Бл#ть", "Н#гр", "Х#й", "Зал#па", "П#нис", "Выбл#док", "Г#ндон", "Челип#здрк", "Подз#лупышь"],
            };
            Procofevih.bruiseCount = Procofevih.bruiseMaker(Procofevih.cursWords);

            return Valera.bruiseCount + Sergey.bruiseCount + Petrovich.bruiseCount + Nikitich.bruiseCount + Procofevih.bruiseCount;
        }

        static void Main(string[] args)
        {
            int[] newRanomInts = Task1();
            foreach (int i in newRanomInts) 
            {
                Console.Write($"{i} "); 
            }

            int product = 1;
            double average;
            Console.WriteLine($"Сумма чисел: {Task2(ref product, out average, 3, 4, 5, 6, 7, 1, 3)}\nПроизведение элементов: {product}\nСреднее арифмитическое: {average}");

            Console.WriteLine("Введите число от 0 до 9");
            Task3();
            Console.WriteLine(Task4());

            Console.ReadKey();
        }
    }
}
