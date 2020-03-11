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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        #region Class Stuff
        /// <summary>
        /// MainWindow instance used for changing Frame and initializing game
        /// </summary>
        MainWindow main;

        /// <summary>
        /// Constructor initializes main
        /// </summary>
        /// <param name="main"></param>
        public GamePage(MainWindow main) {
            InitializeComponent();
            this.main = main;
        }
        #endregion

        #region Quit Game
        /// <summary>
        /// Takes user back to start screen if they wish.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMenu_Click(Object sender, RoutedEventArgs e) {
            // TODO: implemenent "are you sure?"
            main.Main.Content = new StartPage(main);
        }
        #endregion
    }
}
