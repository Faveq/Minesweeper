using Minesweeper.Models;
using System.Diagnostics;
using System.Windows.Controls;

namespace Minesweeper.Commands
{
    public static class ExploreArea
    {
        private static Button[,] buttonList;
        private static int clickedButtonPosX, clickedButtonPosY;
        private static int[,] gameBoard;

        private static GameBoardSizeModel gameBoardSizeModel;

        public static int[,] ExploreEmptyArea(int x, int y, GameBoardSizeModel gameBoardSizeModel, int[,] gameBoard)
        {

            Debug.WriteLine($"Wywyołano dla: {x}/{y}");

            if (x < 1 || x > gameBoardSizeModel.Height || y < 1 || y > gameBoardSizeModel.Width || gameBoard[x, y] < 0 || gameBoard[y, x] > 8)
            {
                return gameBoard;
            }
            else if (gameBoard[x, y] > 0 && gameBoard[x, y] < 9)
            {
                buttonList[x - 1, y - 1].Content = gameBoard[x, y];
                buttonList[x - 1, y - 1].IsEnabled = false;
                gameBoard[x, y] = -1;

                return gameBoard;
            }

            buttonList[x - 1, y - 1].IsEnabled = false;
            gameBoard[x, y] = -1; //-1 means its uncovered




            ExploreEmptyArea(x - 1, y - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x - 1, y, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x - 1, y + 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x, y - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x, y + 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x + 1, y - 1, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x + 1, y, gameBoardSizeModel, gameBoard);
            ExploreEmptyArea(x + 1, y + 1, gameBoardSizeModel, gameBoard);

            return gameBoard;
        }


        public static void PassButtonsList(Button[,] buttonsList)
        {
            buttonList = buttonsList;
        }
    }
}
