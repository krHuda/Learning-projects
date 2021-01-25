using System;

namespace Learning_projects.Tic_tac_toe
{

    public class TicTacToe
    {
        static void Main(string[] args)
        {
            new Config().SetConfiguration();
            //Console.SetWindowSize(defaultSettings.Width + 1, defaultSettings.Height + 1);
            //Console.SetBufferSize(defaultSettings.Width + 1, defaultSettings.Height + 1);
            //Console.CursorVisible = false;
            Render render = new Render();
            render.DrawBorder(defaultSettings.Width, defaultSettings.Height);
            render.DrawGridHorizontal(defaultSettings.Width, defaultSettings.Height); //Метод вызывается тут для теста, должен вызываться после старта игры.
            render.DrawGridVertical(defaultSettings.Width, defaultSettings.Height); //Метод вызывается тут для теста, должен вызываться после старта игры.
            //render.DrawX(defaultSettings.Width, defaultSettings.Height); //Метод вызывается тут для теста, должен вызываться логикой игры (ещё не реализованна).
            Console.ReadKey();
        }
    }

}