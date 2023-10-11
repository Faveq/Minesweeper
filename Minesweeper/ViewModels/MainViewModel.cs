using Minesweeper.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        CustomGameConfigurationViewModel CustomGameConfigurationViewModel { get; }
        public ICommand OpenCustomGameSettingsCommand { get; }
        public ICommand RunPresetGameCommand { get; }

        public MainViewModel(StackPanel stackPanel, Window gameWindow)
        {
            CustomGameConfigurationViewModel = new(stackPanel, gameWindow);
            OpenCustomGameSettingsCommand = new OpenCustomGameSettingsCommand(CustomGameConfigurationViewModel);
            RunPresetGameCommand = new RunPresetGameCommand(stackPanel, gameWindow);

        }

    }
}
