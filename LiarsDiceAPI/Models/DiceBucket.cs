namespace LiarsDiceAPI.Models
{
    public class DiceBucket
    {
        public Die[] Dice { get; }

        public DiceBucket RollDice()
        {
            return this; // random
        }

        public DiceBucket RemoveDice()
        {
            return this;
        }

        public int Count(Die die){
            return Dice.Length;
        }
    }
}