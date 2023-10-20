using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Commands.ClickingCommands
{
    public class ClickCommand : BaseCommand
    {
        private int clickedButtonPosX;
        private int clickedButtonPosY;
        private bool isFirstClick = true;
        private int[,]? gameBoard;
        private Button? clickedButton;

        private readonly GameBoardSizeModel _gameBoardSizeModel;


        public ClickCommand(GameBoardSizeModel gameBoardSizeModel, Button[,] buttonList)
        {
            _gameBoardSizeModel = gameBoardSizeModel;

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
                        clickedButton.Content = gameBoard[clickedButtonPosX, clickedButtonPosY];
                    }
                }
                else
                {
                    if (gameBoard[clickedButtonPosX, clickedButtonPosY] > 0 && gameBoard[clickedButtonPosX, clickedButtonPosY] < 9) // number field click
                    {
                        clickedButton.Content = gameBoard[clickedButtonPosX, clickedButtonPosY];
                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 0) //empty field click
                    {

                        gameBoard = ExploreArea.ExploreEmptyArea(clickedButtonPosX, clickedButtonPosY , _gameBoardSizeModel, gameBoard);

                        for (int y = 0; y < _gameBoardSizeModel.Height; y++)
                        {
                            for (int x = 0; x < _gameBoardSizeModel.Width; x++)
                            {
                                Debug.Write(gameBoard[x, y] + " ");
                            }
                            Debug.WriteLine("");
                        }

                    }
                    else if (gameBoard[clickedButtonPosX, clickedButtonPosY] == 9) //mine filed click
                    {
                        MessageBox.Show("Mine");
                    }
                }

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
            /*
            for (int y = 0; y < gameBoardSize.Height; y++)
            {
                for (int x = 0; x < gameBoardSize.Width; x++)
                {
                    Debug.Write(gameBoard[x, y] + " ");
                }
                Debug.WriteLine("");
            }
            */
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

