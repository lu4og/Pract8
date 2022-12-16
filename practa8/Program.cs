using System;
using System.Runtime.Intrinsics.X86;
using Newtonsoft.Json;
namespace Pract8
{
    class g
    {
        public string name;
        public int min;
        public decimal sec;
    }
    class baza
    {
        static string Name;
        static int i;
        static int secund;
        Thread potok1;
        private static int tm = 1;
        private static List<g> all = new List<g>();
        public void nach()
        {
            Console.Clear();
            Console.WriteLine("Список результатов:\n---------------------");
            all.Sort((x, y) =>
            {
                int ret = String.Compare($"{x.min}", $"{y.min}");
                return ret != 0 ? ret :
                x.min.CompareTo(y.min);
            });
            foreach (g h in all)
            {
                Console.WriteLine($"{h.name} - Количество символов в минуту = {h.min} и количество символов в секунду = {h.sec}");
            }
            Console.WriteLine("Добавить себя в список - '+'");
        }
        public void pechatanie()
        {
            Console.Clear();
            Console.WriteLine("Введите имя:");
            Name = Console.ReadLine();
            i = 0;
            int pos = 0;
            int sop = 0;
            Console.Clear();
            string txt = "Киберпанк — жанр научной фантастики, отражающий упадок человеческой культуры на фоне технологического прогресса в компьютерную эпоху. В мире. Киберпанка высокое технологическое развитие соседствует с глубоким социальным расслоением, нищетой, бесправием, уличным беспределом в городских трущобах. ";
            char[] text = txt.ToCharArray();
            ConsoleKeyInfo a;
            do
            {
                Console.Clear();
                Console.WriteLine(txt);
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Как только будете готовы - нажмите Enter");
                a = Console.ReadKey(true);
            } while (a.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.WriteLine(txt);
            potok1 = new Thread(Nwpotok);
            potok1.Start();
            do
            {
                Console.SetCursorPosition(sop, pos);
                ConsoleKeyInfo s = Console.ReadKey(true);
                if (s.KeyChar == text[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(sop, pos);
                    Console.WriteLine(text[i]);
                    Console.ResetColor();
                    i++;
                    sop++;
                    if (sop == 120)
                    {
                        sop = 0;
                        pos++;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(sop, pos);
                    Console.WriteLine(text[i]);
                    Console.ResetColor();
                }
            } while (tm != 0 && i != text.Length);
            tm = 1;
        }
        static void Nwpotok()
        {
            secund = 0;
            int atm = 10;
            while (atm != 0)
            {
                Console.SetCursorPosition(15, 10);
                if (atm == 60)
                {
                    Console.WriteLine("1:00");
                }
                if (atm < 60 && atm > 0)
                {
                    Console.WriteLine($"0:{atm}");
                }
                if (atm == 0)
                {
                    tm = 0;
                }
                atm--;
                secund++;
                Thread.Sleep(1000);
                Console.SetCursorPosition(15, 10);
                Console.WriteLine("     ");
            }
            Console.SetCursorPosition(15, 10);
            Console.WriteLine($"0:0");
            Thread.Sleep(400);
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Стоп!!! ЧТобы продолжить - нажмите любую клавишу...");
            ser();
            tm = 0;
        }
        static void ser()
        {
            g hy = new g();
            hy.name = Name;
            hy.min = i * (60 / secund);
            hy.sec = (decimal)i / secund;
            all.Add(hy);
            tm = 1;
            File.WriteAllText("C:\\Users\\lu4lu\\OneDrive\\Рабочий стол\\res.json", JsonConvert.SerializeObject(all));
        }
    }

    internal class Program
    {
        static void Main()
        {
            baza r = new baza();
            while (true)
            {
                ConsoleKeyInfo key;
                do
                {
                    r.nach();
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Add);
                r.pechatanie();
            }
        }
    }
}