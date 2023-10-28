using Minesweeper.Appdata;
using Minesweeper.Commands;
using Minesweeper.Controllers;
using Minesweeper.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private static int minesCount;

        public int MinesCount
        {
            get => minesCount;
            set => SetProperty(ref minesCount, value);
        }
        public int ElapsedSeconds
        {
            get { return (int)ElapsedTime.TotalSeconds; }
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

        CustomGameConfigurationViewModel CustomGameConfigurationViewModel { get; }
        public ICommand OpenCustomGameSettingsCommand { get; }
        public ICommand RunPresetGameCommand { get; }
        public ICommand ShutDownGameCommand { get; }
        public ICommand ShowAboutCommand { get; }




        public MainViewModel(StackPanel stackPanel, Window gameWindow)
        {
            CustomGameConfigurationViewModel = new(stackPanel, gameWindow);
            OpenCustomGameSettingsCommand = new OpenCustomGameSettingsCommand(CustomGameConfigurationViewModel);
            RunPresetGameCommand = new RunPresetGameCommand(stackPanel, gameWindow);         
            ShutDownGameCommand = new ShutDownGameCommand();
            ShowAboutCommand = new ShowAboutCommand();
            StatsController.GetViewModel(this);
            new GenerateGameBoardCommand(stackPanel, gameWindow).Execute(new AppData().ReadSavedData());
        }
    }
}
