using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Table
    {
        public Dictionary<Card, Card> Round { get; set; } = new Dictionary<Card, Card>();

        public Table()
        {

        }

        public List<Card> SetCurrentCards()
        {
            List<Card> SetCard = new List<Card>();

            foreach (var card in Round)
            {
                SetCard.Add(card.Key);

                if (card.Value != null)
                {
                    SetCard.Add(card.Value);
                }
            }
            return SetCard;
        }
    }
}
