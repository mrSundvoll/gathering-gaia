using System;
using System.Collections.Generic;
using System.Linq;

namespace LiarsDiceAPI.Models
{
    public class GameRound
    {
        private readonly Guid _gameId;

        // What is the current bid?
        public Bid CurrentBid { get; private set; }

        public GameRound(Bid initialBid, Guid gameId)
        {
            _gameId = gameId;
            CurrentBid = initialBid;
            RollDiceForAllPlayers();
        }

        private void RollDiceForAllPlayers()
        {
            var players = Game.GetActivePlayers(_gameId).ToList();
            players.ForEach(x =>
            {
                x.RollDiceBag(); 
            });
        }

        public void RaiseBid(Bid newBid)
        {
            CurrentBid = newBid;
        }

        public void CallLiar()
        {
        }
    }
}