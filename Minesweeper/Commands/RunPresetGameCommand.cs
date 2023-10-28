using Minesweeper.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper.Commands
{
    public class RunPresetGameCommand : BaseCommand
    {

        private GameBoardSizeModel? selectedDifficulty;

        private readonly ICommand _generateGameBoardCommand;

        public RunPresetGameCommand(StackPanel stackPanel, Window gameWindow)
        {
            _generateGameBoardCommand = new GenerateGameBoardCommand(stackPanel, gameWindow);
        }

        public override void Execute(object? parameter)
        {

            switch (parameter)
            {
                case "begginer":
                    selectedDifficulty = new(8, 8, 10);
                    break;

                case "intermediate":
                    selectedDifficulty = new(16, 16, 40);
                    break;
                case "expert":
                    selectedDifficulty = new(16, 30, 99);
                    break;
            }

            _generateGameBoardCommand.Execute(selectedDifficulty);
        }
    }
}
