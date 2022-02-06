namespace Blackjack
{
    public class Card
    {
        public int value;
        public string suite;

        // public Card(string cardValue)
        // {

        // }
         
        public string GetCardValue (string cardValue)
        {
            return suite + value;
        }
    }
}