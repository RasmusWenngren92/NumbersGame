using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{
    internal class MethodsAndFunctions
    {
        private static int MaxNumber = 10;//Setting a default level for the game, declaring this outside the rest of the code so it can be reused and changed. 
        public static void LetTheGameBegin()//Method for the main game
        {

            bool newGame = true;
            while (newGame)
            {
  
                Random myRandom = new Random();
                int randomNumber = myRandom.Next(1, MaxNumber + 1);//setting the random number for the game
                int MaxGuesses = 5;
                int guesses = 0;
                Console.Clear();
                Console.WriteLine($"\tVälkommen! Jag tänker på ett nummer mellan 1 och {MaxNumber}." +
                        $"\n\tKan du gissa vilket? \n\tDu får {MaxGuesses} försök. Lycka till!");

                bool gameWon = false;

                // Main loop of the game, runs as long the user hasnt reached the max amount of guesses or managed to guess the right number. 
                while (guesses < MaxGuesses && !gameWon)
                {
                    
                    Console.WriteLine($"\n\tDetta är gissning nummer {guesses + 0} av {MaxGuesses}");//letting the user know how many guesses is left
              
                    int userNumber = UserGuess();//using a function to determit if the guess is valid input
                    guesses++;//counting the guesses
                    gameWon = CheckGuess(userNumber, randomNumber);//Sets gameWon to true and therefore breaks the while loop
                    Console.Clear();
                    if (!gameWon && guesses < MaxGuesses)//if the number is wrong and the amount of guesses is less then MaxGuesses this will call the GiveHint funktion.
                    {
                        GiveHint(userNumber, randomNumber);
                    }
                }
                
                //When game is over either one of this messages will be sent depending on if user has won or not
                if (gameWon)
                {
                    ShowWinMessage(guesses, MaxGuesses, randomNumber);

                }
                else
                {
                    ShowLoseMessage(randomNumber, MaxGuesses);

                }

                newGame = AskForNewGame();// This function will be shown after either message to let the user choose between playing again or returning to the main menu. 
                                          // Depending on the return value it will either loop again letting the player play again or setting the bool to false, thus ending the game. 

            }
        }
        //Checking users guess by compairing the input from UserGuess with the correct randomNumber, and returning the value. 
        private static bool CheckGuess(int userGuess, int randomNumber)
        {
            return userGuess == randomNumber;
        }
        //When game is won either one of this message will be shown for the user, 
        private static void ShowWinMessage(int guesses, int MaxGuesses, int randomNumber)
        {
            Console.Clear();
            
            string message = guesses == MaxGuesses//using the ternary conditional operator to determin witch message to send
                ? "\n\tWohoo! Du klarade det på sista försöket!"
                : $"\n\tWohoo! Du klarade det på försök {guesses} av {MaxGuesses}!";

            Console.WriteLine(message +
                              $"\n\tDen rätta siffran var {randomNumber}." );
        }
        //When loosing the game following message will be shown to the user
        private static void ShowLoseMessage(int randomNumber, int MaxGuesses)
        {
            Console.Clear();
            Console.WriteLine($"\n\tTyvärr! Du gissade fler gånger än {MaxGuesses}." +
                              $"\n\tDen rätta siffran var {randomNumber}." );
           
        }

        private static void GiveHint(int userNumber, int randomNumber)//the function used for giving the user a hint and also showing 
        {

            int correctNumber = randomNumber;
            int difference = Math.Abs(userNumber - correctNumber);//Using Math.Abs to see how close the guess is, since using Abs I will get an even number even if its base value is negative.
            
            
            if (difference <=2 )//Less or equal to 2
            {
                Console.WriteLine($"\n\tDu gissade på {userNumber}.\n\tNu bränns det verkligen!!");
            }
            else if(difference <=4 )//Less or equal to 4
            {
                Console.WriteLine($"\n\tDu gissade på {userNumber}.\n\tNu börjar det bli nära!");
            }
            else
            {
                Console.WriteLine($"\n\tDu gissade på {userNumber}.\n\tMen nära skjuter ingen hare! ");
            }
        }

        private static bool AskForNewGame()//the function for letting the player choose to play again, using a bool. 
        {
            while (true)
            {
                Console.WriteLine("\nVill du spela igen? (J/N)");
                string input = Console.ReadLine().ToUpper();
                
                if(input == "J")
                {
                    return true;//This option lets the player play again
                }
                if(input == "N")
                {
                    return false;//This option breaks the loop and sends the user back to the main menu
                }
                else
                {
                    Console.WriteLine("Du kan enbart svara J eller N.");
                }
            }
        }
        public static int UserGuess()//checking if number is a valid input and returning the guess

        {
            int UserGuess = 0;
            UserGuess = CheckUsersGuess(MaxNumber);

            return UserGuess;
        }
        public static int CheckUsersGuess(int MaxNumber)//Checking if the input number is in a valid range between 1 and MaxNumber
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (guess >= 1 && guess <= MaxNumber)//if the guess is between 1 and MaxNumber it will return the guess, otherwise it will ask the user for a valid input.
                    {
                        return guess;
                    }
                    Console.WriteLine($"Var snäll och skriv in en siffra mellan 1 och {MaxNumber}.");
                }
                else
                {
                    Console.WriteLine("Nu blev det tokigt! Skriv in en siffra tack.");
                }

            }
        }
        public static void Setting()//This is the method for settings
        {
            bool myBool = false;
            while (!myBool)
            {
                //Menu for setting
                Console.Clear();
                Console.WriteLine("Användarinställningar");
                Console.WriteLine("Välj svårighetsgrad!");
                Console.WriteLine("A Enkel  1-10");
                Console.WriteLine("B Medel  1-25");
                Console.WriteLine("C Svår   1-50");
                Console.WriteLine("D Välj själv hur många tal att gissa på!");
                Console.WriteLine("E Tillbaka till Meny");


                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "A":
                        Console.Clear();
                        MaxNumber = 10;//Sets the MaxNumber
                        Console.WriteLine("\t\nDu valde den enkla vägen.");
                        Thread.Sleep(2000);
                        LetTheGameBegin();//When choosen, it launches the game straight away
                        break;
                    case "B":
                        Console.Clear();
                        MaxNumber = 25;
                        Console.WriteLine("\t\nNu blir det lite svårare!");
                        Thread.Sleep(2000);
                        LetTheGameBegin();
                        break;
                    case "C":
                        Console.Clear();
                        MaxNumber = 50;
                        Console.WriteLine("\t\nÄr du verkligen säker på detta? Lycka till!");
                        Thread.Sleep(2000);
                        LetTheGameBegin();
                        break;
                    case "D":
                        Console.Clear();
                        Console.WriteLine("\t\nHur många tal vill du gissa på?");
                        int UserInput = CheckUserInput();//Letting the user choose MaxNumber, using CheckUserInput to validate input
                        MaxNumber = UserInput;//Declaring the number chossen as MaxNumber
                        LetTheGameBegin();
                        break;
                    case "E":
                        Console.Clear();
                        Console.WriteLine("\t\nTillbaka till menyn it is!");//Letting the user go back to the main menu
                        Thread.Sleep(2000);
                        myBool = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\t\nVerkar som om du skrev in något tokigt! Försök igen.");
                        Thread.Sleep(2000);
                        break;
                }
            }

        }
        public static int CheckUserInput()//Function for checking user input
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    return guess;
                }
                else
                {
                    Console.WriteLine("Var god skriv in en siffra!");
                }
            }
        }

    } 
}
