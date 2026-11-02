using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_6_Mini_Summative_Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "Dice Casino Game";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================================");
            Console.WriteLine("       WELCOME TO DICE CASINO");
            Console.WriteLine("==================================");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("You will start with $100.");
            Console.WriteLine("Choose an outcome and place your bet.");
            Console.WriteLine("If you guess correctly, you win money!");
            Console.WriteLine();

            Console.WriteLine("Press ENTER to start...");
            Console.ReadLine();
            Console.Clear();

            // Create two dice
            Die die1 = new Die();
            Die die2 = new Die();

            // Starting balance
            double balance = 100;

            // Game loop
            bool done = false;

            while (!done)
            {
                Console.Clear();

                // Check if the player has run out of money
                if (balance <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have run out of money!");
                    Console.WriteLine("GAME OVER!");
                    Console.ResetColor();

                    done = true;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("========== DICE CASINO ==========");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("Current Balance: $" + balance.ToString("F2"));
                Console.WriteLine();

                // Betting choices
                Console.WriteLine("What would you like to bet on?");
                Console.WriteLine();

                Console.WriteLine("1. Doubles - Win double your bet (2x)");
                Console.WriteLine("2. Not Doubles - Win half your bet (0.5x)");
                Console.WriteLine("3. Even Sum - Win your bet (1x)");
                Console.WriteLine("4. Odd Sum - Win your bet (1x)");
                Console.WriteLine();

                Console.WriteLine("If you guess incorrectly, you lose your bet.");
                Console.WriteLine("Enter Q to quit.");
                Console.WriteLine();

                // Get player's choice
                string choice = "";
                bool valid = false;

                while (!valid)
                {
                    Console.Write("Enter your choice (1-4) or Q to quit: ");
                    choice = Console.ReadLine().Trim().ToLower();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                    {
                        valid = true;
                    }
                    else if (choice == "q")
                    {
                        done = true;
                        valid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice! Please enter 1-4 or Q.");
                        Console.ResetColor();
                    }
                }

                // Check if player wants to quit
                if (done)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("==============================");
                    Console.WriteLine("     THANK YOU FOR PLAYING!");
                    Console.WriteLine("==============================");

                    Console.WriteLine();
                    Console.WriteLine("Your final balance is: $" + balance.ToString("F2"));

                    Console.ResetColor();

                    break;
                }

                // Get bet amount
                double bet = 0;
                bool validBet = false;

                while (!validBet)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your current balance is $" + balance.ToString("F2"));
                    Console.WriteLine();
                    Console.WriteLine("Your bet must be greater than $0 and no more than your balance.");
                    Console.Write("How much would you like to bet? $");

                    string betInput = Console.ReadLine();

                    if (double.TryParse(betInput, out bet))
                    {
                        if (bet > 0 && bet <= balance)
                        {
                            validBet = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid bet! Enter an amount greater than $0 and no more than your balance.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number.");
                        Console.ResetColor();
                    }

                }

                // Roll the dice
                Console.WriteLine();
                Console.WriteLine("Press ENTER to roll the dice!");
                Console.ReadLine();

                die1.RollDie();
                die2.RollDie();

                // Display dice results
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========== DICE RESULTS ==========");
                Console.ResetColor();

                Console.WriteLine();

                Console.WriteLine("Die 1:");
                die1.DrawRoll();

                Console.WriteLine();

                Console.WriteLine("Die 2:");
                die2.DrawRoll();

                // Calculate dice total
                int sum = die1.Roll + die2.Roll;

                Console.WriteLine();
                Console.WriteLine("Dice Total: " + sum);

               
                // Check if the dice are doubles
                bool doubles = die1.Roll == die2.Roll;

                // Check if the sum is even
                bool evenSum = sum % 2 == 0; // % calculates the remainder (Check if the sum is even by checking if the remainder when divided by 2 is 0)

                // Check if the player's bet was correct
                bool won = false;

                if (choice == "1" && doubles)
                {
                    won = true;
                }
                else if (choice == "2" && !doubles)
                {
                    won = true;
                }
                else if (choice == "3" && evenSum)
                {
                    won = true;
                }
                else if (choice == "4" && !evenSum)
                {
                    won = true;
                }

                // Calculate winnings
                double winnings = 0;

                if (choice == "1")
                {
                    winnings = bet * 2;
                }
                else if (choice == "2")
                {
                    winnings = bet * 0.5;
                }
                else if (choice == "3" || choice == "4")
                {
                    winnings = bet;
                }


                // Update the player's balance
                if (won)
                {
                    balance += winnings;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("YOU WON!");
                    Console.WriteLine("You won $" + winnings.ToString("F2"));
                    Console.ResetColor();
                }
                else
                {
                    balance -= bet;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("YOU LOST!");
                    Console.WriteLine("You lost $" + bet.ToString("F2"));
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("New Balance: $" + balance.ToString("F2"));

                Console.WriteLine();
                Console.WriteLine("Press ENTER for the next round...");
                Console.ReadLine();



            }
        }
    }
}
