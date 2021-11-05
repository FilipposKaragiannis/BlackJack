using System;
using System.Linq;

namespace Main
{
    public class DeckBuilder
    {
        public BlackJackCard[] GetDefaultDeck()
        {
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToArray();
            var faces = Enum.GetValues(typeof(FaceValue)).Cast<FaceValue>().ToArray();

            var deck = (from s in suits
                        from f in faces
                        select new BlackJackCard(s, f)).ToArray();

            return deck;
        }
    }
}
