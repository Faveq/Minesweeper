using Minesweeper.ViewModels;
using Minesweeper.Views;
using System.Windows;

namespace Minesweeper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartingWindowView startingWindowView = new();
            
            startingWindowView.Show();
            base.OnStartup(e);
        }
    }

}
