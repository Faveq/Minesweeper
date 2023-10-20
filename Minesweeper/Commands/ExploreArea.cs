using Minesweeper.Models;
using System;
using System.Windows.Controls;

namespace Minesweeper.Commands
{
    public static class ExploreArea
    {
        private static Button[,] buttonList;
        private static int clickedButtonPosX, clickedButtonPosY;
        private static int[,] gameBoard;

        private static GameBoardSizeModel gameBoardSizeModel;

        public static int[,] ExploreEmptyArea(int row , int col, GameBoardSizeModel gameBoardSizeModel, int[,] gameBoard)
        {
            if (row < 0 || row >= gameBoardSizeModel.Height || col < 0 || col >= gameBoardSizeModel.Width || gameBoard[row, col] < 0 || gameBoard[row, col] > 8)
            {
                return gameBoard;
            }
            else if (gameBoard[row, col] >0 && gameBoard[row, col] < 9)
            {
                buttonList[row, col].Content = gameBoard[row, col];
                return gameBoard;
            }
            buttonList[row, col].Content = "X";


            gameBoard[row, col] = -1; //-1 means its uncovered


            ExploreEmptyArea(row - 1, col - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row - 1, col, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row - 1, col + 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row, col - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row, col + 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row + 1, col - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row + 1, col, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(row + 1, col + 1, gameBoardSizeModel, gameBoard);

            return gameBoard;
        }


        public static void PassButtonsList(Button[,] buttonsList) { 
        buttonList = buttonsList;
        }
    }
}
