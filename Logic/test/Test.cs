using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CurrentRound  // экземпляр этого класс нужно будет реализовать в Game.cs
    {
        public List<Card> RoundCards {get; set;} = new List<Card>; // это текущая атака/защита (содержить не более 12 карт и обнуляется после успешной атаки/защиты)        
       
        public CurrentRound ()
        {        
        }
        
        public void AddCardOnBoard (Card card)
        {
            RoundCards.Add(card)
        }
        
        public void SetAllCard(Bot botDef) // Передаёт все карты боту, который не смог защититься
        {
            botDef.Hand.AddRange(RoundCards);
        }
        
        public void ClearBoard ()
        {
            RoundCards.Clear();
        }
    }
    
    public class CurrentRound_2  // экземпляр этого класс нужно будет реализовать в Game.cs
    {
        public Dictionary<Card,Card> RoundCards {get; set;} = new Dictionary <Card,Card>();
        
        public CurrentRound()
        {
        }
        
        public void 
    }
    
    // этот метод надо будет добавить в класс Bot, он будет удалять карту из руки
    public void DeleteCard (Card card)
    {
        for(int i =0; i<Hand.Count, i++)
        {
            if (Hand[i]==card)
            {
                Hand.RemoveAT(i);
                break;
            }
            continue;
        }
    }
    
    // этот метод надо будет добавить в класс Bot, бот кидает карту на стол, в метод передаётся карта, которая опредяется отдельным методом
        public Card SetCard(Card setCard)
        {
            var selectCards = from card in Hand
                             where card == seTsuit
                             select card;
           // var TrumpCard =  selectHand.OrderBy(q => q.Value);
            return selectCards.FirstOrDefault();
        }
    // этот метод надо будет добавить в класс Bot, карта кидается на стол (атака)
        public void Attack(Dictionary currentRound)
        {
            currentRound.Add(SetCard(Card),null)
        }
}
