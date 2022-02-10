using Blackjack;
Game game = new Game();
Console.WriteLine("Welcome to Blackjack");
game.Intro();
while(game.gameRunning == true)
{
    game.Update();
}

