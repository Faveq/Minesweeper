using System.Windows;

namespace Minesweeper.Commands
{
    public class ShutDownGameCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
