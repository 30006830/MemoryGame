using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoryGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MemoryGame : Page
    {
        //https://www.tutorialr.com/pdf/uwp-memory-game.pdf
        List<Symbol> myList = new List<Symbol>();     
        
        public MemoryGame()
        {
            this.InitializeComponent();

            myList.Add(new Symbol("a1", "\U00012600/"));
            myList.Add(new Symbol("a2", "\U0001262D/"));
            myList.Add(new Symbol("a3", "\U0001265B/"));
            myList.Add(new Symbol("a4", "\U00012663/"));

            //{ 5, "\U0001267F/"},
            //{ 6, "\U00012693/"},
            //{ 7, "\U000126BD/"},
            //{ 8, "\U000126C4/"},     
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            a1.Content = myList.unicodeName;
        }
    }
}
