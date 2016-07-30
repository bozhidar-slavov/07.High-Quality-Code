namespace Poker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        private PokerHandsChecker testChecker = new PokerHandsChecker();

        // IsValidHand() tests
        [TestMethod]
        public void ValidHand_MustConsist_FiveDifferentCards()
        {
            var validHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });
            
            Assert.IsTrue(this.testChecker.IsValidHand(validHand));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenLessThanFiveCardsIsPassed()
        {
            var invalidHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts)
            });

            Assert.IsFalse(this.testChecker.IsValidHand(invalidHand));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenMoreThanFiveCardsIsPassed()
        {
            var invalidHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            });

            Assert.IsFalse(this.testChecker.IsValidHand(invalidHand));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenHandWithTwoOrMoreSameCardsIsPassed()
        {
            var invalidHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
            });

            Assert.IsFalse(this.testChecker.IsValidHand(invalidHand));
        }

        //IsFlush() tests
        [TestMethod]
        public void IsFlush_MustContains_FiveCardsFromOneSuit()
        {
            var flushHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            Assert.IsTrue(this.testChecker.IsFlush(flushHand));
        }

        [TestMethod]
        public void IsFlush_ShouldReturnFalse_WhenOneOrMoreCardsIsNotFromTheSameSuit()
        {
            var nonFlushHand = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            Assert.IsFalse(this.testChecker.IsFlush(nonFlushHand));
        }

        //IsFourOfAKind() tests
        [TestMethod]
        public void IsFourOfAKind_ShouldReturnFalse_WhenNonFourOfAKindIsPassed()
        {
            var nonFourOfAKind = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            Assert.IsFalse(this.testChecker.IsFourOfAKind(nonFourOfAKind));
        }

        [TestMethod]
        public void IsFourOfAKind_ShouldReturnTrue_WhenFourOfAKindIsPassed()
        {
            var fourOfAKind = new Hand(new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            Assert.IsTrue(this.testChecker.IsFourOfAKind(fourOfAKind));
        }
    }
}
