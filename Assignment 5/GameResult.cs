using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5 {

    /// <summary>
    /// Holds correct guesses and time, helpful for leaderboard display
    /// </summary>
    class GameResult {

        #region Class Stuff
        /// <summary>
        /// Number of correct guesses
        /// </summary>
        int correctGuesses;

        /// <summary>
        /// Duration of game
        /// </summary>
        double time;

        /// <summary>
        /// Type of game played
        /// </summary>
        int gameType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="correctGuesses"></param>
        /// <param name="time"></param>
        public GameResult(int correctGuesses, double time, int gameType) {
            this.correctGuesses = correctGuesses;
            this.time = time;
            this.gameType = gameType;
        }
        #endregion
    }
}
