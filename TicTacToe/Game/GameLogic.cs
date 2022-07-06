namespace TicTacToe.Game
{
    public static class GameLogic
    {
        private static Turns Turn { get; set; }

        private static MagicSquare CrossSquare = new();

        private static MagicSquare CircleSquare = new();

        public enum Turns
        {
            Cross,
            Circle
        }
        
        public static void InputNumber(int number)
        {
            if (Turn == Turns.Cross)
            {
                CrossSquare.InputNumber(number);
            }
            else
            {
                CircleSquare.InputNumber(number);
            }
        }

        public static void FinishGame()
        {
            CrossSquare = new MagicSquare();
            CircleSquare = new MagicSquare();
        }

        public static bool IsGameFinished()
        {
            if (CrossSquare.IsAllIdentical() || CircleSquare.IsAllIdentical())
            {
                FinishGame();
                return true;
            }
            return false;
        }

        public static void Start() => Turn = Turns.Cross;

        public static void UpdateTurn() => Turn = Turn == Turns.Circle ? Turns.Cross : Turns.Circle;

        public static Turns GetTurn() => Turn;
    }
}