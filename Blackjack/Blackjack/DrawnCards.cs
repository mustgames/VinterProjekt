using System;

namespace Blackjack
{
    public class DrawnCards
    { // DrawnCards keeps track of all cards outside the deck and keeps them in a dictionary
        Dictionary<int, Card> playedCards = new Dictionary<int, Card>();
        int i = 1;
        public void RememberCard(Card card)
        {
            playedCards.Add(i, card);
            i++;
        }
        public void ListPlayedCards() 
        { // Prints out all Cards in the playedCards

            for (int i = 1; i < playedCards.Count + 1; i++)
            {
                Console.WriteLine(playedCards[i].GetCardString());

            }
        }
        public void ClearCards()
        { // Clears cards, this methode is called when the deck is shuffled so you can keep track of the cards that are currently left in the deck
            i = 1;
            playedCards.Clear();
        }
    }
}