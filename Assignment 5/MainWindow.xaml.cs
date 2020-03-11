using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Stuff
        /// <summary>
        /// Stores instance of game being played
        /// </summary>
        MathGame game;

        /// <summary>
        /// Initializes MainWindow and sets Frame to StartPage
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            Main.Content = new StartPage(this); // display start page
        }
        #endregion

        /*
        private void MyMethod() {
            try {

            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            } 
        }
        */

        #region Start Game
        /// <summary>
        /// Initializes new game and stores in class variable
        /// </summary>
        /// <param name="gameType"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public void StartGame(int gameType, string name, int age) {
            game = new MathGame(gameType, name, age);
        }
        #endregion
    }
}
