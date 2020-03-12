using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection;


namespace Assignment_5 {
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Page {

        #region Class Variables
        /// <summary>
        /// main window stored for page switching
        /// </summary>
        MainWindow main;

        /// <summary>
        /// gamePage stored for displaying game information
        /// </summary>
        GamePage gamePage;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initializes main and gamePage and displays results
        /// </summary>
        /// <param name="main"></param>
        /// <param name="gamePage"></param>
        public ResultsWindow(MainWindow main, GamePage gamePage, bool added) {
            try {
                InitializeComponent();
                this.main = main;
                this.gamePage = gamePage;
                Player player = gamePage.GetPlayer();

                // update UI
                NameLabel.Content += player.name;
                AgeLabel.Content += player.age.ToString();
                CorrectLabel.Content += gamePage.GetCorrectGuesses().ToString();
                IncorrectLabel.Content += (10 - gamePage.GetCorrectGuesses()).ToString();
                TimeLabel.Content += gamePage.GetTime().ToString();
                if (added) {
                    MadeLeaderboard.Content = "You made the leaderboard!";
                } else {
                    MadeLeaderboard.Content = "You did not make the leaderborad.";
                }

                // assign correct background
                switch (gamePage.GetCorrectGuesses()) {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        GridBackground.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEB515B"));
                        BackgroundImage.Source = new BitmapImage(new Uri(@"images\bad.jpg", UriKind.Relative));
                        break;
                    case 5:
                    case 6:
                    case 7:
                        GridBackground.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE2BA75"));
                        BackgroundImage.Source = new BitmapImage(new Uri(@"images\thumb.png", UriKind.Relative));
                        break;
                    case 8:
                    case 9:
                    case 10:
                        GridBackground.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF66BC97"));
                        BackgroundImage.Source = new BitmapImage(new Uri(@"images\good.jpg", UriKind.Relative));
                        break;
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        #endregion

        #region Button Handlers
        /// <summary>
        /// Take user to leaderboard page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Leaderboard_Click(Object sender, RoutedEventArgs e) {
            try {
                main.Main.Content = new LeaderBoardPage(gamePage, main.leaderboards[gamePage.game.GetGameType()], main);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Take user to Menu page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BackToMenu_Click(Object sender, RoutedEventArgs e) {
            try {
                main.Main.Content = new StartPage(main);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Take user to new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayAgain_Click(Object sender, RoutedEventArgs e) {
            try {
                main.Main.Content = new GamePage(main, gamePage.game.GetGameType(), gamePage.GetPlayer());
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
