using Minesweeper.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Minesweeper.Controllers
{
    public static class StatsController
    {
        private static MainViewModel viewModel;
        private static bool isRunning;
        private static DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, TimerTick, Application.Current.Dispatcher);

        public static void GetViewModel(MainViewModel viewModel)
        {
            StatsController.viewModel = viewModel;
            isRunning = false;
        }
        private static void TimerTick(object sender, EventArgs e)
        {
            if (timer.IsEnabled)
            {
                viewModel.ElapsedTime = viewModel.ElapsedTime.Add(TimeSpan.FromSeconds(1));
            }
        }

        public static void StartStop()
        {
            if (isRunning)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
                isRunning = true;
            }
        }

        public static void Reset()
        {
            viewModel.ElapsedTime = TimeSpan.Zero;
            timer.Stop();
            isRunning = false;
        }

    }
}
