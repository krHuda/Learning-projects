using System;
using System.Collections.Generic;

namespace Learning_projects.Tic_tac_toe
{
    /// <summary>
    /// В данном классе реализована вся логика игры. Вывод меню, получение координат для отрисовки крестиков и ноликов, выявление состояния победы и т.д.
    /// </summary>
    public class GameLogic
    {
        /// <summary>
        /// Список клавиш для игры
        /// </summary>
        List<int> keys = new List<int>(8) { 97, 98, 99, 100, 101, 102, 103, 104, 105 };

        /// <summary>
        /// Данный метод отвечает за вывод меню и запуск игры
        /// </summary>
        public void StartGame()
        {
            Render render = new Render();
            do
            {
                render.StartScreen();
            } while (Convert.ToBoolean(Console.Read()));
        }

        public (int firstX, int secondX, int firstY, int secondY) GetCoordinates(int width, int height)
        {
            int firstX = 0;
            int secondX = 0;
            int firstY = 0;
            int secondY = 0;

            keys.Sort();
            int key = Console.Read();

            switch (key)
            {
                case 97:
                    
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                case 104:
                    

                default: break;
            }
            
            return (firstX, secondX, firstY, secondY);
        }

    }
}