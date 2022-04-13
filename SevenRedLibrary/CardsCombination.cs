using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenRedLibrary
{
    public static class CardsCombination
    {
        public static List<Card> WhiteDeck { get; }
        public static List<Card> BlackDeck { get; }

        static CardsCombination()
        {
            WhiteDeck = new List<Card>(7);
            BlackDeck = new List<Card>(7);
        }

        /// <summary>
        /// Find high card in ones deck
        /// </summary>
        /// <param name="SetOfCards"></param>
        /// <returns>Max card in deck</returns>
        internal static Card GetHigherCard(List<Card> setOfCards)
        {
            Array.Sort(setOfCards.ToArray(), new CardComparer());
            return setOfCards[0];

            /*Card max = setOfCards[0];


            for (int i = 1; i < setOfCards.Count; i++)
            {
                if (max.CompareTo(setOfCards[i]) == 1)
                {
                    max = setOfCards[i];
                }
            }

            return max;*/
        }


        /// <summary>
        /// Create List<card> for convert</card>
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>list objects of card</returns>
        public static void ConvertListStringToListCard(List<string> whiteDeck, List<string> blackDeck)
        {
            WhiteDeck.Clear();
            BlackDeck.Clear();

            for (int i = 1; i < whiteDeck.Count; i++) WhiteDeck.Add(new Card(whiteDeck[i]));
            for (int i = 1; i < blackDeck.Count; i++) BlackDeck.Add(new Card(blackDeck[i]));
        }
    }
}
