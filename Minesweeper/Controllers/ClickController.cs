﻿using Minesweeper.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper.Controllers
{
    public class ClickController
    {

        public void RightClicked(object sender, RoutedEventArgs e)
        {
            if (e is MouseButtonEventArgs mouseEventArgs && mouseEventArgs.RightButton == MouseButtonState.Pressed)
            {
               ClickCommand.RightButtonClicked((Button)sender);
            }
        }
    }
}
