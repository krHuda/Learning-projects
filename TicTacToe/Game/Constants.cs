namespace TicTacToe.Game
{
    /// <summary>
    /// В данном классе содержатся неизменяемые поля для использования их в коде.
    /// В случае необходимости всё меняется в одном месте.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Слово крестик.
        /// </summary>
        public const string Cross = "Cross";
        /// <summary>
        /// Слово нолик.
        /// </summary>
        public const string Circle = "Circle";

        public const string CrossSymbol = "X";
        
        public const string CircleSymbol = "O";

        public const string TurnText = "Turn: ";

        public const int ExpectedRowCountForWin = 3;
        /// <summary>
        /// Эталон магического квадрата.
        /// </summary>
        public static readonly int[][] MagicNumbers = 
        {
            new[] { 17, 24, 1, 8, 15 },
            new[] { 23, 5, 7, 14, 16 },
            new[] { 4, 6, 13, 20, 22 },
            new[] { 10, 12, 19, 21, 3 },
            new[] { 11, 18, 25, 2, 9 },
        };
    }
}