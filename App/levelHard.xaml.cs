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
    public sealed partial class levelHard : AppTests.Common.LayoutAwarePage
    {
        App thisApp = Application.Current as App;
        Move newMove;
        //Move data;

        public levelHard()
        {
            this.InitializeComponent();

            history.ItemsSource = thisApp.hardMoves;

            newMove = new Move(0, 0, 0, 0, 0);
            makeMove.DataContext = newMove;

            if (thisApp.hardMoves.Count > 0)
            {
                if (thisApp.hardMoves[0].Black == 7)
                {
                    makeMove.Visibility = Visibility.Collapsed;
                    info.Visibility = Visibility.Visible;
                }
            }

            if (thisApp.hardData.Value1 == -1)
            {
                thisApp.hardData = Move.randomData(5, 7);
                StorageProxy.writeToFile("hardData.xml", thisApp.hardData);
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
            newMove.Value1 = (newMove.Value1 + 1) % 5;
        }
        private void Button_Click_1_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value1 = (newMove.Value1 + 6) % 5;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 1) % 7;
        }
        private void Button_Click_2_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 6) % 7;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 1) % 7;
        }
        private void Button_Click_3_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 6) % 7;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            newMove.Value4 = (newMove.Value4 + 1) % 7;
        }
        private void Button_Click_4_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value4 = (newMove.Value4 + 6) % 7;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            newMove.Value5 = (newMove.Value5 + 1) % 7;
        }
        private void Button_Click_5_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value5 = (newMove.Value5 + 6) % 7;
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            //dodawanie rozwiązania 
            Move moveToAdd = newMove.checkMarks(thisApp.hardData, 5);
            thisApp.hardMoves.Insert(0, moveToAdd);
            //czyszczenie rozwiązania
            //newMove.clearMove();
            //informacja o ewentualnej wygranej
            if (moveToAdd.Black == 5)
            {
                makeMove.Visibility = Visibility.Collapsed;
                info.Visibility = Visibility.Visible;
                //dopsianie wyniku
                Double points = 1500 + (35 - thisApp.hardMoves.Count) * 100;
                thisApp.scoreList.addScore(new Score(points, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "trudny"));
                scoreInfo.Text = "Wygrałeś! Twój wynik: " + points.ToString() + " punktów.";
            }
            //zapianie stanu gry do pliku
            StorageProxy.writeToFile("hardMoves.xml", thisApp.hardMoves);

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
            thisApp.hardMoves.Clear();
            //newMove.clearMove();
            info.Visibility = Visibility.Collapsed;
            makeMove.Visibility = Visibility.Visible;
            thisApp.hardData = Move.randomData(5, 7);
            StorageProxy.writeToFile("hardMoves.xml", thisApp.hardMoves);
            StorageProxy.writeToFile("hardData.xml", thisApp.hardData);
        }

        private void restartMove_Click(object sender, RoutedEventArgs e)
        {
            newMove.clearMove();
        }

    }
}
