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
        List<Player> playerList = new List<Player>();

        public List<LeaderBoard> leaderboards = new List<LeaderBoard>(4);

        public void AddPlayer(Player player) {
            playerList.Add(player);
        }

        public void AddToLeaderBoard(int gameType, int CorrectGuesses, double time, Player player) {
            leaderboards[gameType].InsertPlayer(CorrectGuesses, time, player);
        }

        public Player GetPlayer(string name, int age) {

            // if player already exists
            int index = playerList.FindIndex(item => item.name == name && item.age == age);
            if (index >= 0) {
                return playerList[index];
            } 
            // new player
            else {
                Player player = new Player(name, age);
                AddPlayer(player);
                return player;
            }
        }
        /// <summary>
        /// Initializes MainWindow and sets Frame to StartPage
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            Main.Content = new StartPage(this); // display start page
            for (int i = 0; i < 4; i++) {
                leaderboards.Add(new LeaderBoard(i));
            }
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
    }
}
