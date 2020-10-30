using System;

namespace LiarsDiceAPI.Models
{
    public struct Bid
    {
        public Die Die { get; }
        public int NrOfDice { get; }
        public Guid UserId { get; }
    }
}