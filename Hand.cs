using System;
using System.Collections.Generic;
using System.Text;
using High_Rollers;

namespace High_Rollers
{
    class Hand
    {
        #region Variables

        public string PlayerName { get; set; }
        private int score;
        private readonly Die[] _hand = new Die[4];
        public int Score { get; set; }

        #endregion

        #region Constructors
        public Hand(string playerName)
        {
            PlayerName = playerName;
        }
        #endregion

        #region Public Methods

        public void RollHand()
        {
            Die d;

            for (int i = 0; i < _hand.Length; i++)
            {
                d = new Die();
                d.Roll();
                _hand[i] = d;
            }
        }

        public Die[] GetHand()
        {
            return _hand;
        }

        public void ShowHand()
        {
            Console.WriteLine("{0}'s hand: ", PlayerName);
            foreach (Die d in _hand)
                d.ShowResult();
            Console.WriteLine("");
        }
        #endregion
    }
}
