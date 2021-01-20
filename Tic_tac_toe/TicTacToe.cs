using System;

namespace Learning_projects.Tic_tac_toe
{


    public class TicTacToe
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            Console.WriteLine(config.SetConfiguration(300, 300, false));
        }
    }

}