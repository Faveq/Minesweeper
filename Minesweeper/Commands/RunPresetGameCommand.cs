using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Minesweeper.Commands
{
    public class RunPresetGameCommand : BaseCommand
    {
        private int height = 0;
        private int width = 0;
        private int minesCount = 0;

        private readonly ICommand _GenerateGameBoardCommand;

        public RunPresetGameCommand()
        {
            _GenerateGameBoardCommand = new GenerateGameBoardCommand();
        }

        public override void Execute(object? parameter)
        {

           switch (parameter)
            {
                case "begginer":
                    height = 8;
                    minesCount = 10;
                    break;

                case "intermediate":
                    height = 16;
                    minesCount = 40;
                    break;

                case "expert":
                    height = 16;
                    width = 30;
                    minesCount = 99;
                    break;
            }

            if(width == 0)
            {

            }
        }
    }
}
