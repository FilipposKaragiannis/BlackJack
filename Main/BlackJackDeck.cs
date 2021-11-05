using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public interface IBlackJackDeck { }

    public class BlackJackDeck : IBlackJackDeck
    {
        private readonly int                  availableDecks;
        private readonly Deck<BlackJackCard>? deckInPlay;

        public BlackJackDeck(int numOfDecks)
        {
            var db          = new DeckBuilder();
            var defaultDeck = db.GetDefaultDeck();

            var decks = new Deck<BlackJackCard>[numOfDecks];

            Array.Fill(decks, new Deck<BlackJackCard>(defaultDeck));

            availableDecks = decks.Length;
            deckInPlay     = new Deck<BlackJackCard>(decks.SelectMany(s => s.GetAllCards()).ToArray());
        }

        public BlackJackDeck(IReadOnlyCollection<Deck<BlackJackCard>> decks)
        {
            availableDecks = decks.Count;
            deckInPlay     = new Deck<BlackJackCard>(decks.SelectMany(s => s.GetAllCards()).ToArray());
        }

        public void InitialiseDeck()
        {
            deckInPlay.Shuffle();
        }

        public BlackJackCard DealCard()
        {
            if(!deckInPlay.TryDealCard(out var d))
                throw new RunOutOfCardsException();

            return d;
        }

        public BlackJackCard[] DealHand(int cards)
        {
            var res = new BlackJackCard[cards];

            for(var i = 0; i < cards; i++)
                res[i] = DealCard();

            return res;
        }
    }
}
