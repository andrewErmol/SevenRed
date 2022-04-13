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
        private static string FindWinner()
        {
            if (CardsCombination.GetHigherCard(CardsCombination.WhiteDeck).CompareTo(CardsCombination.GetHigherCard(CardsCombination.BlackDeck)) == 1)
            {
                return $"Black deck won";
            }
            else if (CardsCombination.GetHigherCard(CardsCombination.BlackDeck).CompareTo(CardsCombination.GetHigherCard(CardsCombination.WhiteDeck)) == 1)
            {
                return $"White deck won";
            }
            else
            {
                return $"draw";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetResult()
        {
            if (CardsCombination.WhiteDeck.Count != 0 && CardsCombination.BlackDeck.Count != 0)
                return FindWinner();
            else if (CardsCombination.BlackDeck.Count == 0 && CardsCombination.WhiteDeck.Count == 0)
                return "Enter cards";
            else if (CardsCombination.WhiteDeck.Count == 0 && CardsCombination.BlackDeck.Count != 0)
                return "Black deck won";
            else
                return "White deck won";
        }
    }
}
