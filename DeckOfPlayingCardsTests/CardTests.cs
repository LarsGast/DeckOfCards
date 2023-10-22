namespace DeckOfPlayingCardsTests {

	[TestFixture]
	public class CardTests {
		/// <summary>
		/// Tests if the Card constructor creates a card with the specified rank and suit.
		/// </summary>
		[Test]
		public void cardConstructor_ValidRankAndSuit_CreatesCard() {

			// Arrange
			var rank = Card.Rank.Ace;
			var suit = Card.Suit.Spades;

			// Act
			var card = new Card(rank, suit);

			// Assert
			Assert.Multiple(() => {
				Assert.That(card.rank, Is.EqualTo(rank));
				Assert.That(card.suit, Is.EqualTo(suit));
			});
		}

		/// <summary>
		/// Tests if the Card.equals() method returns true when comparing the same card.
		/// </summary>
		[Test]
		public void cardEquals_SameCard_ReturnsTrue() {

			// Arrange
			var card = new Card(Card.Rank.Ace, Card.Suit.Spades);

			// Act
			var result = card.equals(card);

			// Assert
			Assert.That(result, Is.True);
		}

		/// <summary>
		/// Tests if the Card.equals() method returns true when comparing different cards with the same rank and suit.
		/// </summary>
		[Test]
		public void cardEquals_DifferentCardsWithSameRankAndSuit_ReturnsTrue() {

			// Arrange
			var card1 = new Card(Card.Rank.Ace, Card.Suit.Spades);
			var card2 = new Card(Card.Rank.Ace, Card.Suit.Spades);

			// Act
			var result = card1.equals(card2);

			// Assert
			Assert.That(result, Is.True);
		}

		/// <summary>
		/// Tests if the Card.equals() method returns false when comparing different cards with different rank or suit.
		/// </summary>
		[Test]
		public void cardEquals_DifferentCardsWithDifferentRankOrSuit_ReturnsFalse() {

			// Arrange
			var card1 = new Card(Card.Rank.Ace, Card.Suit.Spades);
			var card2 = new Card(Card.Rank.King, Card.Suit.Hearts);

			// Act
			var result = card1.equals(card2);

			// Assert
			Assert.That(result, Is.False);
		}

		/// <summary>
		/// Tests if the Card.getDisplayString() method returns the correct string in default mode.
		/// </summary>
		[Test]
		public void getDisplayString_DefaultDisplay_ReturnsCorrectString() {

			// Arrange
			var card = new Card(Card.Rank.Two, Card.Suit.Spades);

			// Act
			var result = card.getDisplayString();

			// Assert
			Assert.That(result, Is.EqualTo("2♠"));
		}

		/// <summary>
		/// Tests if the Card.getDisplayString() method returns the correct string with "Ten" displayed as "T".
		/// </summary>
		[Test]
		public void getDisplayString_DisplayTenAsT_ReturnsCorrectString() {

			// Arrange
			var card = new Card(Card.Rank.Ten, Card.Suit.Spades);

			// Act
			var result = card.getDisplayString(displayTenAsT: true);

			// Assert
			Assert.That(result, Is.EqualTo("T♠"));
		}

		/// <summary>
		/// Tests if the Card.getDisplayString() method returns the correct string with "Ten" displayed as "10".
		/// </summary>
		[Test]
		public void getDisplayString_DisplayTenAsTen_ReturnsCorrectString() {

			// Arrange
			var card = new Card(Card.Rank.Ten, Card.Suit.Spades);

			// Act
			var result = card.getDisplayString(displayTenAsT: false);

			// Assert
			Assert.That(result, Is.EqualTo("10♠"));
		}
	}
}
