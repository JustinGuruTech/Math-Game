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

        MainWindow main;
        int gameType = 0;
        public StartPage(MainWindow main) {
            InitializeComponent();
            this.main = main;
        }

        /// <summary>
        /// Called when radio button is checked - sets game type class variable to correct game type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            String gameTypeString = (sender as RadioButton).Content.ToString();
            Console.WriteLine(gameType);
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

        private void StartGameButton_Click(object sender, RoutedEventArgs e) {

            main.Main.Content = new GamePage(main);
        }
    }
}
