using Minesweeper.Commands;
using Minesweeper.Models;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Controllers
{
    public static class ExploreAreaController
    {
        private static Button[,]? buttonList;

        public static int[,] ExploreEmptyArea(int x, int y, GameBoardSizeModel gameBoardSizeModel, int[,] gameBoard)
        {
            if (buttonList != null)
            {
                if (x < 1 || x > gameBoardSizeModel.Width || y < 1 || y > gameBoardSizeModel.Height || gameBoard[x, y] < 0 || gameBoard[x, y] > 8 && buttonList[x - 1, y - 1].Background != ClickCommand._flag)
                {
                    return gameBoard;
                }
                else if (gameBoard[x, y] > 0 && gameBoard[x, y] < 9 && buttonList[x - 1, y - 1].Background != ClickCommand._flag)
                {
                    DeactivateButton(buttonList[x - 1, y - 1], gameBoard[x, y]);
                    gameBoard[x, y] = -1;

                    return gameBoard;
                }
                else if (buttonList[x - 1, y - 1].Background == ClickCommand._flag)
                {
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
            return gameBoard;
        }
        private static void DeactivateButton(Button button, int number = 0)
        {
            Color backgroundColor = Color.FromArgb(45, 0, 0, 0); // Kolor RGBA: 0,0,0,140
            SolidColorBrush brush = new(backgroundColor);

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
