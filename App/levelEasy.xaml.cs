using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AppTests
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class levelEasy : AppTests.Common.LayoutAwarePage
    {
        App thisApp = Application.Current as App;
        Move newMove;

        public levelEasy()
        {
            this.InitializeComponent();

            history.ItemsSource = thisApp.easyMoves;

            newMove = new Move(0, 0, 0);
            makeMove.DataContext = newMove;

            if (thisApp.easyMoves.Count > 0)
            {
                if (thisApp.easyMoves[0].Black == 3)
                {
                    makeMove.Visibility = Visibility.Collapsed;
                    info.Visibility = Visibility.Visible;
                }
            }

            if (thisApp.easyData.Value1 == -1)
            {
                thisApp.easyData = Move.randomData(3, 3);
                StorageProxy.writeToFile("easyData.xml", thisApp.easyData);
            }


            //data = new Move(1, 2, 1);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newMove.Value1 = (newMove.Value1 + 1) % 3;
        }
        private void Button_Click_1_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value1 = (newMove.Value1 + 2) % 3;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 1) % 3;
        }
        private void Button_Click_2_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 2) % 3;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 1) % 3;
        }
        private void Button_Click_3_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 2) % 3;
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            //dodawanie rozwiązania 
            Move moveToAdd = newMove.checkMarks(thisApp.easyData, 3);
            thisApp.easyMoves.Insert(0, moveToAdd);
            //czyszczenie rozwiązania
            //newMove.clearMove();
            //informacja o ewentualnej wygranej
            if (moveToAdd.Black == 3)
            {
                makeMove.Visibility = Visibility.Collapsed;
                info.Visibility = Visibility.Visible;
                //dopsianie wyniku
                Double points = 500 + (9 - thisApp.easyMoves.Count) * 50;
                thisApp.scoreList.addScore(new Score(points, DateTime.Now.ToString("dd.MM.yyyy HH:mm")  , "łatwy"));
                scoreInfo.Text = "Wygrałeś! Twój wynik: "+ points.ToString() +" punktów.";
            }
            //zapianie stanu gry do pliku
            StorageProxy.writeToFile("easyMoves.xml", thisApp.easyMoves);

        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            startNewGame();
        }

        private void restartGame_Click(object sender, RoutedEventArgs e)
        {
            startNewGame();
        }

        private void startNewGame()
        {
            newMove.clearMove();
            thisApp.easyMoves.Clear();
            info.Visibility = Visibility.Collapsed;
            makeMove.Visibility = Visibility.Visible;
            thisApp.easyData = Move.randomData(3, 3);
            StorageProxy.writeToFile("easyMoves.xml", thisApp.easyMoves);
            StorageProxy.writeToFile("easyData.xml", thisApp.easyData);
        }

        private void restartMove_Click(object sender, RoutedEventArgs e)
        {
            newMove.clearMove();
        }

    }
}
