using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            System.Console.WriteLine("Let's play a game with two Payers.");
            TryReadNrOfCards(out int NrOfCards);
            TryReadNrOfRounds(out int NrOfRounds);

            for (int i = 0; i < NrOfRounds; i++)
            {
                System.Console.WriteLine($"Playing round nr {i + 1}");
                System.Console.WriteLine("---------------------");
                if (myDeck.Count < NrOfCards * 2)
                {
                    System.Console.WriteLine("not enought cards left");
                    break;
                }
                Deal(myDeck, NrOfCards, player1, player2);
                System.Console.WriteLine($"Gave {NrOfCards} cards to a player from the top of the deck. Deck has now {myDeck.Count} cards\n");

                System.Console.WriteLine($"Player 1 hand with {player1.Count} cards.");
                myDeck.Sort();
                System.Console.WriteLine(player1);

                PlayingCard lowest = player1.Lowest;
                PlayingCard high = player1.Highest;
                System.Console.WriteLine($"Lowest card in hand is {lowest} highest is {high}");
                System.Console.WriteLine();

                System.Console.WriteLine($"Player 2 hand with {player2.Count} cards.");
                myDeck.Sort();
                System.Console.WriteLine(player2);


                PlayingCard lowest1 = player2.Lowest;
                PlayingCard high1 = player2.Highest;
                System.Console.WriteLine($"Lowest card in hand is {lowest1} highest is {high1}");
                System.Console.WriteLine();

                DetermineWinner(player1, player2);
                System.Console.WriteLine();

                player1.Clear();
                player2.Clear();

            }


            //Your code to play the game comes here
        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;
            while (true)
            {
                Console.WriteLine("How many cards to deal to each player (1-5 or q to quit)?");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quitting the game.");
                    Console.ForegroundColor = ConsoleColor.White;
                    NrOfCards = default;
                    Environment.Exit(0);
                }

                if (int.TryParse(input, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5)
                {
                    return true;
                }


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input, please try again! Choose a number between 1 and 5.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            while (true)
            {
                System.Console.WriteLine("How many rounds should we play (1-5 or Q to quit)?");
                string userinput = Console.ReadLine();

                if (userinput.Trim().ToLower() == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quitting the game.");
                    Console.ForegroundColor = ConsoleColor.White;
                    NrOfRounds = default;
                    return false;
                }

                if (int.TryParse(userinput, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input, please try again! Choose a number between 1 and 5.");
                Console.ForegroundColor = ConsoleColor.White;
            

            }
        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                if (myDeck.Count >= 2)
                {
                    player1.Add(myDeck.RemoveTopCard());
                    player2.Add(myDeck.RemoveTopCard());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Not enough card to deal");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
           
           if (player1.Highest.CompareTo(player2.Highest) > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Player 1 wins with card: " + player1.Highest);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Player 2 wins with card: " + player2.Highest);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
