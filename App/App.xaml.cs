using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;
using Callisto.Controls;
using Windows.UI;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace AppTests
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public Moves easyMoves;
        public Move easyData;
        public Moves normalMoves;
        public Move normalData;
        public Moves hardMoves;
        public Move hardData;
        public ScoresList scoreList;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            easyMoves = new Moves();
            easyData = new Move();

            normalMoves = new Moves();
            normalData = new Move();

            hardMoves = new Moves();
            hardData = new Move();

            scoreList = new ScoresList();

            StorageProxy.readFromFile("easyData.xml", easyData);
            StorageProxy.readFromFile("normalData.xml", normalData);
            StorageProxy.readFromFile("hardData.xml", hardData);

            StorageProxy.readFromFile("easyMoves.xml", easyMoves);
            StorageProxy.readFromFile("normalMoves.xml", normalMoves);
            StorageProxy.readFromFile("hardMoves.xml", hardMoves);
            StorageProxy.readFromFile("scores.xml", scoreList);

        }



        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                    
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            //settings
            SettingsPane.GetForCurrentView().CommandsRequested += Settings_CommandsRequested;

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

           
     
        }

        private void Settings_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
           /* // Settings Wide
            SettingsCommand storage = new SettingsCommand("SettingsW", "Settings Wide", (x) =>
            {
                SettingsFlyout settings = new SettingsFlyout();
                settings.FlyoutWidth = Callisto.Controls.SettingsFlyout.SettingsFlyoutWidth.Wide;
                settings.HeaderText = "Settings Wide";

                settings.Content = new CallistoSettings.SettingsViews.SettingsWide();
                settings.IsOpen = true;
            });
            args.Request.ApplicationCommands.Add(storage);

            // Settings Narrow
            SettingsCommand settingsNarrow = new SettingsCommand("SettingsNarrow", "Settings Narrow", (x) =>
            {
                SettingsFlyout settings = new SettingsFlyout();
                settings.FlyoutWidth = Callisto.Controls.SettingsFlyout.SettingsFlyoutWidth.Narrow;
                settings.HeaderBrush = new SolidColorBrush(Colors.Orange);
                settings.Background = new SolidColorBrush(Colors.Gray);
                settings.HeaderText = "Settings Narrow";

                settings.Content = new CallistoSettings.SettingsViews.SettingsNarrow();
                settings.IsOpen = true;
            });
            args.Request.ApplicationCommands.Add(settingsNarrow);
            */

            // About
            SettingsCommand about = new SettingsCommand("O grze", "O grze", (x) =>
            {
                SettingsFlyout settings = new SettingsFlyout();
                settings.FlyoutWidth = Callisto.Controls.SettingsFlyout.SettingsFlyoutWidth.Narrow;
                settings.HeaderText = "O grze";

                settings.Content = new CallistoSettings.SettingsViews.About();
                settings.IsOpen = true;
            });
            args.Request.ApplicationCommands.Add(about);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
           // writeToFile(easyMoves, "easyMoves.xml");
            deferral.Complete();
        }

    }
}
