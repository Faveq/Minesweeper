using Minesweeper.Controllers;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Commands
{
    public class ClickCommand : BaseCommand
    {
        private int clickedButtonPosX;
        private int clickedButtonPosY;
        private static int[,]? gameBoard;
        private bool isFirstClick = true, isEverythingUncovered = true;
        private Button[,] _buttonsList;
        private Button? clickedButton;
        private Button? restartButton;
        private GameEndController? gameEnd;

        private readonly GameBoardSizeModel _gameBoardSizeModel;

        static readonly ImageBrush _skull = new(new BitmapImage(new Uri("Resources\\Skull.png", UriKind.Relative)));
        static readonly ImageBrush _trophy = new(new BitmapImage(new Uri("Resources\\Trophy.png", UriKind.Relative)));
        static readonly ImageBrush _questionMark = new(new BitmapImage(new Uri("Resources\\Question_mark.png", UriKind.Relative)));
        public static readonly ImageBrush _flag = new(new BitmapImage(new Uri("Resources\\Flag.png", UriKind.Relative)));

        public ClickCommand(GameBoardSizeModel gameBoardSizeModel, Button[,] buttonsList, Button restartButton)
        {
            _gameBoardSizeModel = gameBoardSizeModel;
            _buttonsList = buttonsList;
            this.restartButton = restartButton;
        }
        public override void Execute(object? parameter) //// parameter => btn pos as string "x_y"
        {

            if (parameter != null)
            {
                clickedButton = (Button)parameter;
                clickedButtonPosX = GetCoordinate(clickedButton.Name, "x");
                clickedButtonPosY = GetCoordinate(clickedButton.Name, "y");


                if (isFirstClick)
                {
                    PlaceMines(_gameBoardSizeModel);
                    isFirstClick = false;

                    if (gameBoard[clickedButtonPosX, clickedButtonPosY] != 0 && gameBoard[clickedButtonPosX, clickedButtonPosY] != 9 && !IsFlagged(clickedButton))
                    {
                        DeactivateButton(clickedButton, gameBoard[clickedButtonPosX, clickedButtonPosY]);
                        gameBoard[clickedButtonPosX, clickedButtonPosY] = -1;
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 0 && !IsFlagged(clickedButton)) //empty field click
                    {

                        gameBoard = ExploreAreaController.ExploreEmptyArea(clickedButtonPosX, clickedButtonPosY, _gameBoardSizeModel, gameBoard);

                    }
                }
                else
                {
                    if (gameBoard[clickedButtonPosX, clickedButtonPosY] > 0 && gameBoard[clickedButtonPosX, clickedButtonPosY] < 9 && !IsFlagged(clickedButton)) // number field click
                    {
                        DeactivateButton(clickedButton, gameBoard[clickedButtonPosX, clickedButtonPosY]);
                        gameBoard[clickedButtonPosX, clickedButtonPosY] = -1;
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 0 && !IsFlagged(clickedButton)) //empty field click
                    {
                        gameBoard = ExploreAreaController.ExploreEmptyArea(clickedButtonPosX, clickedButtonPosY, _gameBoardSizeModel, gameBoard);
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 9 && !IsFlagged(clickedButton)) //mine filed click
                    {
                        gameEnd = new(_buttonsList, gameBoard);
                        restartButton.Background = _skull;
                        gameEnd.BadEnding();
                    }
                }

                for (int y = 1; y < gameBoard.GetLength(1) - 1; y++)
                {
                    for (int x = 1; x < gameBoard.GetLength(0) - 1; x++)
                    {
                        if (gameBoard[x, y] != -1 && gameBoard[x, y] != 9)
                        {
                            isEverythingUncovered = false;
                            break;
                        }
                    }
                }

                //for (int y = 1; y < gameBoard.GetLength(1) - 1; y++)
                //{
                //    for (int x = 1; x < gameBoard.GetLength(0) - 1; x++)
                //    {
                //        Debug.Write(gameBoard[x, y]);

                //    }
                //    Debug.WriteLine("");
                //}
                //Debug.WriteLine("================================================");

                if (isEverythingUncovered)
                {
                    gameEnd = new(_buttonsList, gameBoard);
                    restartButton.Background = _trophy;
                    gameEnd.GoodEnding();
                }
                else
                {
                    isEverythingUncovered = true;
                }

            }

        }

        private bool IsFlagged(Button clickedButton) { 
        return clickedButton.Background == _flag;
        }

        public static void RightButtonClicked(Button clickedButton)
        {
                if (clickedButton.Background != _flag && clickedButton.Background != _questionMark)
                {
                    clickedButton.Background = _flag;
                }
                else if (clickedButton.Background == _flag)
                {
                    clickedButton.Background = _questionMark;
                }
                else if (clickedButton.Background == _questionMark)
                {
                    clickedButton.Background = null;
                }
        }

        private static void DeactivateButton(Button button, int number = 0)
        {
            Color backgroundColor = Color.FromArgb(45, 0, 0, 0);
            SolidColorBrush brush = new(backgroundColor);

            if (number != 0)
            {
                button.Content = number;
                button.IsHitTestVisible = false;
                button.Background = brush;
            }
        }

        private static int GetCoordinate(string coordinateCode, string coordinate)
        {
            int index = coordinateCode.IndexOf('_');

            return coordinate switch
            {
                "x" => int.Parse(coordinateCode[1..index]),
                "y" => int.Parse(coordinateCode[(index + 1)..]),
                _ => 0,
            };
        }

        private int[,] PlaceMines(GameBoardSizeModel gameBoardSize)
        {
            gameBoard = new int[gameBoardSize.Width + 2, gameBoardSize.Height + 2];


            var availableIndices = new List<(int, int)>();
            var minesCoordinates = new List<(int, int)>();

            Random random = new();
            for (int y = 1; y < gameBoardSize.Height + 1; y++) //filling arrays
            {
                for (int x = 1; x < gameBoardSize.Width + 1; x++)
                {
                    availableIndices.Add((x, y));
                    gameBoard[x, y] = 0;
                }
            }

            availableIndices.Remove((clickedButtonPosX, clickedButtonPosY)); //removing possibility of spawning mine on the first clicked button

            for (int i = 0; i < gameBoardSize.MinesCount; i++) //inserting mines
            {
                int randomIndex = random.Next(0, availableIndices.Count);
                (int row, int col) = availableIndices[randomIndex];
                gameBoard[row, col] = 9;                               //9 is bomb
                minesCoordinates.Add((row, col));
                availableIndices.RemoveAt(randomIndex);
            }
            return CaclulateFields(minesCoordinates, gameBoard);
        }
        private static int[,] CaclulateFields(List<(int, int)> minesCoordinates, int[,] gameBoard)
        {
            foreach (var mineCoordinate in minesCoordinates)
            {
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        try
                        {
                            if (gameBoard[mineCoordinate.Item1 + x, mineCoordinate.Item2 + y] != 9)
                            {
                                gameBoard[mineCoordinate.Item1 + x, mineCoordinate.Item2 + y]++;
                            }
                        }
                        catch (Exception)
                        {
                            continue; // ʘ‿ʘ
                        }
                    }
                }
            }


            return gameBoard;
        }
    }
}

/*                     
 *                     for (int y = 1; y < _gameBoardSizeModel.Height + 1; y++)
                        {
                            for (int x = 1; x < _gameBoardSizeModel.Width + 1; x++)
                            {
                                Debug.Write(gameBoard[x, y] + " ");
                            }
                            Debug.WriteLine("");
                        }
                        Debug.WriteLine("===================================="); 
*/