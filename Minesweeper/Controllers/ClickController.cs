using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Controllers
{
    public class ClickController
    {

        private Button clikedButton;
        public void RightClicked(object sender, RoutedEventArgs e)
        {
            clikedButton = (Button)sender;
            if (e is MouseButtonEventArgs mouseEventArgs && mouseEventArgs.RightButton == MouseButtonState.Pressed)
            {
                MessageBox.Show(clikedButton.Name);
            }
        }
    }
}
