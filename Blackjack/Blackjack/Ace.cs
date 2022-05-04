namespace Blackjack
{
    public class Ace : Card
    {
        public Ace()
        {
            value = 11;
            isAce = true;
        }
        public override string GetCardString()
        {
            return "Ace " + suite;
        }
    }
}