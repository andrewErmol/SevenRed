using Microsoft.VisualStudio.TestTools.UnitTesting;
using SevenRedLibrary;
using System;
using System.Collections.Generic;

namespace UnitTestForSevenRed
{
    [TestClass]
    public class UnitTestsForSevenRed
    {
        [TestMethod]
        public void FindWinner_WhiteWon()
        {
            List<Card> WhiteDeck = new List<Card>() { new Card("7 R"), new Card("6 G"), new Card("2 p")};
            List<Card> BlackDeck = new List<Card>() { new Card("7 L"), new Card("2 g"), new Card("1 r") };

            string expected = "White deck won";

            Assert.AreEqual(expected, Service.FindWinner(WhiteDeck, BlackDeck));
        }

        [TestMethod]
        public void FindWinner_BlackWon()
        {
            List<Card> WhiteDeck = new List<Card>() { new Card("6 R"), new Card("6 G"), new Card("2 p") };
            List<Card> BlackDeck = new List<Card>() { new Card("7 L"), new Card("2 g"), new Card("1 r") };

            string expected = "Black deck won";

            Assert.AreEqual(expected, Service.FindWinner(WhiteDeck, BlackDeck));
        }

        [TestMethod]
        public void FindWinner_Draw()
        {
            List<Card> WhiteDeck = new List<Card>() { new Card("6 R"), new Card("6 G"), new Card("2 p") };
            List<Card> BlackDeck = new List<Card>() { new Card("5 L"), new Card("2 g"), new Card("6 r") };

            string expected = "draw";

            Assert.AreEqual(expected, Service.FindWinner(WhiteDeck, BlackDeck));
        }

        [TestMethod]
        public void ConvertListStringToListCardTest()
        {
            List<string> Deck = new List<string>() { "7", "7 r", "6 g" };
            
            List<Card> expected = new List<Card>() { new Card("7 R"), new Card("6 G") };

            Assert.AreEqual(expected[0], Service.ConvertListStringToListCard(Deck)[0]);
            Assert.AreEqual(expected[1], Service.ConvertListStringToListCard(Deck)[1]);
        }
    }
}
