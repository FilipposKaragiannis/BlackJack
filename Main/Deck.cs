using System;

namespace Main
{
    public class Deck<T> where T : Card
    {
        private readonly T[] availableCards;
        private          int dealIndex;

        public Deck(T[] cards)
        {
            dealIndex      = 0;
            availableCards = cards;
        }

        public void Shuffle()
        {
            var random = new Random();

            for(var i = dealIndex; i < availableCards.Length; i++)
            {
                var index = random.Next(i, availableCards.Length - 1);
                (availableCards[i], availableCards[index]) = (availableCards[index], availableCards[i]);
            }
        }

        public T[] GetAllCards()
        {
            return availableCards;
        }

        public bool TryDealCard(out T card)
        {
            card = null;

            if(dealIndex >= availableCards.Length)
                return false;

            card = availableCards[dealIndex];
            card.MarkUnavailable();
            dealIndex++;
            return true;
        }
    }
}
