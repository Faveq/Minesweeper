using Minesweeper.Controllers;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper.Commands.ClickingCommands
{
    public class ClickCommand : BaseCommand
    {
        private int clickedButtonPosX;
        private int clickedButtonPosY;
        private bool isFirstClick = true, isEverythingUncovered = true;
        private int[,]? gameBoard;
        private Button[,] buttonsList;
        private Button? clickedButton;
        private GameEndController gameEnd;


        private readonly GameBoardSizeModel _gameBoardSizeModel;


        public ClickCommand(GameBoardSizeModel gameBoardSizeModel, Button[,] buttonsList)
        {
            _gameBoardSizeModel = gameBoardSizeModel;
            this.buttonsList = buttonsList;
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

                    if (gameBoard[clickedButtonPosX, clickedButtonPosY] != 0 && gameBoard[clickedButtonPosX, clickedButtonPosY] != 9)
                    {
                        DeactivateButton(clickedButton, gameBoard[clickedButtonPosX, clickedButtonPosY]);
                        gameBoard[clickedButtonPosX, clickedButtonPosY] = -1;
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 0) //empty field click
                    {

                        gameBoard = ExploreArea.ExploreEmptyArea(clickedButtonPosX, clickedButtonPosY, _gameBoardSizeModel, gameBoard);

                    }
                }
                else
                {
                    if (gameBoard[clickedButtonPosX, clickedButtonPosY] > 0 && gameBoard[clickedButtonPosX, clickedButtonPosY] < 9) // number field click
                    {
                        DeactivateButton(clickedButton, gameBoard[clickedButtonPosX, clickedButtonPosY]);
                        gameBoard[clickedButtonPosX, clickedButtonPosY] = -1;
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 0) //empty field click
                    {
                        gameBoard = ExploreArea.ExploreEmptyArea(clickedButtonPosX, clickedButtonPosY, _gameBoardSizeModel, gameBoard);
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 9) //mine filed click
                    {
                        gameEnd = new(buttonsList, gameBoard);
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
                    gameEnd = new(buttonsList, gameBoard);
                    gameEnd.GoodEnding();
                }
                else
                {
                    isEverythingUncovered = true;
                }

            }

        }

        private void DeactivateButton(Button button, int number = 0)
        {
            Color backgroundColor = Color.FromArgb(45, 0, 0, 0); // Kolor RGBA: 0,0,0,140
            SolidColorBrush brush = new SolidColorBrush(backgroundColor);

            if (number != 0)
            {
                button.Content = number;
                button.IsHitTestVisible = false;
                button.Background = brush;
            }
        }

        private int GetCoordinate(string coordinateCode, string coordinate)
        {
            int index = coordinateCode.IndexOf('_');

            switch (coordinate)
            {
                case "x":
                    return int.Parse(coordinateCode.Substring(1, index - 1));
                case "y":
                    return int.Parse(coordinateCode.Substring(index + 1));
                default:
                    return 0;
            }
        }

        private int[,] PlaceMines(GameBoardSizeModel gameBoardSize)
        {
            gameBoard = new int[gameBoardSize.Width + 2, gameBoardSize.Height + 2];


            var availableIndices = new List<(int, int)>();
            var minesCoordinates = new List<(int, int)>();

            Random random = new Random();
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
        private int[,] CaclulateFields(List<(int, int)> minesCoordinates, int[,] gameBoard)
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