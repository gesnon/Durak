using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Game
    {
        public void FindAttackBot(List<Bot> gamers, Card card)
        {

           var AttackBot = gamers.OrderBy(q => q.CheckTrump(card.Suit)?.Value);

           AttackBot.First().Attack = true;

        }
    }
}
