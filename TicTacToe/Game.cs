using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        static void Main()
        {
            Field f = new Field();
            f.StartGame();
            while (true)
            {
                f.GetPosition();                                         //Получить адрес клетки и сделать ход
                if (f.EoG())
                    break;
            }
            Console.WriteLine("Thanks for the game :)");
        }
    }
}
