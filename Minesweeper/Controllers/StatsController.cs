using Minesweeper.Models;
using Minesweeper.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Minesweeper.Controllers
{
    public static class StatsController
    {  
        private static bool isRunning;
        private static MainViewModel? viewModel;
        private static readonly DispatcherTimer _timer = new(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, TimerTick, Application.Current.Dispatcher);
        

        public static void SetMinesCount(GameBoardSizeModel gameBoardSizeModel) {
            if (gameBoardSizeModel != null && gameBoardSizeModel != null)
            {
               viewModel.MinesCount = gameBoardSizeModel.MinesCount;
            }
        }
        public static void GetViewModel(MainViewModel viewModel)
        {
            if (viewModel != null)
            {
                StatsController.viewModel = viewModel;
            }

            isRunning = false;
        }

        private static void TimerTick(object? sender, EventArgs e)
        {

            if (_timer.IsEnabled && viewModel != null)
            {
                viewModel.ElapsedTime = viewModel.ElapsedTime.Add(TimeSpan.FromSeconds(1));
            }
        }

        public static void StartStop()
        {
            if (isRunning)
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
                isRunning = true;
            }
        }

        public static void Reset()
        {
            if (viewModel != null)
                viewModel.ElapsedTime = TimeSpan.Zero;
            _timer.Stop();
            isRunning = false;
        }

    }
}
