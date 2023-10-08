using System;
using System.Diagnostics;

namespace Minesweeper.Commands
{
    public class RunPresetGameCommand : BaseCommand
    {
        public RunPresetGameCommand()
        {

        }

        public override void Execute(object? parameter)
        {
           switch (parameter)
            {
                case "begginer":
                    Debug.WriteLine("begginer");
                    break;

                case "intermediate":
                    Debug.WriteLine("intermediate");
                    break;

                case "expert":
                    Debug.WriteLine("expert");
                    break;
                    

            }
        }
    }
}
