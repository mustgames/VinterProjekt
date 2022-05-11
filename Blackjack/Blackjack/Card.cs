namespace Blackjack
{
    public class Card
    { // card is a base class for all cards. normal cards set their values manualy in the CreateDeck() method.
        public int value;
        public string suite;
        public bool isAce;
        public virtual string GetCardString()
        {
            return value + " of " + suite;
        }
    }
}