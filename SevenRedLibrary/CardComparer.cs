using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenRedLibrary
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card card1, Card card2)
        {
            return card1.Nominal > card2.Nominal ? -1 : card1.Nominal < card2.Nominal ? 1 : card1.Color > card2.Color ? -1 : card1.Color < card2.Color ? 1 : 0;
        }
    }
}