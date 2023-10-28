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

        private readonly ImageBrush _mine = new(new BitmapImage(new Uri("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\mine.png")));
        private readonly SoundPlayer[] booms = new SoundPlayer[]
            {
            new SoundPlayer("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Explosion1.wav"),
            new SoundPlayer("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Explosion2.wav"),
            new SoundPlayer("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Explosion3.wav")
            };
        public GameEndController(Button[,] buttonsList, int[,] gameBoard)
        {
            _buttonsList = buttonsList;
            _gameBoard = gameBoard;
        }

        public Button[,] BadEnding()
        {
            StatsController.StartStop();
            Random random = new();
            booms[random.Next(3)].Play();
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
