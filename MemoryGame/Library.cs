using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MemoryGame
{
    public class Library
    {
        private const string title = "Memory Game";
        private const int size = 4;

        private int moves = 0;
        private int firstID = 0;
        private int secondID = 0;
        private Button first;
        private Button second;
        private int[,] board = new int[size, size];
        private List<int> matches = new List<int>();
        private Random random = new Random((int)DateTime.Now.Ticks);

        private Dictionary<int, string> Symbols = new Dictionary<int, string>()
        {
            { 1, "1"},
            { 2, "2"},
            { 3, "3"},
            { 4, "4"},
            { 5, "5"},
            { 6, "6"},
            { 7, "7"},
            { 8, "8"},
        };

        #region Methods

        private void Show(string content, string title)
        {
            _ = new MessageDialog(content, title).ShowAsync();
        }

        private Viewbox myViewbox(int value)
        {
            TextBlock textblock = new TextBlock()
            {
                Text = Symbols[value],
                IsColorFontEnabled = true,
                TextLineBounds = TextLineBounds.Tight,
                FontFamily = new FontFamily("Lato"),
                HorizontalTextAlignment = TextAlignment.Center
            };
            return new Viewbox()
            {
                Child = textblock
            };
        }

        private List<int> Choose(int start, int maximum, int total)
        {
            int number;
            List<int> numbers = new List<int>();
            while ((numbers.Count < total))
            {
                number = random.Next(start, maximum + 1);
                if ((!numbers.Contains(number)) || (numbers.Count < 1))
                {
                    numbers.Add(number);
                }
            }
            return numbers;            
        }

        private void Match()
        {
            matches.Add(firstID);
            matches.Add(secondID);
            if (first != null)
            {
                first.Background = null;
                first = null;
            }
            if (second != null)
            {
                second.Background = null;
                second = null;
            }
            if (matches.Count == size * size)
            {
                Show($"Matched all Symbol phases in {moves} moves.", title);
                //SpeechSynthesizer mySpeech = new SpeechSynthesizer();

                //mySpeech.Speak("Congratulations you won");
            }
        }

        private async void NoMatch()
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            if (first != null)
            {
                first.Content = null;
                first = null;
            }
            if (second != null)
            {
                second.Content = null;
                second = null;
            };
        }

        private void Comparison()
        {
            if (firstID == secondID)
                Match();                
            else
                NoMatch();
            moves++;
            firstID = 0;
            secondID = 0;
        }

        private void Add(ref Grid grid, int row, int column)
        {
            Button button = new Button()
            {
                Width = 50,
                Height = 50,
                Margin = new Thickness(10),
                Style = (Style)Application.Current.Resources["ButtonRevealStyle"]
            };
            button.Click += (object sender, RoutedEventArgs e) =>
            {
                int selected;
                button = (Button)(sender);
                row = (int)button.GetValue(Grid.RowProperty);
                column = (int)button.GetValue(Grid.ColumnProperty);
                selected = board[row, column];
                if ((matches.IndexOf(selected) < 0))
                {
                    if (firstID == 0)
                    {
                        first = button;
                        firstID = selected;
                        first.Content = myViewbox(selected);
                    }
                    else if (secondID == 0)
                    {
                        second = button;
                        if (!first.Equals(second))
                        {
                            secondID = selected;
                            second.Content = myViewbox(selected);
                            Comparison();
                        }
                    }
                }
            };
            button.SetValue(Grid.ColumnProperty, column);
            button.SetValue(Grid.RowProperty, row);
            grid.Children.Add(button);
        }

        private void Layout(ref Grid grid)
        {
            moves = 0;
            matches.Clear();
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            for (int index = 0; (index < size); index++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; (row < size); row++)
            {
                for (int column = 0; (column < size); column++)
                {
                    Add(ref grid, row, column);
                }
            }
        }

        public void New(Grid grid)
        {
            Layout(ref grid);
            int counter = 0;
            List<int> values = new List<int>();
            while (values.Count <= size * size)
            {
                List<int> numbers = Choose(1, size * 2, size * 2);
                for (int number = 0; number < size * 2; number++)
                {
                    values.Add(numbers[number]);
                }
            }

            List<int> indices = Choose(1, size * size, size * size);
            for (int column = 0; column < size; column++)
            {
                for (int row = 0; row < size; row++)
                {
                    board[column, row] = values[indices[counter] - 1];
                    counter++;
                }
            }
        }
        #endregion
    }
}
