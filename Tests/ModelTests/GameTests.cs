using System.Linq;
using LiarsDiceAPI.Models;
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
                var game = new Game();
                Assert.That(game.Status, Is.EqualTo(GameStatus.NotStarted));
            }
        }
        [TestFixture]
        public class When_joining_a_game
        {
            [Test]
            public void Assure_player_is_added()
            {
                var game = new Game();
                game.JoinGame("My name");

                Assert.That(game.Players.FirstOrDefault().UserName, Is.EqualTo("My name"));
            }

            [Test]
            public void Assure_cant_join_game_with_max_players()
            {
                var game = new Game();
                game.JoinGame("My name");
                game.JoinGame("My name 2");
                game.JoinGame("My name 3");
                game.JoinGame("My name 4");

                Assert.That(() => game.JoinGame("My name 5"), Throws.InvalidOperationException);
            }

            [Test]
            public void Assure_player_username_must_be_unique()
            {
                var game = new Game();
                game.JoinGame("My name");
                Assert.That(() => game.JoinGame("My name"), Throws.InvalidOperationException);
            }

            [Test]
            public void Assure_player_username_not_empty()
            {
                var game = new Game();
                Assert.That(() => game.JoinGame(null), Throws.InvalidOperationException);
                Assert.That(() => game.JoinGame(""), Throws.InvalidOperationException);
                Assert.That(() => game.JoinGame("  "), Throws.InvalidOperationException);
            }
        }
    }
}
