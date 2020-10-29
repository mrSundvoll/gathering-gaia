using System;

namespace LiarsDiceAPI.Models
{
    public class Player
    {
        public string UserName { get; set; }
        public DiceBucket Dice { get; set; }

        public Player(string userName)
        {
            UserName = userName;
        }

        public bool HasLost()
        {
            throw new NotImplementedException();
        }
    }
}