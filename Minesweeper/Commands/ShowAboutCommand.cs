using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper.Commands
{
    public class ShowAboutCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            MessageBox.Show("It's a minesweeper, moron", "About", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
