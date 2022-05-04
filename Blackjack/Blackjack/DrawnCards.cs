using System;

namespace Blackjack
{
    public class DrawnCards
    {
        Dictionary<int, Card> playedCards = new Dictionary <int, Card>();
        int i = 1;
        public void RememberCard(Card card)
        {
            playedCards.Add(i,card);
            i++;
       }
        public void ListPlayedCards()
        {
            for (int i = 1; i < playedCards.Count; i++)
            {
                Console.WriteLine(playedCards[i].GetCardString());        
            }
        }
    }
}