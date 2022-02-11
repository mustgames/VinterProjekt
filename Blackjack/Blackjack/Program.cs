using Blackjack;
Game game = new Game();
game.Intro();
while(game.gameRunning == true)
{
    game.Update();
}
