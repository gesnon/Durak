using Logic.BotLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.GameLogic
{
    public class LowLvLBot : IBotLogic

    {
        public void Attack(Dictionary<Card,Card> round, List<Card> Hand, Suit suit)
        {
            List<Card> SortHand = Hand.OrderBy(q => q.Value).ToList();

            Card SetCard = null;

            if (round.Count() == 0)
            {
                SetCard = SortHand.FirstOrDefault(q => q.Suit != suit);

                if (SetCard != null)
                {
                    round.Add(SetCard,null);
                }

                round.Add(SortHand.First(), null);
            }

            if (round.Count() < 8)
            {
                List<Card> SetCards = SortHand.Where(q => q.Suit != suit).ToList();

                foreach (var card in SetCards)
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
                List<Card> SetCards = SortHand.Where(q => q.Suit != suit && (int)q.Value < 5).ToList();

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

        public Card Defence(List<Card> round, List<Card> Hand, Suit suit, Card AttackCard)
        {

            List<Card> SortHand = Hand.OrderBy(q => q.Value).ToList();

            List<Card> SetCards = SortHand.Where(q => q.Suit == AttackCard.Suit && (int)q.Value > (int)AttackCard.Value).ToList(); // попытка покрыть не козырем

            if (round.Count() < 4)
            {
                if (SetCards.Count() != 0)
                {

                    return SetCards.First();
                }
                return null; // Нечем крыть, нужно брать
            }

            if (round.Count() > 8)
            {

                if (SetCards.Count() == 0)
                {
                    SetCards = SortHand.Where(q => q.Suit == suit).ToList();

                }
                if (SetCards.Count() != 0)
                {

                    return SetCards.First();
                }

                return null; // нечем крыть, нужно брать
            }

            //если количество карт на столе (5-8)

            if (SetCards.Count() == 0)
            {
                SetCards = SortHand.Where(q => q.Suit == suit && (int)q.Value < 5).ToList();
            }
            if (SetCards.Count() != 0)
            {

                return SetCards.First();
            }

            return null; // нечем крыть, нужно брать

        }

    }
}
