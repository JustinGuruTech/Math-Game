using System;
using System.Collections.Generic;
using System.Windows;
using System.Reflection;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Variables
        /// <summary>
        /// stores list of players registered into the game
        /// </summary>
        List<Player> playerList = new List<Player>();

        /// <summary>
        /// stores 4 leaderboards, one for each game type
        /// </summary>
        public List<LeaderBoard> leaderboards = new List<LeaderBoard>(4);
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes MainWindow and sets Frame to StartPage
        /// </summary>
        public MainWindow() {
            try {
                InitializeComponent();
                Main.Content = new StartPage(this); // display start page
                for (int i = 0; i < 4; i++) {
                    leaderboards.Add(new LeaderBoard(i));
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Player Insertion
        /// <summary>
        /// Adds new player to list
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player) {
            try {
                playerList.Add(player);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds player and score to leaderboard
        /// </summary>
        /// <param name="gameType"></param>
        /// <param name="CorrectGuesses"></param>
        /// <param name="time"></param>
        /// <param name="player"></param>
        public bool AddToLeaderBoard(int gameType, int CorrectGuesses, double time, Player player) {
            try {
                bool added = leaderboards[gameType].InsertPlayer(CorrectGuesses, time, player);
                return added;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// returns player if already registered, creates new and returns it if not
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public Player GetPlayer(string name, int age) {

            try {
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
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
