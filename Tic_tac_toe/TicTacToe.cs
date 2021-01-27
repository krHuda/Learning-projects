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

            Console.CursorVisible = false;

            GameLogic game = new GameLogic();
            game.StartGame();
            Console.ReadKey();
        }
    }

}