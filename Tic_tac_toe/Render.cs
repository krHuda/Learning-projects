using System;

namespace Learning_projects.Tic_tac_toe
{
    public class Render
    {
        private char verticalBorder = '│';
        private char horizontalBorder = '─';

        /// <summary>
        /// Данный метод рисует заданным символом в заданных координатах
        /// </summary>
        private static void DrawHorizontal(char symbol, int width, int height, int horizontalOfset = 0, int verticalOfset = 0)
        {
            try
            {
                for (int i = 0 + horizontalOfset; i < width; i++)
                {
                    Console.SetCursorPosition(i, height + verticalOfset);
                    Console.Write(symbol);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private static void DrawVertical(char symbol, int width, int height, int horizontalOfset = 0, int verticalOfset = 0)
        {
            try
            {
                for (int i = 0 + verticalOfset; i < height; i++)
                {
                    Console.SetCursorPosition(width + horizontalOfset, i);
                    Console.Write(symbol);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Отрисовка границ окна
        /// </summary>
        public void DrawBorder(int width, int height, int horizontalOfset = 0, int verticalOfset = 0)
        {
            Console.Clear();

            DrawVertical(verticalBorder, 0, height);
            DrawHorizontal(horizontalBorder, width, height);
            DrawVertical(verticalBorder, width, height);
            DrawHorizontal(horizontalBorder, width, 0);

            Console.SetCursorPosition(width, 0);
            Console.Write('┐'); //╭ ╮ ╯ ╰ // ┌ ┐ └ ┘ //Разные варианты углов

            Console.SetCursorPosition(width, height);
            Console.Write('┘');

            Console.SetCursorPosition(0, width);
            Console.Write('└');

            Console.SetCursorPosition(0, 0);
            Console.Write('┌');
        }

        /// <summary>
        /// Данный метод отрисовывает сетку по горизонтали.
        /// </summary>
        public void DrawGridHorizontal(int width, int height)
        {
            height /= 3;
            DrawHorizontal(horizontalBorder, width, height, 1, 0);

            height *= 2;
            DrawHorizontal(horizontalBorder, width, height, 1, 0);
        }
        
        /// <summary>
        /// Данный метод отрисовывает сетку по вертикали.
        /// </summary>
        public void DrawGridVertical(int width, int height)
        {
            width /= 3;
            DrawVertical(verticalBorder, width, height, 0, 1);

            width *= 2;
            DrawVertical(verticalBorder, width, height, 0, 1);
        }

        public void DrawX(int width, int height) //ToDo Реализовать получение координат блока и рисовку крестика.
        {
            
        }

        public void DrawO(int width, int height) //ToDo Реализовать получение координат блока и рисовку нолика.
        {
        
        }
    }
}