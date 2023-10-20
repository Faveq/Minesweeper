using System.Windows;

namespace rwe_tgwe
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
