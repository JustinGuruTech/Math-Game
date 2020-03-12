using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5 {

    /// <summary>
    /// Information about players score to be displayed on leaderboard
    /// </summary>
    public class PlayerRank {

        #region Class Stuff
        /// <summary>
        /// Correct Guesses
        /// </summary>
        public int correctGuesses;

        /// <summary>
        /// Duration of game
        /// </summary>
        public double time;

        /// <summary>
        /// User
        /// </summary>
        public Player player;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="correctGuesses"></param>
        /// <param name="time"></param>
        /// <param name="player"></param>
        public PlayerRank(int correctGuesses, double time, Player player) {
            this.correctGuesses = correctGuesses;
            this.time = time;
            this.player = player;
        }
        #endregion
    }
}
