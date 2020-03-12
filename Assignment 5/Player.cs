using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5 {
    /// <summary>
    /// Stores information about player
    /// </summary>
    public class Player {

        #region Class Stuff
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Player(string name, int age) {
            this.name = name;
            this.age = age;
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
            games.Add(new GameResult(correctGuesses, time, gameType));
        }
        #endregion
    }
}
