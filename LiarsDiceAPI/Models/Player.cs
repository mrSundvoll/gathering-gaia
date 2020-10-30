using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace LiarsDiceAPI.Models
{
    public class Player
    {
        public string UserName { get;}
        public int DieLeft { get; } = Game.DefaultDice;
        public DiceBag DiceBag { get; private set; }

        [JsonIgnore]
        public Guid UserId { get; }

        public Player(string userName)
        {
            UserName = userName;
            UserId = Guid.NewGuid();
            RollDiceBag();
        }

        public bool HasLost => DiceBag.Dice.Count() <= 1;

        public void RollDiceBag()
        {
            DiceBag = DieLeft;
        }
        
        public void RemoveDice()
        {
            DiceBag = DiceBag.Dice.Count() - 1;
        }
    }
}