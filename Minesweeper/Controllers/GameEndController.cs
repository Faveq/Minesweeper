using System;
using System.Media;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Controllers
{
    public class GameEndController
    {
        private readonly int[,] _gameBoard;

        private readonly Button[,] _buttonsList;

        private readonly ImageBrush _mine = new(new BitmapImage(new Uri("Resources\\mine.png", UriKind.Relative)));
        public GameEndController(Button[,] buttonsList, int[,] gameBoard)
        {
            _buttonsList = buttonsList;
            _gameBoard = gameBoard;
        }

        public Button[,] BadEnding()
        {
            StatsController.StartStop();
            for (int y = 0; y < _buttonsList.GetLength(1); y++)
            {
                for (int x = 0; x < _buttonsList.GetLength(0); x++)
                {
                    _buttonsList[x, y].IsHitTestVisible = false;
                    if (_gameBoard[x + 1, y + 1] == 9)
                    {
                        _buttonsList[x, y].Background = _mine;
                    }
                }
            }

            return _buttonsList;
        }

        public Button[,] GoodEnding()
        {
            StatsController.StartStop();
            for (int y = 0; y < _buttonsList.GetLength(1); y++)
            {
                for (int x = 0; x < _buttonsList.GetLength(0); x++)
                {
                    _buttonsList[x, y].IsHitTestVisible = false;
                    if (_gameBoard[x + 1, y + 1] == 9)
                    {
                        _buttonsList[x, y].Background = _mine;
                    }
                }
            }

            return _buttonsList;
        }
    }
}
