using System;

namespace Learning_projects.Tic_tac_toe
{

    public class TicTacToe
    {
        static void Main(string[] args)
        {
            new Config().SetConfiguration();
            try
            {
                Console.SetWindowSize(defaultSettings.Width + 2, defaultSettings.Height + 2);
                Console.SetBufferSize(defaultSettings.Width + 2, defaultSettings.Height + 2);
            }
            catch (PlatformNotSupportedException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            Console.CursorVisible = true;

            GameLogic game = new GameLogic();
            Render render = new Render();
            /*render.DrawBorder(defaultSettings.Width, defaultSettings.Height);
            render.DrawGridHorizontal(defaultSettings.Width, defaultSettings.Height);
            render.DrawGridVertical(defaultSettings.Width, defaultSettings.Height);
            render.DrawX(defaultSettings.Width, defaultSettings.Height);*/
            game.StartGame();
            Console.ReadKey();
        }
    }

}