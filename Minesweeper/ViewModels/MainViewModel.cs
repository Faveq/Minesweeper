using Minesweeper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minesweeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        CustomGameConfigurationViewModel CustomGameConfigurationViewModel { get; }
        public ICommand OpenCustomGameSettingsCommand { get; }
        public ICommand RunPresetGameCommand { get; }
        public MainViewModel() {
            CustomGameConfigurationViewModel = new();
            OpenCustomGameSettingsCommand = new OpenCustomGameSettingsCommand(CustomGameConfigurationViewModel);
            RunPresetGameCommand = new RunPresetGameCommand();
        }

    }
}
