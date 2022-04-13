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
        public void CardsCombination_CreateCardList()
        {
            List<string> whiteDeck = new List<string>() { "1", "7 r", "6 p"};
            List<string> blackDeck = new List<string>() { "1", "1 r", "2 p" };
            Card expectedcardOfWhiteDeck = new Card("7 r");
            Card expectedcardOfBlackDeck = new Card("2 p");

            CardsCombination.ConvertListStringToListCard(whiteDeck, blackDeck);

            Assert.AreEqual(expectedcardOfWhiteDeck, CardsCombination.WhiteDeck[0]);
            Assert.AreEqual(expectedcardOfBlackDeck, CardsCombination.BlackDeck[1]);
        }

        [TestMethod]
        public void Card_Equals()
        {
            Card Card1 = new Card("7 r");
            Card Card2 = new Card("7 r");
            bool expected = true;

            Assert.AreEqual(expected, Card1.Equals(Card2));
        }

        [TestMethod]
        public void ServiceGetResult_WhiteWon()
        {
            List<string> whiteDeck = new List<string>() { "3", "7 R", "6 G", "2 p" };
            List<string> blackDeck = new List<string>() { "3", "7 L", "2 g", "1 r" };
            
            string expected = "White deck won";

            CardsCombination.ConvertListStringToListCard(whiteDeck, blackDeck);

            Assert.AreEqual(expected, Service.GetResult());
        }

        [TestMethod]
        public void ServiceGetResult_BlackWon()
        {
            List<string> whiteDeck = new List<string>() { "3", "6 R", "6 G", "2 p" };
            List<string> blackDeck = new List<string>() { "3", "7 L", "2 g", "1 r" };

            string expected = "Black deck won";

            CardsCombination.ConvertListStringToListCard(whiteDeck, blackDeck);

            Assert.AreEqual(expected, Service.GetResult());
        }

        [TestMethod]
        public void ServiceGetResult_draw()
        {
            List<string> whiteDeck = new List<string>() { "3", "7 R", "6 G", "2 p" };
            List<string> blackDeck = new List<string>() { "3", "7 R", "2 g", "1 r" };

            string expected = "draw";

            CardsCombination.ConvertListStringToListCard(whiteDeck, blackDeck);

            Assert.AreEqual(expected, Service.GetResult());
        }
    }
}
