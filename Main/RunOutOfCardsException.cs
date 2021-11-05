using System;

namespace Main
{
    public class RunOutOfCardsException : Exception
    {
        public RunOutOfCardsException() : base("Deck is out of cards") { }
    }
}
