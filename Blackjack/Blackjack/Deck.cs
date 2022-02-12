namespace Blackjack
{
    public class Deck
    {
        public List<Card> deckOrder = new List<Card>();
        public Queue<Card> deckUnOrder = new Queue<Card>();
        public Random random = new Random();

        public string[] suites = { "Hearts", "Diamonds", "Clubs", "Spades" };
        public string[] dresses = { "Jack", "Queen", "King", };

        public Deck()
        {
            CreateDeck();
        }
        public void CreateDeck()
        {
            deckUnOrder.Clear();
            foreach (string suites in suites) // creates all cards form 2-10 in diffrent suites
            {
                for (int i = 2; i < 11; i++)
                {
                    var card = new Card { value = i, suite = suites };
                    deckOrder.Add(card);
                }
                foreach (string dresses in dresses) // creates all dressed cards in diffrent suites thier value is always 10 and is set in their constructor
                {
                    var dressedCard = new DressedCard { suite = suites, dress = dresses };
                    deckOrder.Add(dressedCard);
                }
                var ace = new Ace { suite = suites }; // creates all aces in diffrent suites thier value is set in constructor and then handeld by Player HandValue()
                deckOrder.Add(ace);
            }
            for (int i = 0; i < 52; i++) // change max number to 1- max cards in deck 
            {
                int x = random.Next(0, deckOrder.Count);
                deckUnOrder.Enqueue(deckOrder[x]);
                deckOrder.RemoveAt(x);
            }
        }
    }
}