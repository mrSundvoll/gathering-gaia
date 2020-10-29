using System;
using System.Collections.Generic;
using System.Linq;

namespace LiarsDiceAPI.Models
{
    public class Game
    {
        public const int MaxPlayers = 4;

        public Game()
        {
            Id = Guid.NewGuid();
            Round = 0;
            Players = new Player[] { };
        }

        public Guid Id { get; }
        public int Round { get; }
        public Player[] Players { get; }
        public IEnumerable<Player> ActivePlayers => Players.Where(player => player.HasLost);
        public IEnumerable<Player> Losers => Players.Where(player => !player.HasLost);
        public Player CurrentPlayer { get; }
        public Bid CurrentBid { get; }

        public void JoinGame(Player player)
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void RollDice()
        {
            throw new NotImplementedException();
        }

        public void Call()
        {
            throw new NotImplementedException();
        }

        public void Bid(Die die, int nrOfDice)
        {
            throw new NotImplementedException();
        }
    }
}