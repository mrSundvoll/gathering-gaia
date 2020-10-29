using System.Collections.Generic;
using System.Linq;

namespace LiarsDiceAPI.Models
{
    public class DiceBag
    {
        public IEnumerable<Die> Dice { get; }

        private DiceBag(IEnumerable<Die> dice)
        {
            Dice = dice;
        }
        
        public static implicit operator DiceBag(int numDie) => NewBag(numDie);

        public DiceBag Reroll()
        {
            return NewBag(Dice.Count());
        }
        
        private static DiceBag NewBag(int numDie)
        {
            return new DiceBag(Roll(numDie));
        }
        
        private static IEnumerable<Die> Roll(int numDie)
        {
            for (var i = 0; i < numDie; i++)
            {
                yield return Die.Roll();
            }
        }
    }
}