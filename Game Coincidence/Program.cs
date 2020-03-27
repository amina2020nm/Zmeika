using System;
using System.Threading;

namespace Game_Coincidence
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.ForegroundColor = ConsoleColor.Red;// Изменение цвета фигур
            Console.WriteLine("Выберите и напишите размер поля N x N");
            Console.WriteLine("Легкий уровень [поле10х10, скорость медленная]");
            Console.WriteLine("Средний уровень [поле15х15, скорость нормальная]");
            Console.WriteLine("Сложный уровень [поле20х20, скорость быстрая]");
            Console.WriteLine("W - Вверх");
            Console.WriteLine("S - Вниз");
            Console.WriteLine("D - Вправо");
            Console.WriteLine("A - Влево");
            Console.WriteLine("N =  N = ");
            Class1 class1 = new Class1();
            class1.Setup(class1.gameOver);
            while (!class1.gameOver)
            {
               class1.Draw();
               class1.Input_Logic();
               class1.dvigenie();
               class1.itog();
            }
            Console.ReadLine();
        }
    }
}
