using System;

namespace gathering_gaia.Models
{
    public class Player
    {
        public string UserName { get; set; }
        public DiceBucket Dice { get; set; }

        internal bool IsOutOfDice()
        {
            throw new NotImplementedException();
        }
    }
}