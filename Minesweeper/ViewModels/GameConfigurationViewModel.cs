using MvvmHelpers;
namespace Minesweeper.ViewModels
{
    public class GameConfigurationViewModel : ViewModelBase
    {
        private int mapSize;

        public int MapSize
        {
            get => mapSize;
            set => SetProperty(ref mapSize, value);
        }

        private int minesCount;

        public int MinesCount
        {
            get => minesCount;
            set => SetProperty(ref minesCount, value);
        }



    }
}
