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
        /// <summary>
        /// Эталон магического квадрата.
        /// </summary>
        public static readonly int[][] MagicNumbers = 
        {
            new int[] { 8, 1, 6 },
            new int[] { 3, 5, 7 },
            new int[] { 4, 9, 2 },
        };
    }
}