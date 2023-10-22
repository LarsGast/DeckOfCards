using DeckOfPlayingCards;

namespace DeckOfPlayingCardsDemo {
	class Program {
		private static void Main(string[] args) {

			// Initialize some variables.
			Deck? deck = null;
			Card? card = null;
			bool shuffled = false;
			var drawnCards = new List<Card>();

			while (true) {
				// Clear the console so the user always sees the same screen.
				Console.Clear();

				// Show the deck, shuffled, and card status to the user.
				Program.showStatus(deck, shuffled, card);

				// Add a white space
				Console.WriteLine();

				// Show the options that the user has to the user.
				Program.showOptions();

				// Get the input of the user based on the options.
				var input = Console.ReadLine();

				// Check if we actually have an input.
				// If so, de-capitalize it.
				if (input == null) {
					Program.showMessage("No input received");
					continue;
				}
				else {
					input = input.ToLower();
				}

				// If the user wants to exit, let them exit.
				if (input == "e") {
					break;
				}

				// Handle the request based on the input of the user.
				Program.handleRequest(ref deck, ref card, ref shuffled, ref drawnCards, input);
			}
		}

		#region Console writeline methods

		/// <summary>
		/// Shows the status of the deck and the last drawn card.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="shuffled"></param>
		/// <param name="card"></param>
		private static void showStatus(Deck? deck, bool shuffled, Card? card) {
			if (deck == null) {
				Console.WriteLine("No deck found");
			}
			else {
				Console.WriteLine("Deck found");
				if (!shuffled) {
					Console.WriteLine("Deck is not shuffled");
				}
				else {
					Console.WriteLine("Deck is shuffled");
				}

				if (card != null) {
					Console.WriteLine($"Last card drawn: {card.getDisplayString(displayTenAsT: true)}");
				}
			}
		}

		/// <summary>
		/// Shows the user the options they have to continue.
		/// </summary>
		private static void showOptions() {
			Console.WriteLine("What would you like to do?");
			Console.WriteLine("G: Get a new (unsorted) deck");
			Console.WriteLine("S: Shuffle the deck");
			Console.WriteLine("D: Draw a card from the deck");
			Console.WriteLine("R: Reset the deck");
			Console.WriteLine("H: History. View all the drawn cards");
			Console.WriteLine("E: Exit (close the console)");
		}

		/// <summary>
		/// Shows a message to the user and halts the program until user interferance.
		/// </summary>
		/// <param name="message"></param>
		private static void showMessage(string message = "Error") {
			Console.Clear();
			Console.WriteLine(message);
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

		#endregion

		#region Logic methods

		/// <summary>
		/// Handles the request based on the input of the user.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="card"></param>
		/// <param name="shuffled"></param>
		/// <param name="drawnCards"></param>
		/// <param name="input"></param>
		private static void handleRequest(ref Deck? deck, ref Card? card, ref bool shuffled, ref List<Card> drawnCards, string? input) {
			if (input == "g") {
				Program.getDeck(out deck, ref shuffled);
			}
			else if (input == "s") {
				Program.shuffleDeck(deck, ref shuffled);
			}
			else if (input == "d") {
				Program.drawCard(deck, drawnCards, ref card);
			}
			else if (input == "r") {
				Program.resetDeck(deck, ref card, ref drawnCards);
			}
			else if (input == "h") {
				Program.showHistory(drawnCards);
			}
			else {
				Program.showMessage("Unknown input. Try again.");
			}
		}

		/// <summary>
		/// Gets a new deck and sets the shuffled status to false.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="shuffled"></param>
		private static void getDeck(out Deck? deck, ref bool shuffled) {
			deck = Deck.get();
			shuffled = false;
		}

		/// <summary>
		/// Shuffles the deck and sets the shuffled status to true.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="shuffled"></param>
		private static void shuffleDeck(Deck? deck, ref bool shuffled) {
			if (deck == null) {
				Program.showMessage("Deck not found");
				return;
			}

			deck.shuffle(includeDrawnCards: false);
			shuffled = true;
		}

		/// <summary>
		/// Draws a card from the deck and adds it to the drawnCards list.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="drawnCards"></param>
		/// <param name="card"></param>
		private static void drawCard(Deck? deck, List<Card> drawnCards, ref Card? card) {
			if (deck == null) {
				Program.showMessage("Deck not found");
				return;
			}

			card = deck.draw();
			if (card != null) {
				drawnCards.Add(card);
			}
		}

		/// <summary>
		/// Resets the deck.
		/// </summary>
		/// <param name="deck"></param>
		/// <param name="card"></param>
		/// <param name="drawnCards"></param>
		private static void resetDeck(Deck? deck, ref Card? card, ref List<Card> drawnCards) {
			if (deck == null) {
				Program.showMessage("Deck not found");
				return;
			}

			deck.reset();
			card = null;
			drawnCards = new List<Card>();

			Program.showMessage("Deck will be reset");
		}

		/// <summary>
		/// Shows all the cards drawn since last reset.
		/// </summary>
		/// <param name="drawnCards"></param>
		private static void showHistory(List<Card> drawnCards) {
			if (drawnCards.Count == 0) {
				Program.showMessage("No cards drawn");
				return;
			}

			Console.Clear();
			Console.WriteLine("History:");
			foreach (var drawnCard in drawnCards) {
				Console.WriteLine(drawnCard.getDisplayString(displayTenAsT: true));
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

		#endregion 
	}
}