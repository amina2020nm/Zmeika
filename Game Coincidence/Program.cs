using System;

namespace Game_Coincidence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;// Изменение цвета фигур
            Console.WriteLine("Выберите и введите номер:");
            Console.WriteLine("Легкий уровень [поле10х10, скорость медленная] - Введите 1");
            Console.WriteLine("Средний уровень [поле15х15, скорость нормальная] - Введите 2");
            Console.WriteLine("Сложный уровень [поле20х20, скорость быстрая] - Введите 3");
            Console.WriteLine("W - Вверх");
            Console.WriteLine("S - Вниз");
            Console.WriteLine("D - Вправо");
            Console.WriteLine("A - Влево");
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
