using System;
using System.Reflection;

namespace Assignment_5 {

    /// <summary>
    /// Information about players score to be displayed on leaderboard
    /// </summary>
    public class PlayerRank {

        #region Class Variables
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
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="correctGuesses"></param>
        /// <param name="time"></param>
        /// <param name="player"></param>
        public PlayerRank(int correctGuesses, double time, Player player) {
            try {
                this.correctGuesses = correctGuesses;
                this.time = time;
                this.player = player;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
