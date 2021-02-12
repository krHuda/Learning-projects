using System;
namespace TicTacToe
{
    class Field
    {
        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
            }
        }
        int size = 0;
        bool move;
        int[,] cells = new int[10, 10];
        public void StartGame()     //Начало игры
        {
            move = true;
            GetSize();
            SetNull();
            DrawField();
        }
        void GetSize()              //Получить размер поля; проверить на целое число больше 3.
        {
            string s;
            bool isNum = false;
            while (!isNum)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the game\nWrite field size: ");
                s = Console.ReadLine();
                isNum = int.TryParse(s, out size);
                if (size < 3)
                {
                    isNum = false;
                    Console.WriteLine("Your digit is too small or not simple.\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }
        void DrawField()           //Рисует игровое поле
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
        public void MakeMove(int pos)
        {
            int i, j;
            i = (pos / 10) - 1;
            j = (pos % 10) - 1;
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
            int pos;
            int i = 0;
            Field f = new Field();
            f.StartGame();
            while (i < (f.Size * f.Size))
            {
                Console.WriteLine("Enter position: ");
                pos = Convert.ToInt32(Console.ReadLine());
                f.MakeMove(pos);
                i++;
            }
            Console.WriteLine("Thanks for the game :)");
        }
    }
}
