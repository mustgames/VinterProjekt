namespace Blackjack
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        public int higestHandValue;
        public int lowestHandValue;
        public bool hasBlackJack;
        public string name;

        public int HandValue(int value)
        {
            foreach (Card hand in hand)
            {
                higestHandValue = higestHandValue + hand.value;
            }
            if (higestHandValue < 21)
            {
                return higestHandValue;
            }
            else
            {
                foreach (Card hand in hand)
                {
                    if (hand.isAce == true)
                    {
                        higestHandValue = higestHandValue - 10;
                    }
                }
                if (higestHandValue < 21)
                {
                    return higestHandValue;
                }
                else { Bust(); return 0; }
            }
        }
        public void Bust()
        {
            Console.WriteLine(higestHandValue);
            Console.WriteLine(name + " busted and loose thier monines");
        }
    }
}