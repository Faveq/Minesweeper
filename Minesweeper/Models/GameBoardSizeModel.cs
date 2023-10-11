namespace Minesweeper.Models
{
    public class GameBoardSizeModel
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int MinesCount { get; set; }

        public GameBoardSizeModel(int height, int width, int minesCount)
        {
            Width = width;
            Height = height;
            MinesCount = minesCount;
        }
    }
}
