using Minesweeper.ViewModels;
using Minesweeper.Views;

namespace Minesweeper.Commands
{
    public class OpenCustomGameSettingsCommand : BaseCommand
    {
        private readonly CustomGameConfigurationViewModel _customGameConfigurationViewModel;

        public OpenCustomGameSettingsCommand(CustomGameConfigurationViewModel customGameConfigurationViewModel)
        {
            _customGameConfigurationViewModel = customGameConfigurationViewModel;
        }

        public override void Execute(object? parameter)
        {
            CustomGameSettingsView customGameSettingsView = new()
            {
                DataContext = _customGameConfigurationViewModel
            };

            customGameSettingsView.Show();
        }
    }
}
