using System;
using System.Collections.Generic;
using System.Reflection;
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
        private MathGame game;

        /// <summary>
        /// Total number of games played
        /// </summary>
        private int games;

        /// <summary>
        /// Total number of correct guesses
        /// </summary>
        private int correctGuesses;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initializes main and sets name/age labels
        /// </summary>
        /// <param name="main"></param>
        public GamePage(MainWindow main, int gameType, string name, int age) {
            InitializeComponent();
            PlayerAnswer.Focus();

            // classes
            this.main = main;
            this.game = new MathGame(gameType);

            // update UI
            PlayerName.Content = "Name: " + name;
            PlayerAge.Content = "Age: " + age;
            LeftOperand.Content = game.GetLeftOperand();
            RightOperand.Content = game.GetRightOperand();
            SetOperator();
            games = 0;
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

        #region Answer Submission
        private void SubmitAnswer() {
            try {
                int playerAnswer;
                bool isNumber = Int32.TryParse(PlayerAnswer.Text, out playerAnswer);

                // user entered text
                if (!isNumber) {
                    GuessResult.Content = "Numbers, Please.";
                    return;
                } else {
                    // correct answer
                    if (game.CheckAnswer(playerAnswer)) {
                        correctGuesses++;
                        GuessResult.Content = "Correct!";
                    }
                    // wrong answer
                    else {
                        GuessResult.Content = "Incorrect.";
                    }

                }

                // update UI
                PlayerAnswer.Text = "";
                game.GenerateNumbers();
                LeftOperand.Content = game.GetLeftOperand();
                RightOperand.Content = game.GetRightOperand();
                games++;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
