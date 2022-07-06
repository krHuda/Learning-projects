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
        public MainWindow()
        {
            InitializeComponent();
            GameLogic.Start();
            SetTurnText();
        }

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
                MessageBoxButton messageBoxButton = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                string messadgeBoxText = "Игра окончена. Перезапустить?";
                string caption = "Game over";
                var result = MessageBox.Show(messadgeBoxText, caption, messageBoxButton, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    RestartGame(sender, e);
                }
                else
                {
                    Application.Current.Shutdown();
                }
                return;
            }
            GameLogic.UpdateTurn();
            SetTurnText();
        }

        private void SetTurnText() => Turn.Text = GameLogic.GetTurn() == GameLogic.Turns.Cross ? "Turn: X" : "Turn: O";

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
        }
    }
}