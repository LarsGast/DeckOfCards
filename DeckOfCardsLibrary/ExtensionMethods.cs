using static DeckOfCardsLibrary.Card;

namespace DeckOfCardsLibrary {
	public static class ExtensionMethods {

		/// <summary>
		/// Extension method.
		/// Gets the value of the rank as a string for displaying.
		/// </summary>
		/// <param name="rank"></param>
		/// <param name="displayTenAsT">Wether the rank "Ten" should be displayed as "T" or "10"</param>
		/// <returns>A one or two character string that represents the value of the rank</returns>
		public static string getDisplayString(this Rank rank, bool displayTenAsT = false) {
			switch (rank) {
				case Rank.Ten:
					if (displayTenAsT) {
						return "T";
					}
					break;
				case Rank.Jack:
					return "J";
				case Rank.Queen:
					return "Q";
				case Rank.King:
					return "K";
				case Rank.Ace:
					return "A";
			}

			return ((int)rank).ToString();
		}

		/// <summary>
		/// Extension method.
		/// Gets the unicode value of the suit as a string for displaying.
		/// </summary>
		/// <param name="suit"></param>
		/// <returns>A one character unicode string that represents the value of the suit</returns>
		public static string? getDisplayString(this Suit suit) {
			switch (suit) {
				case Suit.Hearts:
					return "\u2665";
				case Suit.Spades:
					return "\u2660";
				case Suit.Diamonds:
					return "\u2666";
				case Suit.Clubs:
					return "\u2663";
				default:
					throw new ArgumentException("Undefined suit value");
			}
		}
	}
}
