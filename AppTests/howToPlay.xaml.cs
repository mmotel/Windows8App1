using System;
using System.Collections.Generic;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AppTests
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class howToPlay : AppTests.Common.LayoutAwarePage
    {
        Move newMove;
        public howToPlay()
        {
            this.InitializeComponent();
            newMove = new Move(0,0,0,0,0);
            
            makeMove.DataContext = newMove;
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
    }
}
