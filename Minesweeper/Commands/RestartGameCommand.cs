using Minesweeper.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper.Commands
{
    public class RestartGameCommand : BaseCommand
    {
        private readonly ICommand _generateGameBoardCommand;
        public override void Execute(object? parameter)
        {
            if (parameter != null && parameter is ValueTuple<GameBoardSizeModel, StackPanel, Window> tuple)
            {
                new GenerateGameBoardCommand(tuple.Item2, tuple.Item3).Execute(tuple.Item1);
            }
        }
    }
}
