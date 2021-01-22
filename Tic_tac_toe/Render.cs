using System;

namespace Learning_projects.Tic_tac_toe
{
    public class Render
    {
        public void Border(int x, int y)
        {
            char verticalBorder = '|';
            char horizontalBorder = '–';
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < x; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(horizontalBorder);
            }

            for (int i = 0; i < x; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(horizontalBorder);
            }

            for (int j = 0; j < y; j++)
            {
                Console.Write(verticalBorder);
                Console.SetCursorPosition(0, j);
            }
            
            for (int j = 0; j < y; j++)
            {
                Console.Write(verticalBorder);
                Console.SetCursorPosition(x, j);
            }

        }
    }
}