using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class BlackJackHand : Hand<BlackJackCard>
    {
        public override int Score
        {
            get
            {
                // we need to get the best score that's under 21
                var possibleScores = GetPossibleScores().OrderByDescending(s => s).ToArray();

                var minOver  = int.MaxValue;
                var maxUnder = int.MinValue;
                foreach(var s in possibleScores)
                    if(s > 21 && s < minOver)
                        minOver = s;
                    else if(s <= 21 && s > maxUnder)
                        maxUnder = s;

                return maxUnder == int.MinValue ? minOver : maxUnder;
            }
        }

        private IEnumerable<int> GetPossibleScores()
        {
            var scores = new List<int>() { 0 };

            if(cards.Count == 0)
                return scores;

            foreach(var c in cards)
                AddCardScore(c, scores);

            return scores;
        }

        private void AddCardScore(BlackJackCard card, List<int> scores)
        {
            var length = scores.Count;
            for(var i = 0; i < length; i++)
            {
                var score = scores[i];
                scores[i] = score + card.Value;
                if(card.IsAce)
                    scores.Add(card.MaxValue + score);
            }
        }

        public bool IsBusted()
        {
            return Score > 21;
        }

        public bool Is21()
        {
            return Score == 21;
        }


        public bool IsBlackJack()
        {
            return Score == 21 && cards.Count == 2;
        }
    }
}
