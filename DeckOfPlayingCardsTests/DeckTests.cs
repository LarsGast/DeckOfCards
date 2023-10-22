using NUnit.Framework;

namespace DeckOfPlayingCardsTests {
	[TestFixture]
	public class DeckTests {
		/// <summary>
		/// Tests if a new deck is created correctly with the specified initial set of cards.
		/// </summary>
		[Test]
		public void deckConstructor_ValidCards_CreatesDeck() {

			// Arrange
			var cards = new List<Card>
			{
				new Card(Card.Rank.Ace, Card.Suit.Spades),
				new Card(Card.Rank.King, Card.Suit.Hearts),
                // Add more cards as needed
            };

			// Act
			var deck = Deck.get(cards);

			// Assert
			CollectionAssert.AreEqual(cards, deck.cards);
		}

		/// <summary>
		/// Tests if a new deck is created correctly with the standard 52-card deck when no cards are provided.
		/// </summary>
		[Test]
		public void deckGet_NoCardsProvided_CreatesStandardDeck() {

			// Act
			var deck = Deck.get();

			// Assert
			Assert.That(deck.cards, Has.Count.EqualTo(52));
		}

		/// <summary>
		/// Tests if a deck is correctly shuffled.
		/// </summary>
		[Test]
		public void shuffleDeck_ShuffledDeckIsNotEqualToOriginalDeck() {

			// Arrange
			var deck = Deck.get();
			var originalCards = new List<Card>(deck.cards);

			// Act
			deck.shuffle();

			// Assert
			CollectionAssert.AreNotEqual(originalCards, deck.cards);
		}

		/// <summary>
		/// Tests if the deck can be shuffled without including drawn cards.
		/// </summary>
		[Test]
		public void shuffleDeckWithoutDrawnCards_ShuffledDeckExcludesDrawnCards() {

			// Arrange
			var deck = Deck.get();
			var drawnCards = new List<Card>();

			// Draw some cards.
			for (int i = 0; i < 10; i++) {
				drawnCards.Add(deck.draw()!);
			}

			var originalCards = new List<Card>(deck.cards);

			// Act
			deck.shuffle(includeDrawnCards: false);

			// Assert
			CollectionAssert.AreNotEqual(originalCards, deck.cards);
			CollectionAssert.AreEqual(drawnCards, deck.cards.Take(10));
		}

		/// <summary>
		/// Tests if drawing all the cards from the deck returns null when there are no more cards to draw.
		/// </summary>
		[Test]
		public void drawAllCards_NoMoreCardsToDraw_ReturnsNull() {

			// Arrange
			var deck = Deck.get();
			int totalCards = deck.cards.Count;

			// Draw all the cards.
			for (int i = 0; i < totalCards; i++) {
				deck.draw();
			}

			// Act
			var card = deck.draw();

			// Assert
			Assert.That(card, Is.Null);
		}
	}
}
