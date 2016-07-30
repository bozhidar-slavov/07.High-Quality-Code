namespace Poker.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToString_ShouldReturn_CardFaceAndCardSuitCorrectly()
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

            foreach (var face in cardFaceList)
            {
                foreach (var suit in cardSuitList)
                {
                    var card = new Card(face, suit);
                    Assert.AreEqual(string.Format("{0} {1}", face, suit), card.ToString());
                }
            }
        }
    }
}
