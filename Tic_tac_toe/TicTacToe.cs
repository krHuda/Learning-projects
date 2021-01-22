using System;

namespace Learning_projects.Tic_tac_toe
{

    public class TicTacToe
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            new Config().SetConfiguration();
            Render render = new Render();
            render.Border(defaultSettings.Width, defaultSettings.Height);
            Console.ReadKey();
        }
    }

}