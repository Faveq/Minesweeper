using Minesweeper.Commands;
using Minesweeper.Controllers;
using System;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Minesweeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        CustomGameConfigurationViewModel CustomGameConfigurationViewModel { get; }
        public ICommand OpenCustomGameSettingsCommand { get; }
        public ICommand RunPresetGameCommand { get; }
        public ICommand TimerCommand {  get; }

        private int minesCount;

        public int MinesCount
        {
            get => minesCount;
            set => SetProperty(ref minesCount, value);
        }

        private TimeSpan elapsedTime;
        public TimeSpan ElapsedTime
        {
            get => elapsedTime;
            set
            {
                if (elapsedTime != value)
                {
                    elapsedTime = value;
                    OnPropertyChanged(nameof(ElapsedTime));
                    OnPropertyChanged(nameof(ElapsedSeconds));
                }
            }
        }
        public int ElapsedSeconds
        {
            get { return (int)ElapsedTime.TotalSeconds; }
        }



        public MainViewModel(StackPanel stackPanel, Window gameWindow)
        {
            CustomGameConfigurationViewModel = new(stackPanel, gameWindow);
            OpenCustomGameSettingsCommand = new OpenCustomGameSettingsCommand(CustomGameConfigurationViewModel);
            RunPresetGameCommand = new RunPresetGameCommand(stackPanel, gameWindow);
            StatsController.GetViewModel(this);         
        }
    }
}
