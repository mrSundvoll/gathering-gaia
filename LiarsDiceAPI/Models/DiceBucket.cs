using System;
using System.Linq;

namespace LiarsDiceAPI.Models
{
    public class DiceBucket
    {
        public const int InitialDieCount = 6;

        private readonly Random _random = new Random(); 
        
        public Die[] Dice { get; private set;  }

        public DiceBucket()
        {
            Dice = new[]
            {
                (Die) RandomNumber(1,6),
                (Die) RandomNumber(1,6),
                (Die) RandomNumber(1,6),
                (Die) RandomNumber(1,6),
                (Die) RandomNumber(1,6)
            };
        }

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public DiceBucket RollDice()
        {
            return this; // random
        }

        public DiceBucket RemoveDice()
        {
            Dice = Dice.Skip(1).ToArray();
            return this;
        }

        public int Count(Die die){
            return Dice.Length;
        }
    }
}