using System.ComponentModel;
using System.ComponentModel.Design;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
            {
            // Programmer:  Rasmus Wenngren
            // Program:     Fullstack .NET 2024
            // Course:      Programmering med C# och .NET
            // Lab 3:       NumbersGame

            // A bool for keeping the app up and running
            bool endGame = false;
            while (!endGame)
                {
                Console.Clear();
                PrintMenu();//calling the PrintMenu function.
                Console.WriteLine("");
                string menu = Console.ReadLine().ToUpper();
                Console.Clear();
                //switch for setting up the menu woth various options
                switch (menu)
                {
                    
                    case "A":
                        MethodsAndFunctions.LetTheGameBegin();//Calling the method for starting the game
                        break;
                    case "B":
                        MethodsAndFunctions.Setting();//Calling the method for changing the setting
                        break;
                    case "C":
                        Console.Clear();
                        Console.WriteLine("\t\nTack för att du ville vara med och spela! Välkommen åter!");
                        Thread.Sleep(2000);
                        endGame = true;
                        break;

                    default://default message for letting the user know that they need to type a valid input
                        Console.WriteLine("Var god och välj från menyn.");
                        Thread.Sleep(2000);
                        break;
                       
                }
              
            }

        }

        static void PrintMenu()//the function for printing out the menu
        {

            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("[A]Spela Spelet" +
                            "\n[B]Inställningar" +
                            "\n[C]Avsluta Spelet");

        }
    }
}
