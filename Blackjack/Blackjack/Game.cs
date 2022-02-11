namespace Blackjack
{
    public class Game
    {
        public bool gameRunning;
        public Deck deck = new Deck();
        public int cardsInDeck;
        public List<Player> players = new List<Player>();

        public void Intro()
        {
            Console.WriteLine("Welcome to Blackjack");
            foreach (Card card in deck.deckUnOrder)
            {
                Console.WriteLine(card.GetCardValue());
            }
            Player player = new Player();
            System.Console.WriteLine("What is your name gambling man!");
            player.name = Console.ReadLine();
            Console.WriteLine(player.name + " press anything exept power off to start loosing monies");
            Console.ReadKey();
        }
        public void Deal()
        {
            foreach (Player player in players)
            {
                player.hand.Add(deck.deckUnOrder.Dequeue());
            }
        }
        public void Update()
        {
            
        }
    }

}