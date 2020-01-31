using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public Suit Trump;

        public Deck()
        {
            Create();

            Shuffle();

            GetTrump();
        }

        private void Create()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    Cards.Add(new Card(value, suit));
                }
            }
        }

        private void Shuffle()
        {
            var rand = new Random();
            for (var i = 0; i < Cards.Count; i++)
            {
                var r = rand.Next(0, 35);
                var card1 = Cards[i];
                Cards[i] = Cards[r];
                Cards[r] = card1;
            }
        }

        private void GetTrump()
        {   
            Card firstCard = Cards.First();

            Card lastCard = Cards.Last();

            Cards[35] = firstCard;

            Cards[0] = lastCard;

            this.Trump = firstCard.Suit;
        }

        public Card SetCard()
        {
            Card setCard = Cards.Last();

            Cards.RemoveAt(Cards.Count-1);

            return setCard;
        }
    }
}
