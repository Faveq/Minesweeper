using Minesweeper.Commands.ClickingCommands;
using Minesweeper.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Input;
using Minesweeper.ViewModels;
using System.Windows.Data;
using Minesweeper.Controllers;
using Minesweeper.Views;
using System.Diagnostics;

namespace Minesweeper.Commands
{
    public class GenerateGameBoardCommand : BaseCommand
    {
        private readonly StackPanel _stackPanel;
        private readonly Window _gameWindow;
        private Button[,] buttonsList;

        private ICommand clickCommand;
        private ICommand restartGameCommand;
        private ClickController clickController;

        ImageBrush sand = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\batek\\OneDrive\\Documents\\GitHub\\Minesweeper\\Minesweeper\\Resources\\Sand.jpg")));
        public GenerateGameBoardCommand(StackPanel stackPanel, Window gameWindow)
        {
            _stackPanel = stackPanel;
            _gameWindow = gameWindow;
            restartGameCommand = new RestartGameCommand();
            clickController = new();
        }


        public override void Execute(object? parameter)
        {
            Color backgroundColor = Color.FromArgb(5, 0, 0, 0); // Kolor RGBA: 0,0,0,140
            SolidColorBrush brush = new SolidColorBrush(backgroundColor);
            if (parameter != null)
            {
                GameBoardSizeModel gameBoardSizeModel = (GameBoardSizeModel)parameter; //board size in parameter
                buttonsList = new Button[gameBoardSizeModel.Width, gameBoardSizeModel.Height];
                clickCommand = new ClickCommand(gameBoardSizeModel, buttonsList);

                Grid grid = new Grid();
                StackPanel stackPanel = new StackPanel();

                _stackPanel.Children.Clear();
                _stackPanel.Children.Add(grid);
                _stackPanel.Children.Add(stackPanel);



                for (int i = 0; i < 3; i++)
                {
                    ColumnDefinition columnDefinition = new ColumnDefinition();
                    columnDefinition.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columnDefinition);
                }



                grid.Margin = new Thickness(0, 10, 0, 0);

                TextBlock minesCountTextBox = new();
                minesCountTextBox.Text = "mines";
                minesCountTextBox.HorizontalAlignment = HorizontalAlignment.Center;
                minesCountTextBox.VerticalAlignment = VerticalAlignment.Center;

                Button restartButton = new();
                restartButton.Width = 16;
                restartButton.Height = 16;
                restartButton.Command = restartGameCommand;
                restartButton.CommandParameter = (gameBoardSizeModel, _stackPanel, _gameWindow);
                restartButton.HorizontalAlignment = HorizontalAlignment.Center;
                restartButton.VerticalAlignment = VerticalAlignment.Center;

                TextBlock timeTextBlock = new();
                Binding timeTextBlockBinding = new Binding("ElapsedSeconds");
                timeTextBlock.SetBinding(TextBlock.TextProperty, timeTextBlockBinding);
                timeTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                timeTextBlock.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(minesCountTextBox, 0);
                grid.Children.Add(minesCountTextBox);
                Grid.SetColumn(restartButton, 1);
                grid.Children.Add(restartButton);
                Grid.SetColumn(timeTextBlock, 2);
                grid.Children.Add(timeTextBlock);

                _stackPanel.Background = sand;
                stackPanel.Width = gameBoardSizeModel.Width * 17 + 30;
                stackPanel.Height = gameBoardSizeModel.Height * 17;
                stackPanel.Margin = new Thickness(6, 10, 6, 5);

                _gameWindow.Width = gameBoardSizeModel.Width * 17 + 30;
                _gameWindow.Height = gameBoardSizeModel.Height * 17 + 100;



                for (int y = 0; y < gameBoardSizeModel.Height; y++)
                {
                    string buttonName = "";
                    WrapPanel wrappanel = new WrapPanel();

                    wrappanel.Width = stackPanel.Width;
                    stackPanel.Children.Add(wrappanel);

                    for (int x = 0; x < gameBoardSizeModel.Width; x++)
                    {
                        buttonName = (x + 1).ToString() + "_" + (y + 1).ToString();
                        Button button = new Button();
                        button.Height = 17;
                        button.Width = 17;
                        button.Background = brush;
                        button.Command = clickCommand;
                        button.Name = "b" + buttonName;
                        buttonsList[x, y] = button;
                        button.CommandParameter = button; // showing btn pos (x,y)
                        button.MouseRightButtonDown += clickController.RightClicked;


                        wrappanel.Children.Add(button);
                    }
                }

                ExploreArea.PassButtonsList(buttonsList);
                StatsController.Reset();
                StatsController.StartStop();
            }
        }

        
    }
}
