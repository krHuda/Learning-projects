using System;
using System.Collections.Generic;

namespace Learning_projects.Tic_tac_toe
{
    /// <summary>
    /// В данном классе реализована вся логика игры. Вывод меню, получение координат для отрисовки крестиков и ноликов, выявление состояния победы и т.д.
    /// </summary>
    public class GameLogic
    {
        Render render = new Render();

        /// <summary>
        /// Данный метод отвечает за вывод меню и запуск игры
        /// </summary>
        public void StartGame()
        {
            do
            {
                render.StartScreen();
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        render.GameScreen();
                        break;

                    default:
                        Console.Clear();
                        render.DrawBorder(defaultSettings.Width, defaultSettings.Height);
                        Console.SetCursorPosition(defaultSettings.Width / 4, defaultSettings.Height / 2);
                        Console.Write("Нажата не та клавиша, нажмите \n\t любую клавишу что бы вернуться в меню");
                        Console.ReadKey();
                        continue;
                }

            } while (GameState());

            render.WinScreen();
        }

        public int[] GetCoordinates(int width, int height, ConsoleKeyInfo key)
        {
            int firstX = 0;
            int secondX = 0;
            int firstY = 0;
            int secondY = 0;

            int[] coordinates = new int[4] { firstX, secondX, firstY, secondY };

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                    coordinates[0] = 0;                 //firstX
                    coordinates[1] = width / 3;         //secondX
                    coordinates[2] = height;            //firstY
                    coordinates[3] = height / 3 * 2;    //secondY
                    return coordinates;
                case ConsoleKey.NumPad2:
                    coordinates[0] = width / 3;         //firstX
                    coordinates[1] = width / 3 * 2;     //secondX
                    coordinates[2] = height;            //firstY
                    coordinates[3] = height / 3 * 2;    //secondY
                    return coordinates;
                case ConsoleKey.NumPad3:
                    return coordinates;
                case ConsoleKey.NumPad4:
                    return coordinates;
                case ConsoleKey.NumPad5:
                    return coordinates;
                case ConsoleKey.NumPad6:
                    return coordinates;
                case ConsoleKey.NumPad7:
                    return coordinates;
                case ConsoleKey.NumPad8:
                    return coordinates;
                case ConsoleKey.NumPad9:
                    return coordinates;

                default:
                    Console.Write("Нажата не предусмотренная кнопка");
                    return coordinates;
            }

        }
        private bool GameState()
        {
            return true;
        }

    }
}