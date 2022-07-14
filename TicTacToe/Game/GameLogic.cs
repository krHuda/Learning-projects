using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Game
{
    /// <summary>
    /// В данном классе реализована игровая логика.
    /// </summary>
    public static class GameLogic
    {
        /// <summary>
        /// Статический конструктор инициализирующий статические поля.
        /// </summary>
        static GameLogic()
        {
            CrossSquare = new MagicSquare(Constants.CrossSymbol);
            CircleSquare = new MagicSquare(Constants.CircleSymbol);
        }
        
        /// <summary>
        /// Свойство хранящее очередь хода.
        /// </summary>
        private static Turns Turn { get; set; }

        /// <summary>
        /// Магический квадрат для крестика.
        /// </summary>
        private static MagicSquare CrossSquare { get; set; }

        /// <summary>
        /// Магический квадрат для нолика.
        /// </summary>
        private static MagicSquare CircleSquare { get; set; }

        /// <summary>
        /// Счёт побед крестика.
        /// </summary>
        public static int ScoreX { get; private set; }
        
        /// <summary>
        /// Счёт побед нолика.
        /// </summary>
        public static int ScoreO { get; private set; }

        /// <summary>
        /// Возможное состояние хода.
        /// </summary>
        public enum Turns
        {
            Cross,
            Circle,
            Draw
        }
        
        
        public static void InputSymbol(int index, string symbol)
        {
            if (Turn == Turns.Cross)
            {
                CrossSquare.InputSymbol(index, symbol);
            }
            else
            {
                CircleSquare.InputSymbol(index, symbol);
            }
        }

        /// <summary>
        /// Данный метод сбрасывает состояние игры.
        /// </summary>
        public static void FinishGame()
        {
            CrossSquare = new MagicSquare(Constants.CrossSymbol);
            CircleSquare = new MagicSquare(Constants.CircleSymbol);
        }

        /// <summary>
        /// Данный метод обновляет счётчик побед.
        /// </summary>
        private static void SetScore()
        {
            if (GetTurn() == Turns.Cross)
            {
                ScoreX++;
            }
            else if (GetTurn() == Turns.Circle)
            {
                ScoreO++;
            }
        }

        /// <summary>
        /// Данный метод проверяет состояние окончания игры:
        /// Завершена если есть победитель.
        /// Продолжается если ещё нет победителя.
        /// Ничья, когда свободные поля закончились.
        /// </summary>
        /// <returns>Состояние окончания игры: true или false.</returns>
        public static bool IsGameFinished()
        {
            if (CrossSquare.IsWinConditionAchieved(Constants.ExpectedRowCountForWin) || CircleSquare.IsWinConditionAchieved(Constants.ExpectedRowCountForWin))
            {
                FinishGame();
                SetScore();
                return true;
            }
            if (IsDraw())
            {
                FinishGame();
                Turn = Turns.Draw;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет состояние игры на ничью.
        /// </summary>
        /// <returns>Состояние ничьей true или false</returns>
        private static bool IsDraw()
        {
            var crossField = CrossSquare.Square.ToList();
            var circleField = CircleSquare.Square.ToList();
            var gameField = ListsSum(crossField, circleField);
            return !(gameField.Count(c => c) > 0);
        }

        /// <summary>
        /// Выстовляет стартовую фигуру. По умолчанию всегда крестик.
        /// </summary>
        public static void Start() => Turn = Turns.Cross;

        /// <summary>
        /// Обновляет очередь хода.
        /// </summary>
        public static void UpdateTurn() => Turn = Turn == Turns.Circle ? Turns.Cross : Turns.Circle;

        /// <summary>
        /// Возвращает состояние хода.
        /// </summary>
        /// <returns>Состояние хода.</returns>
        public static Turns GetTurn() => Turn;

        /// <summary>
        /// Объединяет магические квадраты, для определения возмоности продолжения игры.
        /// Если нет свободных полей, то игра заканчивается ничьей.
        /// </summary>
        /// <param name="crossField">Поле крестиков.</param>
        /// <param name="circleField">Поле ноликов.</param>
        /// <returns>Список содержащий все совершённые ходы, если таковые были.</returns>
        private static List<bool> ListsSum(List<string[]> crossField, List<string[]> circleField)
        {
            var result = new List<bool>();
            for (var x = 0; x < crossField.Count; x++)
            {
                for (var y = 0; y < crossField.Count; y++)
                {
                    if (crossField[x][y] == Constants.CrossSymbol || circleField[x][y] == Constants.CircleSymbol)
                    {
                        result.Add(false);
                    }
                    else
                    {
                        result.Add(true);
                    }
                }
            }
            return result;
        }
    }
}