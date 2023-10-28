using Minesweeper.Models;
using Minesweeper.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Commands
{
    public class CreateCustomGameCommand : BaseCommand
    {
        private readonly GenerateGameBoardCommand _generateGameBoardCommand;
        private readonly CustomGameConfigurationViewModel _customGameConfigurationViewModel;

        public CreateCustomGameCommand(StackPanel stackPanel, Window gameWindow, CustomGameConfigurationViewModel customGameConfigurationViewModel)
        {
            _customGameConfigurationViewModel = customGameConfigurationViewModel;
            _generateGameBoardCommand = new GenerateGameBoardCommand(stackPanel, gameWindow);
        }

        public override void Execute(object? parameter)
        {
            if (_customGameConfigurationViewModel.Height < 8)
            {
                _customGameConfigurationViewModel.Height = 8;
            }
            else if (_customGameConfigurationViewModel.Height > 24)
            {
                _customGameConfigurationViewModel.Height = 24;
            }

            if (_customGameConfigurationViewModel.Width < 8)
            {
                _customGameConfigurationViewModel.Width = 8;
            }
            else if (_customGameConfigurationViewModel.Width > 30)
            {
                _customGameConfigurationViewModel.Width = 30;
            }

            if (_customGameConfigurationViewModel.MinesCount > ((_customGameConfigurationViewModel.Width - 1) * (_customGameConfigurationViewModel.Height - 1)))
            {
                _customGameConfigurationViewModel.MinesCount = (_customGameConfigurationViewModel.Width - 1) * (_customGameConfigurationViewModel.Height - 1);
            }
            else if (_customGameConfigurationViewModel.MinesCount < 10)
            {
                _customGameConfigurationViewModel.MinesCount = 10;
            }

            _generateGameBoardCommand.Execute(new GameBoardSizeModel(_customGameConfigurationViewModel.Height, _customGameConfigurationViewModel.Width, _customGameConfigurationViewModel.MinesCount));
        }
    }
}
