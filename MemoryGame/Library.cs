using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            { 1, "\U00012600/"},
            { 2, "\U0001262D/"},
            { 3, "\U0001265B/"},
            { 4, "\U00012663/"},
            { 5, "\U0001267F/"},
            { 6, "\U00012693/"},
            { 7, "\U000126BD/"},
            { 8, "\U000126C4/"},
        };

        #region Methods

        private void Show(string content, string title)
        {
            _ = new MessageDialog(content, title).ShowAsync();
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
            }
        }

        private async void NoMatch()
        {
            await Task.Delay(TimeSpan.FromSeconds(1.5));
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
                Width = 75,
                Height = 75,
                Margin = new Thickness(10),
                Style = (Style)Application.Current.Resources["ButtonRevealStyle"]
            };
            button.Click += (object sender, RoutedEventArgs e) =>
            {

            }
        }
        #endregion
    }
}
