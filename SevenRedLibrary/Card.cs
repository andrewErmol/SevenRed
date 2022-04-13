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
            Nominal = SetNominal(card);
            Color = SetColor(card.ToUpper());
        }

        /// <summary>
        /// Get a nominal combination
        /// </summary>
        /// <param name="combination"></param>
        /// <returns>Nominal(int)</returns>
        /// <exception cref="Exception"></exception>
        private int SetNominal(string combination)
        {
            string[] splittedCombination = combination.Split(' ');

            if (Convert.ToInt32(splittedCombination[0]) <= 7 && Convert.ToInt32(splittedCombination[0]) > 0)
            {
                return Convert.ToInt32(splittedCombination[0]);
            }
            else
            {
                throw new Exception("The nominal for card must be no more than 7 and more then 0");
            }
        }

        /// <summary>
        /// Creates a color object depending on the entered value
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Color</returns>
        /// <exception cref="Exception"></exception>
        private Colors SetColor(string combination)
        {
            string[] splittedCombination = combination.Split(' ');
            string color = splittedCombination[1];

            switch (color)
            {
                case "R":
                    return Colors.Red;
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
            return Nominal > otherCard.Nominal ? -1 : Nominal < otherCard.Nominal ? 1 : Color > otherCard.Color ? -1 : Color < otherCard.Color ? 1 : 0;
        }

        /// <summary>
        /// Check objects to equalityS
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Nominal == card.Nominal &&
                   Color == card.Color;
        }

        public override int GetHashCode()
        {
            int hashCode = -160697517;
            hashCode = hashCode * -1521134295 + Nominal.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            return hashCode;
        }
    }
}
    