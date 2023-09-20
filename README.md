# Deck of cards

[GitHub repo](https://github.com/LarsGast/DeckOfCards)

## Table of Contents

- [About](#about)
- [Features](#features)
- [Usage](#usage)
- [Contributing](#contributing)

## About

This library can be used to create card games such as poker or blackjack. With this library, you can create a standard deck of 52 cards, shuffle it, and draw cards. You can also reset the deck if you want to run it again.

## Features

This package includes the following classes:
* Card.cs
* Deck.cs

The Card.cs class is a simple class for storing the rank and the suit of the card.
The Deck.cs class contains a list of cards as a property. It also includes the following methods:
* get()
	* Gets a standards deck of 52 cards, not shuffled.
* shuffle()
	* Shuffles the deck.
	* Includes a parameter to specify whether the already drawn cards should be shuffled back into the deck.
	* A Random variable can be passed in. If not, a Random variable is initialized.
* draw()
	* Draws a card from the deck.
	* Returns the drawn card
* reset()
	* Resets the deck, meaning all drawn cards will be put back onto the deck in the same order as they were originally.

The draw() method doesn't remove a card from the deck, it simply returns the card at the current index and moves the index up by 1. This is how already drawn cards can be put back into the deck in the same order.

For the source code, check out the GitHub repo.

## Usage

Getting a deck, shuffling it, and drawing cards is pretty straightforward. See the code snippet below.

```csharp
// Get an unshuffled deck.
var deck = Deck.get();

// Shuffle the deck.
deck.shuffle();

// Draw some cards.
var firstCard = deck.draw();
var secondCard = deck.draw();

// That was a good hand! Let's reset the deck so I get the same cards again.
deck.reset();
```

The GitHub repo also includes a console app which you can play around with.

## Contributing and Feedback

If you have questions, concerns, or would like to contribute to this project, there are several ways to get involved:

- **Open an Issue**: If you encounter a bug, have a feature request, or want to discuss improvements, please [open an issue](https://github.com/LarsGast/DeckOfCards/issues).

- **Start a Discussion**: You can also initiate a discussion in the [Discussions](https://github.com/LarsGast/DeckOfCards/discussions) section of this repository to share ideas or seek help.

- **Fork and Contribute**: If you'd like to make changes or enhancements to the project, fork the repository and submit a pull request with your proposed changes.

Your contributions and feedback are highly valued and essential to the improvement of this project. Thank you for your support!
