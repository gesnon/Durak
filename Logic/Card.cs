using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Card
    {
        public Suit Suit { get; set; }

        public Value Value { get; set; }

        public Card(Value value, Suit suit)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Suit} + {Value}";
        }
    }
}
