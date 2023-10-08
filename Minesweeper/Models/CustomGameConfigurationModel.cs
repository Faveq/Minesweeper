
namespace Minesweeper.Models
{
    public class CustomGameConfigurationModel
    {
        public int Height { get; set; }
        public int Width { get; set; }    
        public int MinesCount { get; set; }

        public CustomGameConfigurationModel(int height,int width, int minesCount)
        {
            Height = height;
            Width = width;
            MinesCount = minesCount;
        }
    }
}
