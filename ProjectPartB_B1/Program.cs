using System;

namespace ProjectPartB_B1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            /*Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();*/
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            //Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            //Your code to play the game comes here
            if(!TryReadNrOfRounds(out int NrOfRounds))
            {
                return;
            }
            
            if(!TryReadNrOfCards(out int NrOfCards))
            {
                return;
            }
            Console.Clear();
            
            for(int i = 0; i < NrOfRounds; i++)
            {
                Deal(myDeck, NrOfCards, player1, player2, i);
            }
            Console.WriteLine(DetermineWinner(player1, player2));
            

        }

        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            do 
            {
                Console.Write("How many rounds do you want to play? ");
                string input = Console.ReadLine();
                
                if(input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("It seems like you decided to quit the game. Good Bye");
                    return false;
                }
                if (int.TryParse(input, out NrOfRounds))
                {
                     
                    if (NrOfRounds > 0 && NrOfRounds <= 5)
                    {
                        return true; 
                    }
                   
                    else
                    {
                        Console.WriteLine("That is not an number, that we can accept");
                    }
                }
    
                else
                {
                    Console.WriteLine("That is not an number, please try again");
                }

            }
            while (true);
            
        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;
    
            do
            {
                Console.Write("How many cards to each player do you want to play with? ");
                string input = Console.ReadLine();

                if(input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("It seems like you decided to quit the game. Good Bye");
                    return false;
                }

                if (int.TryParse(input, out NrOfCards))
                {
                    if (NrOfCards >0 && NrOfCards <=5)
                    {
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("That is not an number, that we can accept");
                    }
                    
                }
                else
                {
                    Console.WriteLine("That is not an number, please try again");
                }
            }
            while (true);

        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int NrOfCards, HandOfCards player1, HandOfCards player2, int currentRound)
        { 
             for (int i = 0; i < NrOfCards; i++)
            {
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }
            
            Console.WriteLine($"------------------ Round {currentRound+1} ----------------------\n");

            // Display Player 1's hand
            Console.WriteLine("Player 1's Hand:");
            Console.WriteLine(string.Join(" ", player1.Hand));
            Console.WriteLine($"Highest Card: {player1.Highest}, Lowest Card: {player1.Lowest}\n");

            // Display Player 2's hand
            Console.WriteLine("Player 2's Hand:");
            Console.WriteLine(string.Join(" ", player2.Hand));
            Console.WriteLine($"Highest Card: {player2.Highest}, Lowest Card: {player2.Lowest}\n");

            Console.WriteLine($"The deck has now {myDeck.Count} cards");

            // Compare highest cards
            int comparison = player1.Highest.Value.CompareTo(player2.Highest.Value);
            string result;

            switch (comparison)
            {
                case > 0:
                    result = "Player 1 wins this round!";
                    player1.Score(); // Increment Player 1's score
                    break;
                case < 0:
                    result = "Player 2 wins this round!";
                    player2.Score(); // Increment Player 2's score
                    break;
                default:
                    result = "It's a tie!";
                    break;
            }

            // Display the deck's remaining card count and the result
            Console.WriteLine($"Remaining Cards in Deck: {myDeck.Count}");
            Console.WriteLine($"Result: {result}\n");

        
        }
        
        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static string DetermineWinner(HandOfCards player1, HandOfCards player2)
        { 
            Console.WriteLine($"--------------- Ultimate Winner -------------------\n");
            int comparison = player1.score.CompareTo(player2.score);
            string result;

            switch (comparison)
            {
                case > 0:
                    result = "Player 1 wins the game!";
                    break;
                case < 0:
                    result = "Player 2 wins the game!";
                    break;
                default:
                    result = "It's a tie!";
                    break;
            }
            
            return result;


        }
    }
}
