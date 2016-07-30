namespace Poker
{
    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            var result = string.Format("{0} {1}", this.Face, this.Suit);
            return result;
        }
    }
}
