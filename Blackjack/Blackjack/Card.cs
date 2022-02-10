namespace Blackjack
{
    public class Card
    {
        public int value;
        public string suite;
        public bool isAce;
        public string GetCardValue()
        {
            return value + " of " + suite;
        }
    }
}