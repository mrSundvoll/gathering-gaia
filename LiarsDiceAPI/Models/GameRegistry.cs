using System;
using System.Collections.Generic;

namespace LiarsDiceAPI.Models
{
    public class GameRegistry
    {
        // TODO: use some different caching mechanism?
        public static Dictionary<Guid, Game> Registry { get; }

        static GameRegistry()
        {
            Registry = new Dictionary<Guid, Game>();
        }
    }
}