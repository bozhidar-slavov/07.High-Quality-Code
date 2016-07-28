namespace Santase.Tests
{
    using System;

    using NUnit.Framework;

    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        private const int DeckSize = 24;

        [Test]
        public void NewDeckShouldContains24Cards()
        {
            var deck = new Deck();
            Assert.AreEqual(DeckTests.DeckSize, deck.CardsLeft);
        }

        [Test]
        public void IsTrumpCardValid()
        {
            var deck = new Deck();
            Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), deck.GetTrumpCard.Suit));
            Assert.IsTrue(Enum.IsDefined(typeof(CardType), deck.GetTrumpCard.Type));
        }

        [Test]
        public void ChangeTrumpCardValid()
        {
            var deck = new Deck();
            var card = new Card(CardSuit.Heart, CardType.Ace);
            deck.ChangeTrumpCard(card);
            Assert.AreEqual(card, deck.GetTrumpCard);
        }

        [Test]
        public void GetNextCardShouldRemoveCardFromTheDeck()
        {
            var deck = new Deck();
            int getCurrentCardsNumber = deck.CardsLeft;
            deck.GetNextCard();
            Assert.AreEqual(getCurrentCardsNumber - 1, deck.CardsLeft);
        }

        [Test]
        public void GetNextCardShouldThrowExceptionWhenThereAreNoCardsLeft()
        {
            var deck = new Deck();
            for (int i = 0; i < DeckTests.DeckSize; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [TestCase(5, 19)]
        public void CardsLeftShouldReturnCorrectValue(int getNextCardLength, int expectedCardsLeft)
        {
            var deck = new Deck();
            for (int i = 0; i < getNextCardLength; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(expectedCardsLeft, deck.CardsLeft);
        }
    }
}
