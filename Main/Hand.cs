using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public abstract class Hand<TCard> where TCard : Card
    {
        protected List<TCard> cards;

        protected Hand()
        {
            cards = new List<TCard>();
        }

        public virtual int Score => cards.Select(s => s.Value).Sum();

        public void AddCard(TCard card)
        {
            cards.Add(card);
        }
    }
}
