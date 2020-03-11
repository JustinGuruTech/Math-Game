using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5 {
    
    class MathGame {

        #region Class Variables
        /// <summary>
        /// Used for determining which function to call
        /// </summary>
        int gameType;

        /// <summary>
        /// Stored to display score at the end and could be used for high score page later
        /// </summary>
        string playerName;

        /// <summary>
        /// Stored to display score at the end and could be used for high score page later
        /// </summary>
        int playerAge;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initializes variables passed in
        /// </summary>
        /// <param name="gameType"></param>
        /// <param name="playerName"></param>
        /// <param name="playerAge"></param>
        public MathGame(int gameType, string playerName, int playerAge) {
            this.gameType = gameType;
            this.playerName = playerName;
            this.playerAge = playerAge;
        }
        #endregion
    }
}
