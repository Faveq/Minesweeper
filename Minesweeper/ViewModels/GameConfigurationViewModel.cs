using MvvmHelpers;
namespace Minesweeper.ViewModels
{
    public class GameConfigurationViewModel : ViewModelBase
    {
        private int height;

        public int Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }


        private int width;

        public int Width
        {
            get => width;
            set => SetProperty(ref width, value);
        }

        private int minesCount;

        public int MinesCount
        {
            get => minesCount;
            set => SetProperty(ref minesCount, value);
        }



    }
}
