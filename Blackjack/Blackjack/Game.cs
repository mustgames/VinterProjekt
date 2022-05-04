namespace Blackjack
{
    public class Game // game classen is inspired by the game manger role in many other game projects ive seen where it is a object that has all gamelogic not connected to a specific object
    {
        bool gameRunning;
        public bool win;
        public Deck deck = new Deck();
        List<Player> players = new List<Player>();
        Player player = new Player();
        Dealer dealer = new Dealer();

        public void Intro()
        { // intro gives player some basic info and lets them input a string name
            players.Add(player);
            Console.WriteLine("Welcome to Blackjack");
            Console.WriteLine("What is your name gambling man!");
            // while(true)
            // {
            //try
            // {
            player.name = Console.ReadLine();
            //}
            // catch (SystemException. ArgumentOutOfRangeException)
            // {            
            //     throw;
            // }
            // }
            Console.WriteLine();
            Console.WriteLine(player.name + " press anything exept power off or alt + F4 to start loosing monies"); // other Malte thought instructions where to unclear
            gameRunning = true;
            win = false;
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Deal()
        { // Deal gives out the starting hand 2 cards for each player and 1 for dealer also checks for a blackjackwin 
            foreach (Player player in players) // removes all old cards in case of another round
            {
                if (player.hand.Count > 0)
                {
                    player.hand.Clear();
                    dealer.hand.Clear();
                }
            }
            if (deck.deckUnOrder.Count < 10)
            {
                deck.CreateDeck();
                Console.WriteLine("Time to shuffle deck");
            }
            foreach (Player player in players)
            {
                player.hand.Add(deck.deckUnOrder.Dequeue());
                player.hand.Add(deck.deckUnOrder.Dequeue());
                if (player.HandValue() == 21)
                {
                    BlackjackWin();
                }
            }
            dealer.hand.Add(deck.deckUnOrder.Dequeue());
        }

        public void OfferHit()
        {// offer hit first checks if the player has already won in case of blackjack then player can input y or n to accept or decline reciving another card
            while (true && player.HandValue() < 22 && dealer.HandValue() < 22 && gameRunning == true && win == false)
            {
                Console.WriteLine("Dealer has" + dealer.HandString());
                Console.WriteLine(player.name + " hand is a" + player.HandString());
                Console.WriteLine(player.name + " hand has a value of " + player.HandValue());
                Console.WriteLine();
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
        { // after the player has gotten as many cards as they want the dealer draws until either the player or the dealer wins, player wins if dealer busts wich is check for by the hit methode inherited from Player.cs 
            if (dealer.HandValue() < 22 && player.HandValue() < 22 && gameRunning == true && win == false)
            {
                while (true)
                {
                    if (dealer.HandValue() > player.HandValue() && dealer.HandValue() < 22 && win == false)
                    {
                        DealerWin();
                        break;
                    }
                    else if (dealer.HandValue() > 16 && player.HandValue() > dealer.HandValue() && win == false)
                    {
                        System.Console.WriteLine("dealer has to stay");
                        PlayerWin();
                        break;
                    }
                    else if (dealer.HandValue() > 21)
                    {
                        break;
                    }
                    dealer.Hit(deck.deckUnOrder.Dequeue());
                }
            }
        }
        public bool RematchOption()
        { // simple input y or n if you want to continue playing game will return to Deal() if y
            win = false;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("want play again? press [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "n" || input == "N")
                {
                    gameRunning = false;
                    return false;
                }
                else if (input == "y" || input == "Y")
                {
                    return true;
                }
            }
        }
        public void PlayerWin()
        { // Beacuse player can win at diffrent places this methode just stores a win which the other methodes will deal with accordingly so the game running loop can continue correctly
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
                Console.WriteLine(player.name + " hand is a" + player.HandString());
                Console.WriteLine("Player Wins dubble with a black jack win!");
                win = true;
            }
        }
    }
}