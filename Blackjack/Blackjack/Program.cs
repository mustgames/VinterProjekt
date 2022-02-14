using Blackjack;
Game game = new Game();
game.Intro();

while (game.gameRunning == true)
{
    game.Deal();
    if (game.win == false)
    {
        game.OfferHit();
        game.Reveal();

    }
    game.RematchOption();
}

Console.WriteLine("Bye bye take ur monies other day! (press anything to exit)");
Console.ReadKey();