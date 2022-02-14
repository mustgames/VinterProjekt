namespace Blackjack
{
    public class Game
    {
        public bool gameRunning;
        public bool win;
        public Deck deck = new Deck();
        public int cardsInDeck;
        List<Player> players = new List<Player>();
        Player player = new Player();
        Dealer dealer = new Dealer();

        public void Intro()
        {
            players.Add(player);
            Console.WriteLine("Welcome to Blackjack");
            Console.WriteLine("What is your name gambling man!");
            player.name = Console.ReadLine();
            Console.WriteLine(player.name + " press anything exept power off or alt + F4 to start loosing monies"); // other Malte thought instructions where to unclear
            gameRunning = true;
            win = false;
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Deal()
        {
            foreach (Player player in players)
            {
                player.hand.Add(deck.deckUnOrder.Dequeue());
                player.hand.Add(deck.deckUnOrder.Dequeue());
                if (player.HandValue() == 21)
                {
                    BlackjackWin();
                }
                Console.WriteLine(player.name + " starting hand is a " + player.hand[0].GetCardValue() + " and a " + player.hand[1].GetCardValue());
            }
            dealer.hand.Add(deck.deckUnOrder.Dequeue());
        }
        public void OfferHit()
        {
            while (true)
            {
                if (win == true)
                {
                    break;
                }
                Console.WriteLine("Dealer has " + dealer.HandValue());
                Console.WriteLine("want card? press [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    player.Hit(deck.deckUnOrder.Dequeue());
                }
                else if (input == "n" || input == "N")
                {
                    Console.WriteLine("Staying are we");
                    break;
                }
                else
                {
                    Console.WriteLine("you input wrong. Only [y] for yes or [n] for no, I want no more of your silly games");
                }
            }
        }
        public void Reveal()
        {
            while (true)
            {
                if (dealer.HandValue() > player.HandValue())
                {
                    DealerWin();
                    break;
                }
                dealer.Hit(deck.deckUnOrder.Dequeue());
            }
        }
        public void RematchOption()
        {
            win = false;
            while (true)
            {
                Console.WriteLine("want play again? press [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "n" || input == "N")
                {
                    gameRunning = false;
                    break;
                }
            }
        }
        public void PlayerWin()
        {
            if (win == false)
            {
                Console.WriteLine("Player Wins!");
                win = true;
            }
        }
        public void DealerWin()
        {
            if (win == false)
            {
                Console.WriteLine("Dealer Wins yay!!! i get the monies");
                win = true;
            }
        }
        public void BlackjackWin()
        {
            if (win == false)
            {
                Console.WriteLine("Player Wins dubble with a black jack win!");
                win = true;
            }
        }
    }
}