using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper.Views
{
    public partial class CustomGameSettingsView : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public CustomGameSettingsView()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
          Close();
        }
    }
}
