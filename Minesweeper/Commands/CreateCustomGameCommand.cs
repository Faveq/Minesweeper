using Minesweeper.Models;
using Minesweeper.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            _generateGameBoardCommand.Execute(new GameBoardSizeModel(_customGameConfigurationViewModel.Height, _customGameConfigurationViewModel.Width, _customGameConfigurationViewModel.MinesCount));
        }
    }
}
