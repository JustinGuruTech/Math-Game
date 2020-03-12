using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment_5 {
    /// <summary>
    /// Stores information about player
    /// </summary>
    public class Player {

        #region Class Variables
        /// <summary>
        /// Player name
        /// </summary>
        public string name;

        /// <summary>
        /// Player age
        /// </summary>
        public int age;

        /// <summary>
        /// List of games played and their results
        /// </summary>
        List<GameResult> games = new List<GameResult>();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Player(string name, int age) {
            try {
                this.name = name;
                this.age = age;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Add Game Result
        /// <summary>
        /// Add result to list of games
        /// </summary>
        /// <param name="correctGuesses"></param>
        /// <param name="time"></param>
        /// <param name="gameType"></param>
        public void AddGameResult(int correctGuesses, double time, int gameType) {
            try {
                games.Add(new GameResult(correctGuesses, time, gameType));
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
