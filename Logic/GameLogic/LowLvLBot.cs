using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.GameLogic
{
    class LowLvLBot
    {
        public Card Attack(List<Card> round, List<Card> Hand, Suit suit)
        {
            List<Card> SortHand = Hand.OrderBy(q => q.Value).ToList();

            Card SetCard = null;

            if (round.Count() == 0)
            {
                SetCard = SortHand.FirstOrDefault(q => q.Suit != suit);

                if (SetCard != null)
                {
                    return SetCard;
                }

                return SortHand.First();
            }

            if (round.Count() < 8)
            {
                List<Card> SetCards = SortHand.Where(q => q.Suit != suit).ToList();              

                foreach(var card in SetCards)
                {
                    bool qqq = round.Any(q => q.Value == SetCard.Value);

                    if (qqq)
                    {
                        return card;
                    }
                }
            }

            if (round.Count() > 8)
            {
                List<Card> SetCards = SortHand.Where(q => q.Suit != suit && (int)q.Value<5).ToList();

                foreach (var card in SetCards)
                {
                    bool qqq = round.Any(q => q.Value == SetCard.Value);

                    if (qqq)
                    {
                        return card;
                    }
                }
            }

            throw new Exception("Произошла странная хуйня !");
        }
    }
}
