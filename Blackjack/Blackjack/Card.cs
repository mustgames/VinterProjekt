namespace Blackjack
{
    public class Card
    {
        public int value;
        public string suite;
        public bool isAce;
        public virtual string GetCardString()
        {
            return value + " of " + suite;
        }
    }
}