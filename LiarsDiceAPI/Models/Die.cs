using System;

namespace LiarsDiceAPI.Models
{
    public readonly struct Die
    {
        private readonly int _value;

        private Die(int value)
        {
            if (value < 1 || value > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Die numbers must be between 1 and 6");
            }

            this._value = value;
        }

        public static Die Roll()
        {
            return new Die(new Random().Next(1, 6));
        }

        public static implicit operator int(Die d) => d._value;

        public static implicit operator Die(int val) => new Die(val);
    }
}