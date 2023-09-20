using DeckOfCardsLibrary;

Deck? deck = null;
Card? card = null;
bool shuffled = false;
var drawnCards = new List<Card>();

while (true) {
	Console.Clear();

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
			Console.WriteLine($"Last card drawn: {card.rank} of {card.suit}");
		}
	}

	Console.WriteLine();

	Console.WriteLine("What would you like to do?");
	Console.WriteLine("G: Get a new (unsorted) deck");
	Console.WriteLine("S: Shuffle the deck");
	Console.WriteLine("D: Draw a card from the deck");
	Console.WriteLine("R: Reset the deck");
	Console.WriteLine("H: History. View all the drawn cards");
	Console.WriteLine("E: Exit (close the console)");

	var input = Console.ReadLine();

	if (input == "G") {
		deck = Deck.get();
		shuffled = false;
	}
	else if (input == "S") {
		if (deck == null) {
			Console.Clear();
			Console.WriteLine("Deck not found");
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			continue;
		}
		deck.shuffle(includeDrawnCards: false);
		shuffled = true;
	}
	else if (input == "D") {
		if (deck == null) {
			Console.Clear();
			Console.WriteLine("Deck not found");
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			continue;
		}
		card = deck.draw();
		if (card != null) {
			drawnCards.Add(card);
		}
	}
	else if (input == "R") {

		Console.Clear();

		if (deck == null) {
			Console.WriteLine("Deck not found");
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			continue;
		}

		deck.reset();
		card = null;
		drawnCards = new List<Card>();

		Console.WriteLine("Deck will be reset");
		Console.WriteLine("Press any key to continue");
		Console.ReadKey();
	}
	else if (input == "H") {
		Console.Clear();

		if (drawnCards.Count == 0) {
			Console.WriteLine("No cards drawn");
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			continue;
		}

		Console.WriteLine("History:");
		foreach (var drawnCard in drawnCards) {
			Console.WriteLine($"{drawnCard.rank} of {drawnCard.suit}");
		}

		Console.WriteLine();
		Console.WriteLine("Press any key to continue");
		Console.ReadKey();
	}
	else if (input == "E") {
		break;
	}
	else {
		Console.Clear();
		Console.WriteLine("Unknown input. Try again.");
		Console.WriteLine("Press any key to continue");
		Console.ReadKey();
	}
}