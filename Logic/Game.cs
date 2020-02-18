using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Game
    {
        public Deck Deck = new Deck();

        public List<Bot> Gamers = new List<Bot>();

        public Dictionary<Card,Card> Round = new Dictionary<Card, Card>();

        public Game()
        {
            Gamers.Add(new Bot("Бот № 1"));
            Gamers.Add(new Bot("Бот № 2"));
        }

        public void FindAttackBot(List<Bot> gamers, Card card)
        {

            var AttackBot = gamers.OrderBy(q => q.CheckTrump(card.Suit)?.Value);

            AttackBot.First().Attack = true;

        }

        private void FillAllHand()
        {
            foreach(Bot bot in Gamers)
            {
                bot.FillHand(Deck);
            }
        }
    }
}
