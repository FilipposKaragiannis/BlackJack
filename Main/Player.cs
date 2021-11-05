using System;
using System.Collections.Generic;

namespace Main
{
    public abstract class Player
    {
        protected LinkedList<BlackJackHand> hands;
        public    string                    Id;
        public    string                    Name;

        protected Player(string name, string id)
        {
            Id   = id;
            Name = name;
        }

        public abstract Move GetNextMove();

        public void StartNewHand()
        {
            hands.AddFirst(new BlackJackHand());
        }
    }

    public enum Move
    {
        HIT,
        STAND,
        SPLIT,
        INSURANCE
    }

    public class AutoBlackJackPlayer : Player
    {
        public AutoBlackJackPlayer(string name) : base(name, Guid.NewGuid().ToString()) { }

        public override Move GetNextMove()
        {
            var hand = hands.First;

            return hand.Value.Score < 16 ? Move.HIT : Move.STAND;
        }

        public void TakeCards(BlackJackCard[] dealHand) { }
    }

    public class Dealer : Player
    {
        public Dealer(string name) : base(name, Guid.NewGuid().ToString()) { }

        public override Move GetNextMove()
        {
            var hand = hands.First;
            return hand.Value.Score < 16 ? Move.HIT : Move.STAND;
        }

        public void TakeCard(BlackJackCard dealCard, bool isVisible) { }
    }
}
