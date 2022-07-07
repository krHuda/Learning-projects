using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TicTacToe.Additions;
using TicTacToe.Game;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Стартовая функция.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            GameLogic.Start();
            SetTurnText();
            SetScoreText();
        }

        /// <summary>
        /// Метод вызваемый при нажатии на кнопку поля. Проверяет состояние игры и ставит крестик или нолик в зависимости от очерёдности хода.
        /// </summary>
        /// <exception cref="NotImplementedException">Исключение, которое кидается в случае, если игра сломается и выйде за пределы возможного хода.</exception>
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var buttonIndex = Int32.Parse(button?.Tag.ToString()!);
            var image = Elements.GetChildOfType<Image>(button);
            if (image.Source != null)
            {
                return;
            }
            switch (GameLogic.GetTurn())
            {
                case GameLogic.Turns.Cross:
                    image.Source = Application.Current.Resources[Constants.Cross] as ImageSource;
                    GameLogic.InputNumber(buttonIndex);
                    break;
                case GameLogic.Turns.Circle:
                    image.Source = Application.Current.Resources[Constants.Circle] as ImageSource;
                    GameLogic.InputNumber(buttonIndex);
                    break;
                default: throw new NotImplementedException("How did you get here? :)");
            }
            if (GameLogic.IsGameFinished())
            {
                EndGameMessageBox(sender, e);
                return;
            }
            GameLogic.UpdateTurn();
            SetTurnText();
        }

        /// <summary>
        /// Метод открывающий диалоговое окно окончания игры с выбором перезапуска или выхода из неё.
        /// </summary>
        private void EndGameMessageBox(object sender, RoutedEventArgs e)
        {
            var turn = GameLogic.GetTurn() == GameLogic.Turns.Cross ? "X" : "O";
            string messageBoxText;
            if (GameLogic.GetTurn() == GameLogic.Turns.Draw)
            {
                messageBoxText = "Ничья. \nПерезапустить?";
            }
            else
            {
                messageBoxText = $"Игра окончена. Выйграл: {turn}! \nПерезапустить?";
            }
            const MessageBoxButton messageBoxButton = MessageBoxButton.YesNo;
            const MessageBoxImage icon = MessageBoxImage.Question;
            const string caption = "Game over";
            var result = MessageBox.Show(messageBoxText, caption, messageBoxButton, icon, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                RestartGame(sender, e);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Выводит в текстовом поле Turn очередь хода. 
        /// </summary>
        private void SetTurnText() => Turn.Text = GameLogic.GetTurn() == GameLogic.Turns.Cross ? "Turn: X" : "Turn: O";

        /// <summary>
        /// Выводит в текстовом поле Score счёт побед крестика и нолика.
        /// </summary>
        private void SetScoreText()
        {
            Score.Text = $"Score: X-{GameLogic.ScoreX} O-{GameLogic.ScoreO}";
        }
        
        /// <summary>
        /// Данный метод перезапускает игру по нажатии на кнопку в игре или в диалогом окне законченной игры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartGame(object sender, RoutedEventArgs e)
        {
            GameLogic.Start();
            var grid = VisualTreeHelper.GetParent((Button)sender);
            var buttons = Elements.GetListOfChildrenOfType<Button>(grid);
            var images = buttons.Select(Elements.GetChildOfType<Image>).ToList();
            foreach (var image in images.Where(image => image != null))
            {
                image.Source = null;
            }
            GameLogic.FinishGame();
            SetTurnText();
            SetScoreText();
        }
    }
}