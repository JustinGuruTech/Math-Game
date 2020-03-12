using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;

namespace Assignment_5 {
    /// <summary>
    /// Interaction logic for LeaderBoardPage.xaml
    /// </summary>
    public partial class LeaderBoardPage : Page {

        #region Class Variables
        /// <summary>
        /// Stores MainWindow as main for transitioning pages
        /// </summary>
        MainWindow main;

        /// <summary>
        /// Stores GamePage for restarting game with same parameters
        /// </summary>
        GamePage gamePage;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor populates leaderboard from LeaderBoard object passed in
        /// </summary>
        /// <param name="leaderboard"></param>
        public LeaderBoardPage(GamePage gamePage, LeaderBoard leaderboard, MainWindow main) {
            try {
                InitializeComponent();
                this.main = main;
                this.gamePage = gamePage;

                LeaderBoardTitle.Content = leaderboard.leaderboardType;

                int i = 1;
                // loop through every ranking
                foreach (PlayerRank rank in leaderboard.rankings) {

                    // stack to hold score row
                    StackPanel newScore = new StackPanel {
                        Height = ScoresStack.Height,
                        Orientation = Orientation.Horizontal
                    };

                    Label label = new Label {
                        Foreground = Brushes.White,
                        Content = i++,
                        FontSize = 20,
                        Width = 60
                    };
                    newScore.Children.Add(label);

                    // name label
                    label = new Label {
                        Foreground = Brushes.White,
                        Content = rank.player.name,
                        FontSize = 20,
                        Width = 300
                    };
                    newScore.Children.Add(label);

                    // score label
                    label = new Label {
                        Foreground = Brushes.White,
                        Content = rank.correctGuesses,
                        FontSize = 20,
                        Width = 80
                    };
                    newScore.Children.Add(label);

                    // time label
                    label = new Label {
                        Foreground = Brushes.White,
                        Content = rank.time,
                        FontSize = 20
                    };
                    newScore.Children.Add(label);
                    ScoresStack.Children.Add(newScore);
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Button Handlers
        /// <summary>
        /// Handles clicking back to menu button - Initializes new start page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMenu_Click(object sender, RoutedEventArgs e) {
            try {
                main.Main.Content = new StartPage(main);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Handles clicking play again button - initializes new game with current gameType/player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAgain_Click(object sender, RoutedEventArgs e) {
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
