using System;
using System.Collections.Generic;
using System.Linq;
using LiarsDiceAPI.Models.Exceptions;

namespace LiarsDiceAPI.Models
{
    public class Game
    {
        public const int MaxPlayers = 4;
        public const int InitialDiceCount = 5;
        public GameRound CurrentRound { get; private set; }
        public string Name { get; }
        public GameStatus Status { get; private set; } = GameStatus.NotStarted;
        
        public List<GameRoundSummary> RoundSummaries { get; }

        public Game(string gameName)
        {
            Id = Guid.NewGuid();
            Name = gameName;
            GameRegistry.Registry.Add(Id, this);
            Players = new Player[] { };
            RoundSummaries = new List<GameRoundSummary>();
        }

        public Guid Id { get; }
        public Player[] Players { get; private set; }
        public IEnumerable<Player> ActivePlayers => Players.Where(player => !player.HasLost);
        public IEnumerable<Player> Losers => Players.Where(player => player.HasLost);

        public Player CurrentPlayer => Players.Length == 0 ? null : Players[_currentPlayerIndex];
        private int _currentPlayerIndex;
        
        public Bid LastBid { get; }

        public Player JoinGame(string userName)
        {
            switch (Status)
            {
                case GameStatus.Running:
                    throw new BadRequestException("Cannot join game that has already started");
                case GameStatus.Finished:
                    throw new BadRequestException("Cannot join game that is finished");
            }

            if (Players.Length >= MaxPlayers)
            {
                throw new BadRequestException("Max number of players");
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new BadRequestException("Username cannot be empty");
            }

            if (Players.Any(pl => userName.Equals(pl.UserName, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new BadRequestException("User with same name already registered");
            }

            var player = new Player(userName);
            Players = Players.Append(player).ToArray();
            return player;
        }

        public void StartGame()
        {
            if (Status == GameStatus.Running)
            {
                throw new InvalidOperationException("Cannot restart a running game");
            }

            if (Players.Length <= 1)
            {
                throw new InvalidOperationException("Requires more than 1 player");
            }

            Status = GameStatus.Running;
            ShufflePlayers();
            _currentPlayerIndex = 0;
            StartRound();
        }

        private void ShufflePlayers()
        {
            var rng = new Random();
            var n = Players.Length;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = Players[k];
                Players[k] = Players[n];
                Players[n] = value;
            }
        }

        private void GotoNextPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex >= Players.Length)
            {
                _currentPlayerIndex = 0;
            }
        }

        public void RollDice()
        {
            throw new NotImplementedException();
        }

        public void Call()
        {
            if (Status == GameStatus.Running)
            {
                CurrentRound.CallLiar(CurrentPlayer.UserId);
            }
        }

        public void Bid(Die die, int nrOfDice)
        {
            if (Status == GameStatus.Running)
            {
                CurrentRound.RaiseBid(new Bid(die, nrOfDice, CurrentPlayer.UserId));
                GotoNextPlayer();
            }
        }

        private void StartRound()
        {
            CurrentRound = new GameRound(this);
        }

        public void EndRound(GameRoundSummary gameRoundSummary)
        {
            RoundSummaries.Add(gameRoundSummary);
            
            // if called successfully, bidder loses a die and starts next round
            if (gameRoundSummary.CalledLiarSuccessfully)
            {
                HandleRoundLoser(gameRoundSummary.UserWithBid);
            }
            // otherwise caller loses a die and starts next round.
            else
            {
                HandleRoundLoser(gameRoundSummary.UserThatCalledLiar);
            }
            
        }

        private void HandleRoundLoser(Guid losingPlayerGuid)
        {
            for (var i = 0; i < Players.Length; i++)
            {
                if (Players[i].UserId.Equals(losingPlayerGuid))
                {
                    var losingPlayer = Players[i];
                    losingPlayer.RemoveDice();
                    
                    if (losingPlayer.HasLost)
                    {
                        NotifyPlayerOfLoss(losingPlayer);
                    }
                    else
                    {
                        // loser begins next round
                        _currentPlayerIndex = i;    
                    }
                    break;
                }
            }
            StartRound();
        }

        private void NotifyPlayerOfLoss(Player losingPlayer)
        {
            throw new NotImplementedException();
        }
    }
}