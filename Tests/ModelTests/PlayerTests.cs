using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LiarsDiceAPI.Models;
using NUnit.Framework;

namespace Tests.ModelTests
{
    public class PlayerTests
    {
        [TestFixture]
        public class When_creating_player
        {
            [Test]
            public void Assure_name_is_set()
            {
                var player = new Player("My name");

                Assert.That(player.UserName, Is.EqualTo("My name"));
            }
        }
    }
}
