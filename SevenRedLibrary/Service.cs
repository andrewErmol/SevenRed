using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenRedLibrary
{
    public static class Service
    {        
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

        public static List<Card> ConvertListStringToListCard(List<string> deck)
        {
            List<Card> Deck = new List<Card>();
            for (int i = 1; i < deck.Count; i++)
            {
                Deck.Add(new Card(deck[i]));
            }

            return Deck;
        }


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
