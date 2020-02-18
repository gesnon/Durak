using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Bot
    {
        public string Name { get; set; }

        public bool Attack { get; set; }

        public List<Card> Hand { get; set; } = new List<Card>();

        public Bot(string name)
        {
            this.Name = name;
        }

        public void GetCard(Deck deck)
        {
            Hand.Add(deck.SetCard());
        }

        public void FillHand(Deck deck)
        {
            while (Hand.Count <= 6)
            {
                GetCard(deck);
            }
        }

        public Card CheckTrump(Suit suit)
        {
            var selectHand = from card in Hand
                             where card.Suit == suit
                             select card;
            var TrumpCard = selectHand.OrderBy(q => q.Value);

            return TrumpCard.FirstOrDefault();
        }

    }
}
