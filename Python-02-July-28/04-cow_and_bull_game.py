import random


def check_guess(guess: str, target: str) -> (int, int):
    """Check the guess against the target word and return the number of bulls and cows."""
    bulls = sum(g == t for g, t in zip(guess, target))
    cows = sum(min(guess.count(c), target.count(c))
               for c in set(guess)) - bulls
    return bulls, cows


def play_cow_and_bull_game(word_list: list, max_tries: int = 5):
    """Play the Cow and Bull game."""
    target_word = random.choice(word_list).lower()
    print(target_word)
    score = 100
    tries = max_tries

    print(f"You have {max_tries} guesses to guess the word:")

    while tries > 0:
        guess = input("Enter your guess: ").strip().lower()
        if len(guess) != len(target_word):
            print(f"Please enter a {len(target_word)}-letter word.")
            continue

        bulls, cows = check_guess(guess, target_word)
        print(f"Bulls: {bulls}, Cows: {cows}")

        if bulls == len(target_word):
            print(f"Congrats! You scored: {score}")
            return

        tries -= 1
        score -= 20

    print(f"Sorry, you lost! The word was: {target_word}")


if __name__ == "__main__":
    word_list = ["apple", "mango", "grape", "lemon", "kiwi",
                 "melon", "guava", "peach", "cherry", "banana"]
    play_cow_and_bull_game(word_list)
