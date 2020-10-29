using System;
using System.Collections.Generic;
using System.Linq;

namespace LiarsDiceAPI.Models
{
    public class Game
    {
        public const int MaxPlayers = 4;
        public const int DefaultDice = 5;
        public GameRound CurrentRound { get; private set; }

        public Game()
        {
            Id = Guid.NewGuid();
            GameRegistry.Registry.Add(Id, this);
            Round = 0;
            Players = new Player[] { };
        }

        public Guid Id { get; }
        public int Round { get; }
        public Player[] Players { get; private set; }
        public IEnumerable<Player> ActivePlayers => Players.Where(player => !player.HasLost);
        public IEnumerable<Player> Losers => Players.Where(player => player.HasLost);
        
        public Player CurrentPlayer { get; }
        public Bid CurrentBid { get; }

        public bool HasStarted => Round > 0;

        public Player JoinGame(string userName)
        {
            if (HasStarted)
            {
                throw new InvalidOperationException("Cannot join game that has already started");
            }
            if (Players.Length >= MaxPlayers)
            {
                throw new InvalidOperationException("Max number of players");
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new InvalidOperationException("Username cannot be empty");
            }
            if (Players.Any(player => userName.Equals(player.UserName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException("User with same name already registered");
            }

            var player = new Player(userName);
            Players = Players.Append(player).ToArray();
            return player;
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

        public void StartRoundWith(Bid initialBid)
        {
            CurrentRound = new GameRound(initialBid, Id);
        }

        public static Game GetGameInstance(Guid guid)
        {
            // TODO: Handle Exceptions.
            return GameRegistry.Registry[guid];
        }

        public static IEnumerable<Player> GetActivePlayers(Guid guid)
        {
            return GetGameInstance(guid).ActivePlayers;
        }
    }
}