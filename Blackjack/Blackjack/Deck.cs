
namespace Blackjack
{
    public class Deck
    {
        List<Card> deckOrder = new List<Card>();
        public Queue<Card> deckUnOrder = new Queue<Card>();
        Random random = new Random();

        string[] suites = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] dresses = { "Jack", "Queen", "King", };

        public Deck() // room for improvement, wrote like this in case I would want to use the CreateDeck() methode to suffle the deck but I could have just put the deck in 
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
            for (int i = 0; i < 52; i++)  // shuffels the cards
            {
                int x = random.Next(0, deckOrder.Count);
                deckUnOrder.Enqueue(deckOrder[x]);
                deckOrder.RemoveAt(x);
            }
        }
    }
}