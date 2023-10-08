using Minesweeper.Commands;
using MvvmHelpers;
using System.Windows.Input;

namespace Minesweeper.ViewModels
{
    public class CustomGameConfigurationViewModel : ViewModelBase
    {
        private int height;

        public int Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }


        private int width;

        public int Width
        {
            get => width;
            set => SetProperty(ref width, value);
        }

        private int minesCount;

        public int MinesCount
        {
            get => minesCount;
            set => SetProperty(ref minesCount, value);
        }
        
        public ICommand CreateCustomGameCommand { get; }
        public ICommand CloseCustomGameSettingsCommand { get; }


        public CustomGameConfigurationViewModel() {
            CreateCustomGameCommand = new CreateCustomGameCommand();
            CloseCustomGameSettingsCommand = new CloseCustomGameSettingsCommand(this);
        }
    }
}
