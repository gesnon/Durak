using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BotLogic
{
    public interface IBotLogic
    {
        Card Attack(List<Card> round, List<Card> Hand, Suit suit);

        Card Defence(List<Card> round, List<Card> Hand, Suit suit, Card AttackCard);
    }
}
