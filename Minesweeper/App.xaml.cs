using Minesweeper.Views;
using System.Windows;

namespace Minesweeper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GameWindowView gameWindowView = new();

            gameWindowView.Show();

            base.OnStartup(e);
        }
    }

}
