using Minesweeper.ViewModels;
using Minesweeper.Views;
using System.Windows;

namespace Minesweeper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GameWindowView gameWindowView = new()
            {
                DataContext = new MainViewModel()
            };

            gameWindowView.Show();
            base.OnStartup(e);
        }
    }

}
