namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void ToString_ShouldReturn_CorrectCardHand()
        {
            var cardFaceList = new List<CardFace>()
            {
                CardFace.Two,
                CardFace.Three,
                CardFace.Four,
                CardFace.Five,
                CardFace.Six,
                CardFace.Seven,
                CardFace.Eight,
                CardFace.Nine,
                CardFace.Ten,
                CardFace.Jack,
                CardFace.Queen,
                CardFace.King,
                CardFace.Ace
            };

            var cardSuitList = new List<CardSuit>()
            {
                CardSuit.Clubs,
                CardSuit.Diamonds,
                CardSuit.Hearts,
                CardSuit.Spades
            };

            var cardHand = new List<ICard>();
            var getRandomValue = new Random();

            for (int i = 0; i < 10; i++)
            {
                var randomFace = cardFaceList[getRandomValue.Next(0, cardFaceList.Count - 1)];
                var randomSuit = cardSuitList[getRandomValue.Next(0, cardSuitList.Count - 1)];
                var randomCard = new Card(randomFace, randomSuit);

                if (!cardHand.Contains(randomCard))
                {
                    cardHand.Add(randomCard);
                }

                var cards = new Hand(cardHand);

                Assert.AreEqual(string.Join(", ", cardHand), cards.ToString());
            }
        }
    }
}
