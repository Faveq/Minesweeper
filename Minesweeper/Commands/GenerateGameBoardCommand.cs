using Minesweeper.Appdata;
using Minesweeper.Controllers;
using Minesweeper.Models;
using Minesweeper.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Commands
{
    public class GenerateGameBoardCommand : BaseCommand
    {
        private readonly StackPanel _stackPanel;
        private readonly Window _gameWindow;
        private Button[,]? buttonsList;

        private ICommand? clickCommand;
        private readonly ICommand _restartGameCommand;
        private readonly ClickController _clickController;

        readonly ImageBrush _sand = new(new BitmapImage(new Uri("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Sand.jpg")));
        readonly ImageBrush _face = new(new BitmapImage(new Uri("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Face.png")));


        public GenerateGameBoardCommand(StackPanel stackPanel, Window gameWindow)
        {
            _stackPanel = stackPanel;
            _gameWindow = gameWindow;
            _restartGameCommand = new RestartGameCommand();
            _clickController = new();
        }

        public override void Execute(object? parameter)
        {
            Color backgroundColor = Color.FromArgb(5, 0, 0, 0);
            SolidColorBrush brush = new(backgroundColor);
            if (parameter != null)
            {
                Button restartButton = new();

                GameBoardSizeModel gameBoardSizeModel = (GameBoardSizeModel)parameter; //board size in parameter
                buttonsList = new Button[gameBoardSizeModel.Width, gameBoardSizeModel.Height];
                clickCommand = new ClickCommand(gameBoardSizeModel, buttonsList, restartButton);

                Grid grid = new();
                StackPanel stackPanel = new();

                _stackPanel.Children.Clear();
                _stackPanel.Children.Add(grid);
                _stackPanel.Children.Add(stackPanel);

                for (int i = 0; i < 3; i++)
                {
                    ColumnDefinition columnDefinition = new()
                    {
                        Width = new GridLength(1, GridUnitType.Star)
                    };
                    grid.ColumnDefinitions.Add(columnDefinition);
                }

                grid.Margin = new Thickness(0, 10, 0, 0);

                Border border1 = new Border
                {
                    BorderBrush = Brushes.Black,
                    Opacity = .7,
                    BorderThickness = new Thickness(1),
                    Width = 35
                };
                Border border2 = new Border
                {
                    BorderBrush = Brushes.Black,
                    Opacity = .7,
                    BorderThickness = new Thickness(1),
                    Width = 35
                };

                Binding minesCountTextBlockBinding = new("MinesCount");
                TextBlock minesCountTextBox = new()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    
                };
                minesCountTextBox.SetBinding(TextBlock.TextProperty, minesCountTextBlockBinding);

                restartButton.Width = 20;
                restartButton.Height = 20;
                restartButton.Command = _restartGameCommand;
                restartButton.CommandParameter = (gameBoardSizeModel, _stackPanel, _gameWindow);
                restartButton.HorizontalAlignment = HorizontalAlignment.Center;
                restartButton.VerticalAlignment = VerticalAlignment.Center;
                restartButton.Background = _face;
                restartButton.BorderBrush = Brushes.Black;

                TextBlock timeTextBlock = new();
                Binding timeTextBlockBinding = new("ElapsedSeconds");
                timeTextBlock.SetBinding(TextBlock.TextProperty, timeTextBlockBinding);
                timeTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                timeTextBlock.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(border1, 0);
                grid.Children.Add(border1);
                Grid.SetColumn(minesCountTextBox, 0);
                grid.Children.Add(minesCountTextBox);
                Grid.SetColumn(restartButton, 1);
                grid.Children.Add(restartButton);
                Grid.SetColumn(border2, 2);
                grid.Children.Add(border2);
                Grid.SetColumn(timeTextBlock, 2);
                grid.Children.Add(timeTextBlock);

                _stackPanel.Background = _sand;
                stackPanel.Width = gameBoardSizeModel.Width * 17 + 30;
                stackPanel.Height = gameBoardSizeModel.Height * 17;
                stackPanel.Margin = new Thickness(6, 10, 6, 5);

                _gameWindow.Width = gameBoardSizeModel.Width * 17 + 30;
                _gameWindow.Height = gameBoardSizeModel.Height * 17 + 100;



                for (int y = 0; y < gameBoardSizeModel.Height; y++)
                {
                    string buttonName = "";
                    WrapPanel wrappanel = new()
                    {
                        Width = stackPanel.Width
                    };
                    stackPanel.Children.Add(wrappanel);

                    for (int x = 0; x < gameBoardSizeModel.Width; x++)
                    {
                        buttonName = (x + 1).ToString() + "_" + (y + 1).ToString();
                        Button button = new()
                        {
                            Height = 17,
                            Width = 17,
                            Background = brush,
                            Command = clickCommand,
                            Name = "b" + buttonName
                        };
                        buttonsList[x, y] = button;
                        button.CommandParameter = button; // showing btn pos (x,y)
                        button.MouseRightButtonDown += _clickController.RightClicked;


                        wrappanel.Children.Add(button);
                    }
                }

                ExploreAreaController.PassButtonsList(buttonsList);
                StatsController.SetMinesCount(gameBoardSizeModel);
                StatsController.Reset();
                StatsController.StartStop();
                AppData.SaveData(gameBoardSizeModel);
            }

        }


    }
}
