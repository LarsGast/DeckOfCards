namespace DeckOfPlayingCards {

	/// <summary>
	/// Represents a playing card with a rank and suit.
	/// </summary>
	public class Card {

		/// <summary>
		/// Enumeration of card ranks, ranging from Two to Ace.
		/// </summary>
		public enum Rank {
			Two = 2,
			Three,
			Four,
			Five,
			Six,
			Seven,
			Eight,
			Nine,
			Ten,
			Jack,
			Queen,
			King,
			Ace
		}

		/// <summary>
		/// Enumeration of card suits, including Spades, Hearts, Diamonds, and Clubs.
		/// </summary>
		public enum Suit {
			Spades,
			Hearts,
			Diamonds,
			Clubs
		}

		/// <summary>
		/// Gets or sets the rank of the card.
		/// Ranks range from "Two" to "Ten," and "Jack" to "Ace."
		/// </summary>
		public Rank rank { get; private set; }

		/// <summary>
		/// Gets or sets the suit of the card.
		/// Suits include "Spades," "Hearts," "Diamonds," and "Clubs."
		/// </summary>
		public Suit suit { get; private set; }

		/// <summary>
		/// Initializes a new instance of the Card class with the specified rank and suit.
		/// </summary>
		/// <param name="rank">The rank of the card.</param>
		/// <param name="suit">The suit of the card.</param>
		public Card(Rank rank, Suit suit) {
			this.rank = rank;
			this.suit = suit;
		}

		/// <summary>
		/// Checks whether this card is equal to another card.
		/// Two cards are equal if they have the same rank and the same suit.
		/// </summary>
		/// <param name="other">The other card to compare.</param>
		/// <returns>true if the cards are equal; otherwise, false.</returns>
		public bool equals(Card other) {
			return this.rank == other.rank && this.suit == other.suit;
		}

		/// <summary>
		/// Gets the display string for the card, representing both rank and suit.
		/// This is a two-character string (except for a card with rank 10, if displayTenAsT is false).
		/// </summary>
		/// <param name="displayTenAsT">Whether the rank "Ten" should be displayed as "T". Default is false (displays "10").</param>
		/// <returns>A string representing the card, e.g., "2♠" for the 2 of Spades.</returns>
		public string getDisplayString(bool displayTenAsT = false) {
			return this.suit.getDisplayString() + this.rank.getDisplayString(displayTenAsT);
		}
	}
}