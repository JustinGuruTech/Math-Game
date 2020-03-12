using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_5 {
    /// <summary>
    /// Interaction logic for LeaderBoardPage.xaml
    /// </summary>
    public partial class LeaderBoardPage : Page {

        #region Constructor
        /// <summary>
        /// Constructor populates leaderboard from LeaderBoard object passed in
        /// </summary>
        /// <param name="leaderboard"></param>
        public LeaderBoardPage(LeaderBoard leaderboard) {
            InitializeComponent();

            LeaderBoardTitle.Content = "MathHead " + leaderboard.leaderboardType + " Leaderboard";

            // loop through every ranking
            foreach (PlayerRank rank in leaderboard.rankings) {

                // stack to hold score row
                StackPanel newScore = new StackPanel {
                    Height = ScoresStack.Height,
                    Orientation = Orientation.Horizontal
                };

                // name label
                Label label = new Label {
                    Foreground = Brushes.White,
                    Content = rank.player.name,
                    FontSize = 20,
                    Width = 314
                };
                newScore.Children.Add(label);

                // score label
                label = new Label {
                    Foreground = Brushes.White,
                    Content = rank.correctGuesses,
                    FontSize = 20,
                    Width = 172
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
        }
        #endregion
    }
}
