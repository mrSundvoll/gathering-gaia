using System;

namespace LiarsDiceAPI.Models
{
    public class Player
    {
        public string UserName { get; set; }
        public DiceBucket DiceBucket { get; set; }

        public Player(string userName)
        {
            UserName = userName;
            DiceBucket = new DiceBucket();
        }

        public bool HasLost => DiceBucket.Dice.Length <= 1;

        public void RemoveDice()
        {
            DiceBucket.RemoveDice();
        }
    }
}