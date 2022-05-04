namespace Blackjack
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        int handValue;
        public bool hasBlackJack;
        bool busted = false;
        public string name;


        public int HandValue() // checks hands value and busts 
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
                foreach (Card card in hand)
                {
                    if (card.isAce == true) // safe guard since ace can be 1 or 11
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
        public string HandString()
        {
            string returnString = " ";
            for (int i = 0; i < hand.Count; i++)
            {
                if (i != hand.Count - 1)
                {
                    returnString = returnString + hand[i].GetCardString() + ", ";
                }
                else
                {
                    returnString = returnString + hand[i].GetCardString();
                }
            }
            return returnString;
        }
        public void Hit(Card card)
        { // adds card to hand and prints its info 
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
                Console.Clear();
                System.Threading.Thread.Sleep(80);
                Console.WriteLine("..");
                Console.Clear();
                System.Threading.Thread.Sleep(80);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(80);
                Console.Clear();
            }
            hand.Add(card);
            Console.WriteLine(name + " got a " + card.GetCardString());
            Console.WriteLine(name + " hand is now valued at " + HandValue());
            Console.WriteLine();
            Console.WriteLine("press anything to continue");
            Console.ReadKey(true);
        }
        public void Bust()
        {
            if (this is Dealer && busted == false)
            {
                Console.WriteLine("Player Wins!");
                busted = true;
            }
            else
            {
                if (busted == false)
                {
                    Console.WriteLine(handValue);
                    Console.WriteLine(name + " busted and loose thier monines");
                    busted = true;
                }
            }
        }
    }
}