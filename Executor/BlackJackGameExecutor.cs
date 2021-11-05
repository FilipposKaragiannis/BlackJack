using Main;

namespace Executor
{
    public class BlackJackGameExecutor
    {
        public void Start()
        {
            var players = new[]
                          {
                              new AutoBlackJackPlayer("Filip"),
                              new AutoBlackJackPlayer("Elena")
                          };

            var dealer = new Dealer("Jack");

            var deck = new BlackJackDeck(5);
            deck.InitialiseDeck();


            foreach(var player in players)
            {
                player.StartNewHand();
                player.TakeCards(deck.DealHand(2));
            }

            dealer.TakeCard(deck.DealCard(), true);
            dealer.TakeCard(deck.DealCard(), false);
        }
    }
}
