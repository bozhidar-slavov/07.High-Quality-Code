namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            var handCards = hand.Cards;
            for (var i = 0; i < handCards.Count - 1; i++)
            {
                var currCard = handCards[i];
                var nextCard = handCards[i + 1];
                if (currCard.ToString() == nextCard.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) != 4)
            {
                return false;
            }

            return true;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var flushCardSuit = hand.Cards[0].Suit;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Suit != flushCardSuit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private int MaxNumberOfSameCards(IHand hand)
        {
            int result = 1;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var typeOfCardToCheck = hand.Cards[i];
                int numberOfSuchCardsInTheHand = hand.Cards.Where(x => x.Face == typeOfCardToCheck.Face).Count();

                if (numberOfSuchCardsInTheHand > result)
                {
                    result = numberOfSuchCardsInTheHand;
                }
            }

            return result;
        }
    }
}
