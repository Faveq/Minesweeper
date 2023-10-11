using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Minesweeper.Commands.ClickingCommands
{
    public class ClickCommand : BaseCommand
    {
        private int clickedButtonPosX;
        private int clickedButtonPosY;
        private bool isFirstClick = true;
        private int[,]? gameBoard;

        private Button? button;

        private readonly GameBoardSizeModel _gameBoardSizeModel;


        public ClickCommand(GameBoardSizeModel gameBoardSizeModel)
        {
            _gameBoardSizeModel = gameBoardSizeModel;
        }
        public override void Execute(object? parameter) //// parameter => btn pos as string "x_y"
        {
            if (parameter != null)
            {
                button = (Button)parameter;
                if (button != null)
                {

                    clickedButtonPosX = GetCoordinate(button.Name, "x");
                    clickedButtonPosY = GetCoordinate(button.Name, "y");

                    if (isFirstClick)
                    {
                        PlaceMines(_gameBoardSizeModel);
                        isFirstClick = false;
                    }
                    else
                    {
                        button.Content = "1";
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
            gameBoard = new int[gameBoardSize.Width, gameBoardSize.Height];
            var availableIndices = new List<(int, int)>();

            Random random = new Random();
            for (int y = 0; y < gameBoardSize.Height; y++) //filling arrays
            {
                for (int x = 0; x < gameBoardSize.Width; x++)
                {
                    availableIndices.Add((x, y));
                    gameBoard[x, y] = 0;
                }
            }

            availableIndices.Remove((clickedButtonPosX, clickedButtonPosY)); //removing possibility of spawning mine on first clicked button

            for (int i = 0; i < gameBoardSize.MinesCount; i++) //inserting mines
            {
                int randomIndex = random.Next(0, availableIndices.Count);
                (int row, int col) = availableIndices[randomIndex];
                gameBoard[row, col] = 1;
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
            return gameBoard;
        }
    }
}

