using System;
namespace TicTacToe
{
    class Field
    {
        int size;
        bool move;
        int[,] cells = new int[10, 10];
        public Field(int s)
        {
            size = s;
        }
        public void StartGame()
        {
            move = true;
            SetNull();
            DrawField();
        }
        void DrawField()
        {
            Console.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("| {0} |", cells[i, j]);
                }
                Console.WriteLine();
            }
        }
        void SetNull()              //Очищает игровое поле
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = 0;
                }
            }
        }
        public void MakeMove(int i, int j)
        {
            i--;
            j--;
            if (move)
                cells[i, j] = 1;
            else
                cells[i, j] = 2;
            move = !move;
            DrawField();
        }
    }
    class Game
    {
        static void Main()
        {
            int size;
            int i, j;
            Console.WriteLine("Welcome to the game\nWrite field size: ");
            size = Convert.ToInt32(Console.ReadLine());
            Field f = new Field(size);
            f.StartGame();
            while (true)
            {
                Console.WriteLine("Enter position: ");
                i = Convert.ToInt32(Console.ReadLine());
                j = Convert.ToInt32(Console.ReadLine());
                f.MakeMove(i, j);
            }
        }
    }
}
