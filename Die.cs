using System;
using System.Collections.Generic;
using System.Text;

namespace High_Rollers
{
    class Die
    {
        #region Private Variables
        private int _face;
        #endregion

        public Die()
        {
            _face = 0;
        }

        #region Public Methods

        public void Roll()
        {
            var random = new Random();

            _face = random.Next(1, 6);
        }

        public int GetResult()
        {
            return _face;
        }

        public void ShowResult()
        {
            Console.Write("{0} ", _face);
        }
        #endregion
    }
}
