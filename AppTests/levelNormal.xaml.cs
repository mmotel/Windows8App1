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
    public sealed partial class levelNormal : AppTests.Common.LayoutAwarePage
    {
        App thisApp = Application.Current as App;
        Move newMove;
        //Move data;


        public levelNormal()
        {
            this.InitializeComponent();

            history.ItemsSource = thisApp.normalMoves;

            newMove = new Move(0, 0, 0, 0, 0);
            makeMove.DataContext = newMove;

            if (thisApp.normalMoves.Count > 0)
            {
                if (thisApp.normalMoves[0].Black == 5)
                {
                    makeMove.Visibility = Visibility.Collapsed;
                    info.Visibility = Visibility.Visible;
                }
            }

            if (thisApp.normalData.Value1 == -1)
            {
                thisApp.normalData = Move.randomData(5, 5);
                StorageProxy.writeToFile("normalData.xml", thisApp.normalData);
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
            newMove.Value1 = (newMove.Value1 + 4) % 5;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 1) % 5;
        }
        private void Button_Click_2_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value2 = (newMove.Value2 + 4) % 5;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 1) % 5;
        }
        private void Button_Click_3_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value3 = (newMove.Value3 + 4) % 5;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            newMove.Value4 = (newMove.Value4 + 1) % 5;
        }
        private void Button_Click_4_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value4 = (newMove.Value4 + 4) % 5;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            newMove.Value5 = (newMove.Value5 + 1) % 5;
        }
        private void Button_Click_5_Down(object sender, RoutedEventArgs e)
        {
            newMove.Value5 = (newMove.Value5 + 4) % 5;
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            //dodawanie rozwiązania 
            Move moveToAdd = newMove.checkMarks(thisApp.normalData, 5);
            thisApp.normalMoves.Insert(0, moveToAdd);
            //czyszczenie rozwiązania
            //newMove.clearMove();
            //informacja o ewentualnej wygranej
            if (moveToAdd.Black == 5)
            {
                makeMove.Visibility = Visibility.Collapsed;
                info.Visibility = Visibility.Visible;
                //dopsianie wyniku
                Double points = 1000 + (25 - thisApp.normalMoves.Count) * 75;
                thisApp.scoreList.addScore(new Score(points, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "normalny"));
                scoreInfo.Text = "Wygrałeś! Twój wynik: " + points.ToString() + " punktów.";
            }
            //zapianie stanu gry do pliku
            StorageProxy.writeToFile("normalMoves.xml", thisApp.normalMoves);

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
            thisApp.normalMoves.Clear();
            //newMove.clearMove();
            info.Visibility = Visibility.Collapsed;
            makeMove.Visibility = Visibility.Visible;
            thisApp.normalData = Move.randomData(5, 5);
            StorageProxy.writeToFile("normalMoves.xml", thisApp.normalMoves);
            StorageProxy.writeToFile("normalData.xml", thisApp.normalData);
        }

        private void restartMove_Click(object sender, RoutedEventArgs e)
        {
            newMove.clearMove();
        }

    }
}
