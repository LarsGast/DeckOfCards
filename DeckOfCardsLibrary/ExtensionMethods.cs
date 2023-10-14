using static DeckOfCardsLibrary.Card;

namespace DeckOfCardsLibrary {
	public static class ExtensionMethods {

		/// <summary>
		/// Extension method.
		/// Gets the value of the rank as a string for displaying.
		/// </summary>
		/// <param name="rank"></param>
		/// <returns></returns>
		public static string getDisplayString(this Rank rank) {
			switch (rank) {
				case Rank.Jack:
					return "J";
				case Rank.Queen:
					return "Q";
				case Rank.King:
					return "K";
				case Rank.Ace:
					return "A";
				default:
					return ((int)rank).ToString();
			}
		}

		/// <summary>
		/// Extension method.
		/// Gets the unicode value of the suit as a string for displaying.
		/// </summary>
		/// <param name="suit"></param>
		/// <returns></returns>
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
