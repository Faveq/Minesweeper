
namespace Minesweeper.Models
{
    public class GameConfigurationModel 
    {
        public int MapSize { get; set; }
        public int MinesCount { get; set; }

        public GameConfigurationModel(int mapSize, int minesCount)
        {
            MapSize = mapSize;
            MinesCount = minesCount;
        }
    }
}
