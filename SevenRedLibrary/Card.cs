using System;
using System.Text.RegularExpressions;

namespace SevenRedLibrary
{
    /// <summary>
    /// Class contains object type card
    /// </summary>
    public class Card : IComparable<Card>
    {
        public int Nominal { get; }
        public Colors Color { get; }
        private string[] Combination { get; }
        private const int NominalIndex = 0;
        private const int ColorIndex = 1;

        /// <summary>
        /// Constructor Without parametrs
        /// </summary>
        public Card() { }

        /// <summary>
        /// Constructor for class Card
        /// </summary>
        /// <param name="card"></param>
        public Card(string card)
        {
            Combination = ParsCombination(card);
            Nominal = Convert.ToInt32(Combination[NominalIndex]);
            Color = SetColor(Combination[ColorIndex].ToUpper());
        }

        /// <summary>
        /// Check entered value of correct format
        /// </summary>
        /// <param name="combination"></param>
        /// <returns>Array of string type with nominal and color</returns>
        /// <exception cref="Exception"></exception>
        private string[] ParsCombination(string combination)
        {
            Regex correctFormat = new Regex(@"\d{1}\s{1}\w{1}");
            Match correctFormatMatch = correctFormat.Match(combination);

            if (!correctFormatMatch.Success)
            {
                throw new Exception("Incorect format data for card");
            }

            string[] splittedCombination = combination.Split(' ');

            if (Convert.ToInt32(splittedCombination[0]) <= 7)
            {
                return splittedCombination;
            }
            else
            {
                throw new Exception("The nominal for card must be no more than 7");
            }
        }

        /// <summary>
        /// Creates a color object depending on the entered value
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Color</returns>
        /// <exception cref="Exception"></exception>
        private Colors SetColor(string color)
        {
            switch (color)
            {
                case "R":
                    return Colors.Red;
                    break;
                case "O":
                    return Colors.Orange;
                    break;
                case "Y":
                    return Colors.Yellow;
                    break;
                case "G":
                    return Colors.Green;
                    break;
                case "L":
                    return Colors.LightBlue;
                    break;
                case "B":
                    return Colors.Blue;
                    break;
                case "P":
                    return Colors.Purple;
                    break;
                default:
                    throw new Exception("In SevenRed haven't this color");
            }
        }

        /// <summary>
        /// Comparison of objects
        /// </summary>
        /// <param name="otherCard"></param>
        /// <returns></returns>
        public int CompareTo(Card otherCard)
        {
            if (Nominal > otherCard.Nominal)
                return -1;
            else if (Nominal < otherCard.Nominal)
                return 1;
            else
            {
                if (Color > otherCard.Color)
                    return -1;
                else if (Color < otherCard.Color)
                    return 1;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Check objects to equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Nominal == card.Nominal &&
                   Color == card.Color;
        }
    }
}
    