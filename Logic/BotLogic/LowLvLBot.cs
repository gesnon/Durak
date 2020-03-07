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
                    //bool qqq = round.Any(q => q.Value == SetCard.Value);

                    //if (qqq)
                    //{
                    //    round.Add(card, null);
                    //}
                    foreach(var cardOnTable in round)
                    {
                        if(cardOnTable.Key.Value==card.Value || cardOnTable.Value.Value == card.Value)     // дла каждой карты в руке и для каждой карты на столе, если их значения равны, то добавить карту из руки на стол
                        {
                            round.Add(card, null);
                        }
                    }
                }
            }

            if (round.Count() > 8)
            {
                List<Card> SetCards = SortHand.Where(q => q.Suit != suit && (int)q.Value < 5).ToList();

                foreach (var card in SetCards)
                {
                    //bool qqq = round.Any(q => q.Value == SetCard.Value);

                    //if (qqq)
                    //{
                    //    return card;
                    //}
                    foreach (var cardOnTable in round)
                    {
                        if (cardOnTable.Key.Value == card.Value || cardOnTable.Value.Value == card.Value)     // то же самое что и в условии для количества карт <8
                        {
                            round.Add(card, null);
                        }
                    }

                }
            }

            throw new Exception("Произошла странная хуйня !");
        }

        public void Defence(Dictionary<Card, Card> round, List<Card> Hand, Suit suit, Card AttackCard)
        {

            List<Card> SortHand = Hand.OrderBy(q => q.Value).ToList();

            List<Card> SetCards = SortHand.Where(q => q.Suit == AttackCard.Suit && (int)q.Value > (int)AttackCard.Value).ToList(); // попытка покрыть не козырем  

            if (round.Count() < 4)
            {
                if (SetCards.Count() != 0)
                {
                    round.FirstOrDefault(q => q.Key == AttackCard).Value = SetCards.First();   // наверное надо изменить модификатор доступа на public

                    //return SetCards.First();
                }
                //return null; // Нечем крыть, нужно брать        // не совсем понятно как сделать здесь
            }

            if (round.Count() > 8)
            {

                if (SetCards.Count() == 0)
                {
                    SetCards = SortHand.Where(q => q.Suit == suit).ToList();

                }
                if (SetCards.Count() != 0)
                {
                    round.FirstOrDefault(q => q.Key == AttackCard).Value = SetCards.First();   // наверное надо изменить модификатор доступа на public
                    //return SetCards.First();
                }

                //return null; // нечем крыть, нужно брать         // не совсем понятно как сделать здесь
            }

            //если количество карт на столе (5-8)

            if (SetCards.Count() == 0)
            {
                SetCards = SortHand.Where(q => q.Suit == suit && (int)q.Value < 5).ToList();
            }
            if (SetCards.Count() != 0)
            {
                round.FirstOrDefault(q => q.Key == AttackCard).Value = SetCards.First();   // наверное надо изменить модификатор доступа на public
                //return SetCards.First();
            }

            //return null; // нечем крыть, нужно брать              // не совсем понятно как сделать здесь

        }

    }
}
