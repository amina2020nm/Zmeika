// Гурбанов Нурлан гр.682
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game_Coincidence
{
    class Class1
    {
        public bool gameOver = false;
        int schet = 0;
        int x;
        int y;
        int celX, celY;
        public int S = Convert.ToInt32(Console.ReadLine());
        public int V = Convert.ToInt32(Console.ReadLine());
        int[] hvostX = new int[1000];// Массив для хвоста с значением Х
        int[] hvostY = new int[1000];// Массив для хвоста с значением У
        int nomerhv;
        Random R = new Random();
        ConsoleKeyInfo knopki;
        public bool Setup(bool gameOver)// Заданые переменные 
        {
            gameOver = false;// Игра закончена = ложь
            if (S == V)
            {
                x = S / 2 - 1;
                y = V / 2 - 1;
            }
            celX = R.Next(3, S - 2);// Рандомное значения фрукты
            celY = R.Next(3, S - 2);// Рандомное значения фрукты
            Console.WriteLine();
            return gameOver;// Возращение значения игры
        }
        public void Draw()// Карта и персонажи
        {   
            if (S == 10 && V == 10)
                Thread.Sleep(200);
            if (S == 15 && V == 15)
                Thread.Sleep(100);
            if (S >= 20 && V >= 20)
                Thread.Sleep(50);
            Console.WriteLine();
            Console.SetCursorPosition(0, 8);// Позиция курсора
            for (int i = 0; i < V + 1; i++)
            Console.Write("#");// Верхняя граница
            Console.WriteLine();

            for (int i = 0; i < S; i++)
            {
                for (int j = 0; j < S; j++)
                {
                    if (j == 0 || j == S - 1)
                        Console.Write((char)47);// Боковые границы
                    if (i == y && j == x )
                        Console.Write((char)79); // Выдаст O// Голова змейки
                    else if (i == celY && j == celX)
                        Console.Write((char)70); // Выдаст F// Расположение фрукты
                    else
                    {
                        bool print = false;

                        for (int k = 0; k < nomerhv; k++)
                        {
                            if (hvostX[k] == j && hvostY[k] == i)
                            {
                                print = true;
                                Console.Write((char)79); // Выдаст O// Рисование хвоста
                            }
                        }
                        if (!print)
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            for (int j = 0; j < S + 1; j++)
            Console.Write("#");// Нижняя граница
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Количество баллов: " + schet);
            Console.WriteLine();
            Console.WriteLine("Задача игры: Вы должны съесть как можно много фрукта 'F'");
            Console.WriteLine("Выше отображается количество баллов, за каждый съеданный фрукт +10 балла");
        }
        public void Input_Logic()
        {
            int predznX = hvostX[0];// Предудыщий значение хвоста
            int predznY = hvostY[0];
            int pred2X;
            int pred2Y;
            hvostX[0] = x;// Значение хвоста Х = значение Х
            hvostY[0] = y;// Значение хвоста У = значение У
            for (int i = 1; i < nomerhv; i++)
            {
                pred2X = hvostX[i];
                pred2Y = hvostY[i];
                hvostX[i] = predznX;
                hvostY[i] = predznY;
                predznX = pred2X;
                predznY = pred2Y;
            }
        }
        public void dvigenie()
        {
            if (Console.KeyAvailable == true)
            { knopki = Console.ReadKey(true); }          
            switch (knopki.Key)
            {
                case ConsoleKey.W:
                    y--;// Вверх
                    break;

                case ConsoleKey.S:
                    y++;// Вниз
                    break;

                case ConsoleKey.D:
                    x++;// Вправо
                    break;

                case ConsoleKey.A:
                    x--;// Влево
                    break;
            }
        }
        public void itog()
        { 
            if (x > S)//
                x = 0;//
            else if (x < 0)//
                x = S - 2;// Выход за границы поля и обратное появление с другой стороны
            if (y > V)//
                y = 0;//
            else if (y < 0)//
                y = V - 2;//
            for (int g = 0; g < nomerhv; g++)
            {
                if (hvostX[g] == x && hvostY[g] == y)
                {
                    gameOver = true;
                    Console.WriteLine("                             Вы проиграли!!!");
                    Console.WriteLine("Выберите и напишите размер поля N x N");
                    Console.WriteLine("Нажмите ENTER");
                    Console.ReadKey();
                }              
            }
            if (gameOver != false)
            {
                Console.Clear();
                {
                    Class1 class1 = new Class1();
                    class1.Setup(class1.gameOver);
                    while (!class1.gameOver)
                    {
                        class1.Draw();
                        class1.Input_Logic();
                        class1.dvigenie();
                        class1.itog();
                    }
                    Console.ReadKey(true);
                }
            }
            if (x == celX && y == celY)
            {
                schet += 10;// Суммирование баллов
                celX = R.Next(3, S - 2);
                celY = R.Next(3, S - 2);
                nomerhv++;
            }
        }    
    }
}