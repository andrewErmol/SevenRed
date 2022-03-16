using System.Collections.Generic;

namespace SevenRedLibrary
{
    public static class Service
    {
        /// <summary>
        /// Find Won deck
        /// </summary>
        /// <param name="WhiteDeck"></param>
        /// <param name="BlackDeck"></param>
        /// <returns>String Who won</returns>
        public static string FindWinner(List<Card> WhiteDeck, List<Card> BlackDeck)
        {
            if (HighCard(WhiteDeck).CompareTo(HighCard(BlackDeck)) == 1)
            {
                return $"Black deck won";
            }
            else if (HighCard(BlackDeck).CompareTo(HighCard(WhiteDeck)) == 1)
            {
                return $"White deck won";
            }
            else
            {
                return $"draw";
            }
        }

        /// <summary>
        /// Create List<card> for convert</card>
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>list objects of card</returns>
        public static List<Card> ConvertListStringToListCard(List<string> deck)
        {
            List<Card> Deck = new List<Card>();
            for (int i = 1; i < deck.Count; i++)
            {
                Deck.Add(new Card(deck[i]));
            }

            return Deck;
        }

        /// <summary>
        /// Find high card in ones deck
        /// </summary>
        /// <param name="SetOfCards"></param>
        /// <returns>Max card in deck</returns>
        private static Card HighCard(List<Card> SetOfCards)
        {
            Card max = SetOfCards[0];

            for (int i = 1; i < SetOfCards.Count; i++)
            {
                if (max.CompareTo(SetOfCards[i]) == 1)
                {
                    max = SetOfCards[i];
                }
            }

            return max;
        }         
    }
}
