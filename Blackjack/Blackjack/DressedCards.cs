namespace Blackjack
{
    public class DressedCard : Card
    {
        public string dress;
        public DressedCard()
        {
            value = 10;
        }
        public override string GetCardString()
        {
            return dress + " of " + suite;
        }
    }
}