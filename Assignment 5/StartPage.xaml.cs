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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page {

        #region Class Variables
        /// <summary>
        /// MainWindow instance used for changing Frame and initializing game
        /// </summary>
        MainWindow main;

        /// <summary>
        /// passed to game initializer for game mode
        /// </summary>
        int gameType = 0;
        #endregion

        #region Initializer
        /// <summary>
        /// Initializer for StartPage, sets main to MainWindow passed in
        /// </summary>
        /// <param name="main"></param>
        public StartPage(MainWindow main) {
            InitializeComponent();
            this.main = main;
        }
        #endregion

        #region Mode Select
        /// <summary>
        /// Called when radio button is checked - sets game type class variable to correct game type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            String gameTypeString = (sender as RadioButton).Content.ToString();
            Console.WriteLine(gameType);

            // assign game type based on radio button pressed
            switch (gameTypeString) {
                case "Addition":
                    gameType = 0;
                    break;
                case "Subtraction":
                    gameType = 1;
                    break;
                case "Multiplication":
                    gameType = 2;
                    break;
                case "Division":
                    gameType = 3;
                    break;
            }

        }
        #endregion

        #region Validation and Start Game
        /// <summary>
        /// Validates user input, initializes game, and changes page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameButton_Click(object sender, RoutedEventArgs e) {

            // get ui elements into variables
            string name = NameInput.Text;
            int age = -1;
            Int32.TryParse(AgeInput.Text, out age);

            // name validation
            if (name.Length < 1) {
                ErrorLabel.Content = "Please enter a name.";
                return;
            }

            // age validation
            if (age < 0) {
                ErrorLabel.Content = "Enter a real age.";
                return;
            } else if (age < 3) {
                ErrorLabel.Content = "You must be 3 to play.";
                return;
            } else if (age > 10) {
                ErrorLabel.Content = "You must be under 10 to play.";
                return;
            }
            
            
            main.StartGame(gameType, name, age);
            main.Main.Content = new GamePage(main);
        }
        #endregion
    }
}
