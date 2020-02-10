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
        
        public void SetAllCard(Bot botDef)
        {
            botDef.Hand.AddRange(RoundCards);
        }
        
        public void ClearBoard ()
        {
            RoundCards.Clear();
        }
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
        
}
