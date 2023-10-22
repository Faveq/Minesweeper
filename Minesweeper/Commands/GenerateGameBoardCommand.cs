using Minesweeper.Commands.ClickingCommands;
using Minesweeper.Models;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Commands
{
    public class GenerateGameBoardCommand : BaseCommand
    {
        private readonly StackPanel _stackPanel;
        private readonly Window _gameWindow;
        private Button[,] buttonsList;
        
        private ClickCommand _clickCommand;
        public GenerateGameBoardCommand(StackPanel stackPanel, Window gameWindow)
        {
            _stackPanel = stackPanel;
            _gameWindow = gameWindow;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                GameBoardSizeModel gameBoardSizeModel = (GameBoardSizeModel)parameter; //board size in parameter
                _stackPanel.Children.Clear();
                buttonsList = new Button[gameBoardSizeModel.Width, gameBoardSizeModel.Height];

                
                _clickCommand = new ClickCommand(gameBoardSizeModel, buttonsList);

                _gameWindow.Width = gameBoardSizeModel.Width * 17 + 30;
                _gameWindow.Height = gameBoardSizeModel.Height * 17 + 100;
                _stackPanel.Width = gameBoardSizeModel.Width * 17 + 30;
                _stackPanel.Height = gameBoardSizeModel.Height * 17;



               

                for (int y = 0; y < gameBoardSizeModel.Height; y++)
                {
                    string buttonName = "";
                    WrapPanel wrappanel = new WrapPanel();

                    wrappanel.Width = _stackPanel.Width;
                    _stackPanel.Children.Add(wrappanel);

                    for (int x = 0; x < gameBoardSizeModel.Width; x++)
                    {
                        buttonName = (x +1).ToString() + "_" + (y+1).ToString();
                        Button button = new Button();
                        button.Height = 17;
                        button.Width = 17;
                        button.Command = _clickCommand;
                        button.Name = "b" + buttonName;
                        buttonsList[x, y] = button;
                        button.CommandParameter = button; // showing btn pos (x,y)

                       

                        wrappanel.Children.Add(button);
                    }
                }

                ExploreArea.PassButtonsList(buttonsList);
            }
        }
    }
}
