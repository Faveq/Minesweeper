using Minesweeper.Commands;
using Minesweeper.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Views
{
    public partial class GameWindowView : Window
    {
        public GameWindowView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(stackPanel, gameWindow);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
