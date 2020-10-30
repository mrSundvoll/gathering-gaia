using System;
using System.Linq;
using LiarsDiceAPI.Models;
using LiarsDiceAPI.Models.Exceptions;
using NUnit.Framework;

namespace Tests.ModelTests
{
    public class GameTests
    {
        [TestFixture]
        public class When_Creating_A_Game
        {
            [Test]
            public void Assure_Game_Status_Is_NotStarted()
            {
                var game = new Game("En game");
                Assert.That(game.Status, Is.EqualTo(GameStatus.NotStarted));
            }
        }

        [TestFixture]
        public class When_starting_a_game
        {
            [Test]
            public void Assure_more_than_one_player()
            {
                var game = new Game("et game");
                Assert.That(() => game.StartGame(), Throws.InvalidOperationException);
            }

            [Test]
            public void Assure_game_status_is_running()
            {
                var game = StartGame();

                Assert.That(game.Status, Is.EqualTo(GameStatus.Running));
            }

            [Test]
            public void Assure_all_players_has_starting_number_of_dices()
            {
                var game = StartGame();

                Assert.That(game.ActivePlayers.All(player => player.DiceCount == Game.InitialDiceCount), Is.True);
            }

            [Test]
            public void Assure_has_current_player()
            {
                var game = StartGame();

                Assert.That(game.CurrentPlayer, Is.Not.Null);
            }

            [Test]
            public void Assure_cannot_start_already_running_game()
            {
                var game = StartGame();

                Assert.That(() => game.StartGame(), Throws.InvalidOperationException);
            }

            [Test]
            public void Assure_only_game_master_can_start_game()
            {

            }

            private Game StartGame()
            {

                var game = new Game("et game");
                game.JoinGame("player 1");
                game.JoinGame("player 2");
                game.StartGame();
                return game;
            }
        }

        [TestFixture]
        public class When_joining_a_game
        {
            [Test]
            public void Assure_player_is_added()
            {
                var game = new Game("En game");
                game.JoinGame("My name");

                Assert.That(game.Players.FirstOrDefault().UserName, Is.EqualTo("My name"));
            }

            [Test]
            public void Assure_cant_join_game_with_max_players()
            {
                var game = new Game("En game");
                game.JoinGame("My name");
                game.JoinGame("My name 2");
                game.JoinGame("My name 3");
                game.JoinGame("My name 4");

                Assert.Throws<BadRequestException>(() => game.JoinGame("My name 5"));
            }

            [Test]
            public void Assure_player_username_must_be_unique()
            {
                var game = new Game("En game");
                game.JoinGame("My name");
                Assert.Throws<BadRequestException>(() => game.JoinGame("My name"));
            }

            [Test]
            public void Assure_player_username_not_empty()
            {
                var game = new Game("En game");


                Assert.Throws<BadRequestException>(() => game.JoinGame(null));
                Assert.Throws<BadRequestException>(() => game.JoinGame(""));
                Assert.Throws<BadRequestException>(() => game.JoinGame("     "));
            }
        }

        [TestFixture]
        public class When_Running_A_Game
        {
            private Game game;

            [Test]
            public void Then_Assure_Rounds_And_Players_Are_Handled_Correctly()
            {
                game = new Game("TestGame");
                game.JoinGame("Terje");
                game.JoinGame("Kjell Erik");
                game.JoinGame("Kjell Einar");
                game.JoinGame("Thomas");
                game.StartGame();

                var players = game.Players;
                Assert.That(players[0].UserId, Is.EqualTo(game.CurrentPlayer.UserId));
                game.Bid(3, 10);
                Assert.That(players[1].UserId, Is.EqualTo(game.CurrentPlayer.UserId));
                Assert.Throws<ArgumentException>(() => game.Bid(3, 10));
                game.Bid(3, 11);
                Assert.That(players[2].UserId, Is.EqualTo(game.CurrentPlayer.UserId));
                game.Bid(3, 12);
                Assert.That(players[3].UserId, Is.EqualTo(game.CurrentPlayer.UserId));
                game.Bid(3, 13);
                Assert.That(players[0].UserId, Is.EqualTo(game.CurrentPlayer.UserId));

                game.Call();

                Assert.That(game.RoundSummaries.Count, Is.EqualTo(1));



            }
        }
    }
}
