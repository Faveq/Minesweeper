
namespace Minesweeper.Models
{
    public class GameConfigurationModel
    {
        public int Height { get; set; }
        public int Width { get; set; }    
        public int MinesCount { get; set; }

        public GameConfigurationModel(int height,int width, int minesCount)
        {
            Height = height;
            Width = width;
            MinesCount = minesCount;
        }
    }
}
