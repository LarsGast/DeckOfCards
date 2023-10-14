namespace DeckOfCardsLibrary {
	public class Card {

		/// <summary>
		/// Card rank.
		/// Two is the lowest rank.
		/// Ace is the highest rank.
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
		/// Card suit.
		/// </summary>
		public enum Suit {
			Spades,
			Hearts,
			Diamonds,
			Clubs
		}

		/// <summary>
		/// Rank of the card.
		/// This includes "Two" until "Ten", and "Jack" until "Ace".
		/// </summary>
		public Rank rank { get; private set; }

		/// <summary>
		/// The suit of the card.
		/// This includes "Spades", "Hearts", "Diamonds", and "Clubs".
		/// </summary>
		public Suit suit { get; private set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="rank"></param>
		/// <param name="suit"></param>
		public Card(Rank rank, Suit suit) {
			this.rank = rank;
			this.suit = suit;
		}

		/// <summary>
		/// Checks whether the two cards are equal.
		/// Two cards are equal if they have the same rank and the same suit.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool equals(Card other) {
			return this.rank == other.rank && this.suit == other.suit;
		}

		/// <summary>
		/// Gets the display string for a card.
		/// This is a two character string (except for a card with rank 10).
		/// </summary>
		/// <returns></returns>
		public string getDisplayString(bool displayTenAsT = false) {
			return this.suit.getDisplayString() + this.rank.getDisplayString(displayTenAsT);
		}
	}
}