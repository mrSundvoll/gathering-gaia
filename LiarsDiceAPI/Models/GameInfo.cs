using System;

namespace LiarsDiceAPI.Models
{
    public class GameInfo
    {
        public int PlayersJoined { get; set; }
        public int MaxPlayers { get; set; } = Game.MaxPlayers;
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public Guid Id { get; set; }
    }
}