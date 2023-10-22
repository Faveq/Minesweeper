using System.Windows.Controls;

namespace Minesweeper.Commands
{
    public class GameEnd
    {
        private Button[,] buttonsList;
        private int[,] gameBoard;

        public GameEnd(Button[,] buttonsList, int[,] gameBoard)
        {
            this.buttonsList = buttonsList;
            this.gameBoard = gameBoard;
        }

        public Button[,] BadEnding()
        {

            for (int y = 1; y < buttonsList.GetLength(0) + 1; y++)
            {
                for (int x = 1; x < buttonsList.GetLength(1) + 1; x++)
                {
                    buttonsList[x - 1, y - 1].IsHitTestVisible = false;
                    if (gameBoard[x, y] == 9)
                    {
                        buttonsList[x - 1, y - 1].Content = "9";
                    }
                }
            }

            return buttonsList;
        }

        public void GoodEnding() { }
    }
}
