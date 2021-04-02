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
        public char Winner
        {
            get
            {
                return winner;
            }
            private set
            {
                winner = value;
            }
        }
        int size = 0, count = 0, pos = 0;
        bool move;
        char winner = ' ';
        char[,] cells = new char[10, 10];
        public void StartGame()             //Начало игры
        {
            move = true;
            GetSize();
            SetNull();
            DrawField();
        }
        void GetSize()                      //Получить размер поля; проверить на целое число больше 3.
        {
            string s;
            bool isNum = false;
            while (!isNum)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the game\nWrite field size: ");
                s = Console.ReadLine();
                isNum = int.TryParse(s, out size);
                if ((size < 3) || (size > 10))
                {
                    isNum = false;
                    Console.WriteLine("Your digit is too small or not simple.\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }
        public void GetPosition()
        {
            Console.WriteLine("Move number is {0}", count + 1);
            Console.WriteLine("Enter position: ");
            MakeMove(Console.ReadLine());
            
        }
        void DrawField()                     //Рисует игровое поле
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
        void SetNull()                      //Очищает игровое поле
        {
            count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = ' ';
                }
            }
        }
        void MakeMove(string position)       //Сделать ход по координатам, введённым пользователем
        {
            int i, j;
            if (int.TryParse(position, out pos))
            {
                i = (pos / 10) - 1;
                j = (pos % 10) - 1;
                if (((i > 0) && (j > 0) && (i < size) && (j < size)) && CheckCells(i, j))
                {
                    count++;
                    if (move)
                        cells[i, j] = 'X';
                    else
                        cells[i, j] = 'O';
                    move = !move;
                    DrawField();            //Отрисовка поля после хода
                                            //Проверка на ничью
                }
                else
                {
                    DrawField();
                    Console.WriteLine("Another try");
                }
            }
            else
            {
                DrawField();
                Console.WriteLine("Another try");
            }
        }
        bool CheckCells(int i, int j)
        {
            if (cells[i, j] == ' ')
                return true;
            else
                return false;
        }
        public bool CheckDraw()           //Проверка на ничью
        {
            if (count >= size * size)
                return true;
            else
                return false;
        }
        char GetWinner()            //Устанавливает, кто победил
        {
            if (move)
                return 'O';
            else
                return 'X';
        }
        public bool EoG()           //Проверка на конец игры
        {
            if (WinCombination())
            {
                Console.WriteLine("The winner is {0}", GetWinner());
                return true;
            }
            else
            if (CheckDraw())
            {
                Console.WriteLine("Game draw");
                return true;
            }
            else
                return false;
        }
        bool WinCombination()             //Поставить проверку поля на наличие выиграшных комбинаций
        {
            if (WinMainDiagonal()||WinSecondDiagonal()||WinRows()||WinColumns())
                return true;
            else
                return false;

        }
        bool WinMainDiagonal()
        {
            int winD = 0;
            for (int i = 0; i < size - 1; i++)
            {
                if (cells[i, i] == cells[i + 1, i + 1] && (cells[i, i] != ' ')) //Диагональ
                    winD++;
            }
            if (winD > size - 2)
                return true;
            else
                return false;
        }
        bool WinSecondDiagonal()
        {
            int winD = 0;
            for (int i = 0; i < size - 1; i++)
            {
                if (cells[i, size - i - 1] == cells[i + 1, size - i - 2] && (cells[i, size - i - 1] != ' '))
                    winD++;
            }
            if (winD > size - 2)
                return true;
            else
                return false;
        }
        bool WinRows()
        {
            int winRX = 0, winRO = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i, j] == 'X')
                        winRX++;
                    else if (cells[i, j] == 'O')
                        winRO++;
                }
                if ((winRX == size) | (winRO == size))
                    return true;
                else
                {
                    winRX = 0;
                    winRO = 0;
                }
            }
            return false;
        }
        bool WinColumns()
        {
            int winCX = 0, winCO = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[j, i] == 'X')
                        winCX++;
                    else if (cells[j, i] == 'O')
                        winCO++;
                }
                if ((winCX == size) | (winCO == size))
                    return true;
                else
                {
                    winCX = 0;
                    winCO = 0;
                }
            }
            return false;
        }
    }
}
 /*   class Game
    {
        static void Main()
        {
            Field f = new Field();
            f.StartGame();
            while (true)
            {
                Console.WriteLine("Move number is {0}", f.Count+1);
                f.GetPosition();                                         //Получить адрес клетки и сделать ход
                if (f.EoG())
                    break;
            }
            Console.WriteLine("Thanks for the game :)");
        }
    }
 */