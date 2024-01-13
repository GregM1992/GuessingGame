


using System.Runtime.InteropServices;

int userGuess = 0;
List<int> userGuesses = new();
Random random = new Random();
int secretNumber = random.Next(1, 101);
int difficulty = 0;
int cheaterDifficulty = int.MaxValue;



int CalculateRemainingGuesses(int guesses)
{
    int remainingGuesses = 0;
    if (guesses < difficulty)
    {
        remainingGuesses = difficulty - guesses;
    }
    return remainingGuesses;
}

string TooHighTooLow(int guess, int secretNum)
{
    string result = null;
    if (guess > secretNum)
    {
        result = "too high";
    }
    else if (guess < secretNum)
    {
        result = "too low";
    }
    return result;
}

void PromptForDifficulty()
{

    Console.WriteLine("Please choose your difficulty level: (1 - 3)\n" +
        @"1. Easy (8 guesses)
2. Medium (6 guesses)
3. Hard (4 guesses)
4. Cheater (keep going till you win or give up)");
    int difficultySelected = Convert.ToInt32(Console.ReadLine());

    switch (difficultySelected)
    {
        case 1:

            Console.WriteLine("You're a lil scared baby huh? Thats alright.");
            difficulty = 8;
            break;

        case 2:

            Console.WriteLine("You can probably get this.....maybe");
            difficulty = 6;
            break;

        case 3:

            Console.WriteLine("A bit confident are we? Goodluck.");
            difficulty = 4;
            break;
        case 4:

            Console.WriteLine("Oh brother, we're gonna be here a while arent we?");
            difficulty = cheaterDifficulty;
            break;

        default:
            Console.WriteLine("That isnt an option dingus.");
            PromptForDifficulty();
            break;

    }

}



void PromptUserForGuess()
{
    Console.WriteLine("Please guess the secret number.\n");

    userGuess = Convert.ToInt32(Console.ReadLine());

    if (userGuess == secretNumber)
    {
        Console.WriteLine("Congratulations! You guessed correctly!\n");
    }
    else
    {
        if (difficulty == cheaterDifficulty)
        {
            Console.WriteLine($"Sorry your guess was incorrect.\n\nYour guess was ({userGuess}). Which is {TooHighTooLow(userGuess, secretNumber)}.\n");
            PromptUserForGuess();
        }
        else
        {
            Console.WriteLine($"Sorry your guess was incorrect.\n\nYour guess was ({userGuess}). Which is {TooHighTooLow(userGuess, secretNumber)}.You have {CalculateRemainingGuesses(userGuesses.Count) - 1} guesses left.");
            userGuesses.Add(userGuess);
            if (userGuesses.Count >= difficulty)
            {
                Console.WriteLine("\nThat was your last chance sorry.\n");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nTry Again!\n");
                Console.WriteLine();
                PromptUserForGuess();
            };

        }
    }

}
PromptForDifficulty();
PromptUserForGuess();
