using DeckOfCardsLibrary;

// Initialize some variables.
Deck? deck = null;
Card? card = null;
bool shuffled = false;
var drawnCards = new List<Card>();

while (true) {
	// Clear the console so the user always sees the same screen.
	Console.Clear();

	// Show the deck, shuffled, and card status to the user.
	showStatus(deck, shuffled, card);

	// Add a white space
	Console.WriteLine();

	// Show the options that the user has to the user.
	showOptions();
	
	// Get the input of the user based on the options.
	var input = Console.ReadLine();

	// Check if we actually have an input.
	// If so, de-capitalize it.
	if (input == null) {
		showMessage("No input received");
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
	handleRequest(ref deck, ref card, ref shuffled, ref drawnCards, input);
}

// Shows the status of the deck and the last drawn card.
static void showStatus(Deck? deck, bool shuffled, Card? card) {
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

// Shows a message to the user and halts the program until user interferance.
static void showMessage(string message = "Error") {
	Console.Clear();
	Console.WriteLine(message);
	Console.WriteLine("Press any key to continue");
	Console.ReadKey();
}

// Shows the user the options they have to continue.
static void showOptions() {
	Console.WriteLine("What would you like to do?");
	Console.WriteLine("G: Get a new (unsorted) deck");
	Console.WriteLine("S: Shuffle the deck");
	Console.WriteLine("D: Draw a card from the deck");
	Console.WriteLine("R: Reset the deck");
	Console.WriteLine("H: History. View all the drawn cards");
	Console.WriteLine("E: Exit (close the console)");
}

// Handles the request based on the input of the user.
static void handleRequest(ref Deck? deck, ref Card? card, ref bool shuffled, ref List<Card> drawnCards, string? input) {
	if (input == "g") {
		getDeck(out deck, ref shuffled);
	}
	else if (input == "s") {
		shuffleDeck(deck, ref shuffled);
	}
	else if (input == "d") {
		drawCard(deck, drawnCards, ref card);
	}
	else if (input == "r") {
		resetDeck(deck, ref card, ref drawnCards);
	}
	else if (input == "h") {
		showHistory(drawnCards);
	}
	else {
		showMessage("Unknown input. Try again.");
	}
}

// Gets a new deck and sets the shuffled status to false.
static void getDeck(out Deck? deck, ref bool shuffled) {
	deck = Deck.get();
	shuffled = false;
}

// Shuffles the deck and sets the shuffled status to true.
static void shuffleDeck(Deck? deck, ref bool shuffled) {
	if (deck == null) {
		showMessage("Deck not found");
		return;
	}

	deck.shuffle(includeDrawnCards: false);
	shuffled = true;
}

// Draws a card from the deck and adds it to the drawnCards list.
static void drawCard(Deck? deck, List<Card> drawnCards, ref Card? card) {
	if (deck == null) {
		showMessage("Deck not found");
		return;
	}

	card = deck.draw();
	if (card != null) {
		drawnCards.Add(card);
	}
}

// Resets the deck.
static void resetDeck(Deck? deck, ref Card? card, ref List<Card> drawnCards) {
	if (deck == null) {
		showMessage("Deck not found");
		return;
	}

	deck.reset();
	card = null;
	drawnCards = new List<Card>();

	showMessage("Deck will be reset");
}

// Shows all the cards drawn since last reset.
static void showHistory(List<Card> drawnCards) {
	if (drawnCards.Count == 0) {
		showMessage("No cards drawn");
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