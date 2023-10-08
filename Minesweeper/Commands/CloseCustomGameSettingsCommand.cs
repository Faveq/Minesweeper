using Minesweeper.ViewModels;
using Minesweeper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Commands
{
    public class CloseCustomGameSettingsCommand : BaseCommand
    {
        private readonly CustomGameConfigurationViewModel _customGameConfigurationViewModel;

        public CloseCustomGameSettingsCommand(CustomGameConfigurationViewModel customGameConfigurationViewModel)
        {
            _customGameConfigurationViewModel = customGameConfigurationViewModel;
        }

        public override void Execute(object? parameter)
        {
            CustomGameSettingsView customGameSettingsView = new()
            {
                DataContext = _customGameConfigurationViewModel
            };

            customGameSettingsView.Close();
        }
    }
}
