using Minesweeper.ViewModels;
using Minesweeper.Views;
using System.Windows;

namespace Minesweeper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CustomGameSettingsView customGameSettingsView = new();
    
            GameWindowView gameWindowView = new ();

            customGameSettingsView.Show();
            base.OnStartup(e);
        }
    }

}
