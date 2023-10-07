using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper.Views
{
    public partial class StartingWindowView : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public StartingWindowView()
        {
            InitializeComponent();
        }
    }
}
