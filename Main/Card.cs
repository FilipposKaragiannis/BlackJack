namespace Main
{
    public class Card
    {
        public FaceValue FaceValue;
        public bool      isAvailable;
        public Suit      Suit;

        protected Card(Suit suit, FaceValue faceValue1)
        {
            Suit        = suit;
            FaceValue   = faceValue1;
            isAvailable = true;
        }

        public virtual int Value => (int)FaceValue;

        public void MarkUnavailable()
        {
            isAvailable = false;
        }

        public override string ToString()
        {
            return $"{FaceValue.ToDisplayValue()} of {Suit}";
        }
    }

    public class BlackJackCard : Card
    {
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue) { }

        public override int Value
        {
            get
            {
                if(FaceValue == FaceValue.Ace)
                    return 1;

                if(FaceValue <= FaceValue.Ten)
                    return (int)FaceValue;

                return 10;
            }
        }

        public int  MinValue => Value;
        public int  MaxValue => IsAce ? 11 : Value;
        public bool IsAce    => FaceValue == FaceValue.Ace;
    }
}
