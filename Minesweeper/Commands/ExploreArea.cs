using Minesweeper.Models;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper.Commands
{
    public static class ExploreArea
    {
        private static Button[,] buttonList;
        private static int[,] gameBoard;

        private static GameBoardSizeModel gameBoardSizeModel;

        public static int[,] ExploreEmptyArea(int x, int y, GameBoardSizeModel gameBoardSizeModel, int[,] gameBoard)
        {
            if (x < 1 || x > gameBoardSizeModel.Width || y < 1 || y > gameBoardSizeModel.Height || gameBoard[x, y] < 0 || gameBoard[x, y] > 8)
            {
                return gameBoard;
            }
            else if (gameBoard[x, y] > 0 && gameBoard[x, y] < 9)
            {
                DeactivateButton(buttonList[x - 1, y - 1], gameBoard[x, y]);
                gameBoard[x, y] = -1;

                return gameBoard;
            }

            DeactivateButton(buttonList[x - 1, y - 1], gameBoard[x, y]);
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

        private static void DeactivateButton(Button button, int number = 0)
        {
            Color backgroundColor = Color.FromArgb(45, 0, 0, 0); // Kolor RGBA: 0,0,0,140
            SolidColorBrush brush = new SolidColorBrush(backgroundColor);

            if (number != 0)
            {
                button.Content = number;
                button.IsHitTestVisible = false;
                button.Background = brush;
            }
            else
            {
                button.IsHitTestVisible = false;
                button.Background = brush;
            }
        }
        public static void PassButtonsList(Button[,] buttonsList)
        {
            buttonList = buttonsList;
        }
    }
}
