using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Controllers
{
    public class GameEndController
    {
        private Button[,] buttonsList;
        private int[,] gameBoard;
        private readonly ImageBrush _mine = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\mine.png")));
        public GameEndController(Button[,] buttonsList, int[,] gameBoard)
        {
            this.buttonsList = buttonsList;
            this.gameBoard = gameBoard;
        }

        public Button[,] BadEnding()
        {
            StatsController.StartStop();
            for (int y = 0; y < buttonsList.GetLength(1); y++)
            {
                for (int x = 0; x < buttonsList.GetLength(0); x++)
                {
                    buttonsList[x, y].IsHitTestVisible = false;
                    if (gameBoard[x + 1, y + 1] == 9)
                    {
                        buttonsList[x, y].Background = _mine;
                    }
                }
            }

            return buttonsList;
        }

        public Button[,] GoodEnding()
        {
            StatsController.StartStop();
            for (int y = 0; y < buttonsList.GetLength(1); y++)
            {
                for (int x = 0; x < buttonsList.GetLength(0); x++)
                {
                    buttonsList[x, y].IsHitTestVisible = false;
                    if (gameBoard[x + 1, y + 1] == 9)
                    {
                        buttonsList[x, y].Background = _mine;
                    }
                }
            }

            return buttonsList;
        }
    }
}
