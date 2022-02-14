namespace Blackjack
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        public int handValue;
        public bool hasBlackJack;
        public string name;

        public int HandValue()
        {
            handValue = 0;
            foreach (Card card in hand)
            {
                handValue = handValue + card.value;
            }
            if (handValue <= 21)
            {
                return handValue;
            }
            else
            {
                foreach (Card hand in hand)
                {
                    if (hand.isAce == true)
                    {
                        handValue = handValue - 10;
                        Console.WriteLine("lets count that ace as a 1 now");
                    }
                }
                if (handValue <= 21)
                {
                    return handValue;
                }
                else
                {
                    Bust();
                    return handValue;
                }
            }
        }
        public void Hit(Card card)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(30);
                Console.WriteLine("..");
                System.Threading.Thread.Sleep(30);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(30);
                Console.Clear();
            }
            hand.Add(card);
            Console.WriteLine(name + " got a " + card.GetCardValue());
            Console.WriteLine(name + " hand is now valued at " + HandValue());
        }
        public void Bust()
        {

            if (this is Dealer)
            {
                Console.WriteLine("Player Wins!");
            }
            else
            {
                Console.WriteLine(handValue);
                Console.WriteLine(name + " busted and loose thier monines");
            }
        }
    }
}