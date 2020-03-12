using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Assignment_5 {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        #region Class Variables
        /// <summary>
        /// MainWindow instance used for changing Frame and initializing game
        /// </summary>
        MainWindow main;

        /// <summary>
        /// Stores instance of game being played
        /// </summary>
        public MathGame game;

        /// <summary>
        /// Total number of games played
        /// </summary>
        private int games;

        /// <summary>
        /// Total number of correct guesses
        /// </summary>
        private int correctGuesses;

        /// <summary>
        /// Current player
        /// </summary>
        private Player player;

        /// <summary>
        /// Time elapsed
        /// </summary>
        private int time;

        DispatcherTimer myTimer;
        #endregion

        #region Getters
        public Player GetPlayer() {
            try {
                return player;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// return number of correct guesses
        /// </summary>
        /// <returns></returns>
        public int GetCorrectGuesses() {
            try {
                return correctGuesses;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// return time elapsed
        /// </summary>
        /// <returns></returns>
        public int GetTime() {
            try {
                return time;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initializes main and sets name/age labels
        /// </summary>
        /// <param name="main"></param>
        public GamePage(MainWindow main, int gameType, Player player) {
            try {
                InitializeComponent();
                

                // classes
                this.main = main;
                this.game = new MathGame(gameType);
                this.player = player;

                // update UI
                PlayerName.Content = "Name: " + player.name;
                PlayerAge.Content = "Age: " + player.age;
                
                SetOperator();
                games = 0;

                myTimer = new DispatcherTimer();
                myTimer.Interval = TimeSpan.FromSeconds(1);
                myTimer.Tick += MyTimer_Tick;
                
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        #endregion

        #region Timer
        /// <summary>
        /// Called every second by timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTimer_Tick(object sender, EventArgs e) {
            try {
                time++;
                TimeLabel.Content = "Time: " + time + "s";
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Start Game Button
        private void StartGame_Click(object sender, RoutedEventArgs e) {
            try {
                if (StartGame.Content.Equals("Start Game")) {
                    // set operands
                    LeftOperand.Content = game.GetLeftOperand();
                    RightOperand.Content = game.GetRightOperand();
                    // start timer and focus input
                    myTimer.Start();
                    PlayerAnswer.Focus();
                    // update button
                    StartGame.Content = "Submit Answer";
                    PlayerAnswer.IsEnabled = true;
                    PlayerAnswer.Focus();
                } else {
                    SubmitAnswer();
                } 
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Answer Submission
        private void SubmitAnswer() {
            try {
                int playerAnswer;
                bool isNumber = Int32.TryParse(PlayerAnswer.Text, out playerAnswer);

                // user entered text
                if (!isNumber) {
                    GuessResult.Foreground = Brushes.Red;
                    GuessResult.Content = "Numbers, Please.";
                    return;
                } else {
                    // correct answer
                    if (game.CheckAnswer(playerAnswer)) {
                        correctGuesses++;
                        GuessResult.Foreground = Brushes.Green;
                        GuessResult.Content = "Correct!";
                    }
                    // wrong answer
                    else {
                        GuessResult.Foreground = Brushes.Red;
                        GuessResult.Content = "Incorrect.";
                    }

                }

                // check if 10 games played
                games++;
                if (games >= 10) {
                    EndGame();
                    return;
                }

                // update UI
                PlayerAnswer.Text = "";
                game.GenerateNumbers();
                LeftOperand.Content = game.GetLeftOperand();
                RightOperand.Content = game.GetRightOperand();
                QuestionLabel.Content = "Question: " + (games + 1) + "/10";

            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Enter Key
        /// <summary>
        /// Allow user to press enter to submit answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterKeyHandler(object sender, KeyEventArgs e) {
            try {
                if (e.Key == Key.Return) {
                    SubmitAnswer();
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Quit Game
        /// <summary>
        /// Takes user back to start screen if they wish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMenu_Click(Object sender, RoutedEventArgs e) {

            try {
                // TODO: implemenent "are you sure?"
                main.Main.Content = new StartPage(main);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Operator UIUpdate
        /// <summary>
        /// Set operator to match game type
        /// </summary>
        private void SetOperator() {
            try {
                switch (game.GetGameType()) {
                    case 0:
                        OperatorLabel.Content = "+";
                        break;
                    case 1:
                        OperatorLabel.Content = "-";
                        break;
                    case 2:
                        OperatorLabel.Content = "x";
                        break;
                    case 3:
                        OperatorLabel.Content = (char)247;
                        break;

                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Endgame
        /// <summary>
        /// Shows result in dialog, saves user score and adds to leaderboard, and changes to leaderboard page
        /// </summary>
        public void EndGame() {
            try {
                myTimer.Stop(); // stop timer
                // add game result and display
                player.AddGameResult(correctGuesses, time, game.GetGameType());
                // add to leaderboard
                bool added = main.AddToLeaderBoard(game.GetGameType(), correctGuesses, time, player);
                // show results page
                main.Main.Content = new ResultsWindow(main, this, added);
                // show leaderboard page
                // main.Main.Content = new LeaderBoardPage(this, main.leaderboards[game.GetGameType()], main);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        #endregion

    }
}
