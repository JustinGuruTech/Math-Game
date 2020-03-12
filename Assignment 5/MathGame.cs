using System;
using System.Reflection;

namespace Assignment_5 {
    
    /// <summary>
    /// Contains game logic behind math game
    /// </summary>
    public class MathGame {

        #region Class Variables
        /// <summary>
        /// Used for determining which function to call
        /// </summary>
        readonly int gameType;

        /// <summary>
        /// Random number generator class
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// Left operand stored for display
        /// </summary>
        int leftOperand;

        /// <summary>
        /// Right operand stored for display
        /// </summary>
        int rightOperand;

        /// <summary>
        /// Correct answer stored for answer checking
        /// </summary>
        int correctAnswer;
        #endregion

        #region Getters
        /// <summary>
        /// Returns gameType
        /// </summary>
        /// <returns></returns>
        public int GetGameType() {
            try {
                return gameType;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns left operand
        /// </summary>
        /// <returns></returns>
        public int GetLeftOperand() {
            try { 
                return leftOperand; 
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns right operand
        /// </summary>
        /// <returns></returns>
        public int GetRightOperand() {
            try {
                return rightOperand;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initializes variables passed in
        /// </summary>
        /// <param name="gameType"></param>
        /// <param name="playerName"></param>
        /// <param name="playerAge"></param>
        public MathGame(int gameType) {
            try {
                this.gameType = gameType;
                GenerateNumbers();
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Number Generation/Comparison
        /// <summary>
        /// Generate random numbers and correct answer
        /// </summary>
        public void GenerateNumbers() {
            try {
                // division
                if (gameType == 3) {
                    leftOperand = rand.Next(0, 11);
                    // loop until finding a number that divides into an integer
                    do {
                        rightOperand = rand.Next(1, 11);
                    } while (((double)leftOperand / rightOperand) % 1 != 0);
                    correctAnswer = leftOperand / rightOperand;
                } 
                // multiplication
                else if (gameType == 2) {
                    leftOperand = rand.Next(0, 11);
                    rightOperand = rand.Next(0, 11);
                    correctAnswer = leftOperand * rightOperand;
                } 

                // subtraction
                else if (gameType == 1) {
                    leftOperand = rand.Next(1, 11);
                    rightOperand = rand.Next(1, leftOperand + 1);
                    correctAnswer = leftOperand - rightOperand;
                }
                // addition
                else {
                    leftOperand = rand.Next(1, 11);
                    rightOperand = rand.Next(1, 11);
                    correctAnswer = leftOperand + rightOperand;
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Compare answer given to correct answer
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        public bool CheckAnswer(int userAnswer) {
            try {
                return (userAnswer == correctAnswer);
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
