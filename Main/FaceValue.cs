using System;

namespace Main
{
    public enum FaceValue
    {
        Ace   = 1,
        Two   = 2,
        Three = 3,
        Four  = 4,
        Five  = 5,
        Six   = 6,
        Seven = 7,
        Eight = 8,
        Nine  = 9,
        Ten   = 10,
        Jack  = 11,
        Queen = 12,
        King  = 13
    }

    public static class FaceValueExtensions
    {
        public static string ToDisplayValue(this FaceValue v)
        {
            switch(v)
            {
                case FaceValue.Ace: return "A";
                case FaceValue.Two:
                case FaceValue.Three:
                case FaceValue.Four:
                case FaceValue.Five:
                case FaceValue.Six:
                case FaceValue.Seven:
                case FaceValue.Eight:
                case FaceValue.Nine:
                case FaceValue.Ten:
                    return ((int)v).ToString();
                case FaceValue.Jack:  return "J";
                case FaceValue.Queen: return "Q";
                case FaceValue.King:  return "K";
                default:
                    Console.WriteLine($"Unrecognised faceValue ({v}).");
                    return string.Empty;
            }
        }
    }
}
