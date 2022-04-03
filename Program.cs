using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<< Welcome to Hangman >>>");
            Console.WriteLine("-----------------------------------------\n");

            string[] allWords = GetAllWords();
            string secretWord = ReturnRandomWord(allWords.Length, allWords);

            //Print underlines representing each letter in the secret word
            foreach (char x in secretWord)
            {
                Console.Write("_ ");
            }
            
            int lenghthOfSecretWord = secretWord.Length;
            int amountOfTimesWrong = 0;
            int currentLettersRight = 0;
            StringBuilder incorrectLettersGuessed = new StringBuilder();
            char[] correctLettersGuessed = new char[lenghthOfSecretWord];
            string userInput;
            char letterGuessed;
            string str;

            while (amountOfTimesWrong != 10 && currentLettersRight != lenghthOfSecretWord)
            {
                Console.WriteLine("");
                Console.Write("\n Incorrect letters guessed so far: " + incorrectLettersGuessed + "\n");
                Console.Write("\n Guess a letter or try to guess the secretword at once: ");

                str = new string(correctLettersGuessed);
                
               
                userInput = Console.ReadLine();

                if (userInput.Length == 1) 
                {
                    letterGuessed = userInput[0];
                    if (incorrectLettersGuessed.ToString().Contains(letterGuessed) || 
                        str.Contains(letterGuessed))
                    {
                        Console.Write("\r\n You have already guessed this letter\n");
                    }

                    
                    else 
                    {
                        // Check if guessed letter is in the secret word
                        bool right = false;
                        for (int i = 0; i < secretWord.Length; i++) { if (letterGuessed == secretWord[i]) { right = true; } }

                        // User is right
                        if (right)
                        {
                            printHangman(amountOfTimesWrong);
                            correctLettersGuessed[currentLettersRight] = letterGuessed;
                            currentLettersRight = printWord(correctLettersGuessed, secretWord);
                            Console.Write("\r\n");
                            //printLines(secretWord);
                        }
                        // User was wrong af
                        else
                        {
                            amountOfTimesWrong += 1;
                            incorrectLettersGuessed.Append(letterGuessed);
                            // Update the drawing
                            printHangman(amountOfTimesWrong);
                            // Print word
                            currentLettersRight = printWord(correctLettersGuessed, secretWord);
                            Console.Write("\r\n");
                            //printLines(secretWord);
                        }
                    }
                }
                // If the user try to guess the entire secret word
                else if (userInput.Length == lenghthOfSecretWord) 
                {
                    if (userInput != secretWord)
                    {
                        Console.WriteLine("You guessed wrong.");
                        amountOfTimesWrong += 1;
                        printHangman(amountOfTimesWrong);
                    }

                    else
                    {
                        Console.WriteLine($"You guessed right! The secret word is {secretWord}!");
                        Console.WriteLine("You Won!!!");
                        currentLettersRight = secretWord.Length;

                    }
                }
                // Handles if user gives invalid input
                else
                {
                    Console.WriteLine("Invalid guess!\n");
                }
            }
        }
        private static void printHangman(int wrongguess)
        {
            if (wrongguess == 0)
            {
                Console.WriteLine("\n     ");
                Console.WriteLine("       ");
                Console.WriteLine("       ");
                Console.WriteLine("       ");
                Console.WriteLine("    ==="); ;
            }
            else if (wrongguess == 1)
            {
                Console.WriteLine("\n    ");
                Console.WriteLine("      ");
                Console.WriteLine("       ");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 2)
            {
                Console.WriteLine("\n     ");
                Console.WriteLine("      ");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 3)
            {
                Console.WriteLine("\n     ");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");


            }
            else if (wrongguess == 4)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 5)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 6)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/     |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 7)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|    |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 8)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("      |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 9)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("/     |");
                Console.WriteLine("    ===");
            }
            else if (wrongguess == 10)
            {
                Console.WriteLine("\n +----+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|\\   |");
                Console.WriteLine("/ \\   |");
                Console.WriteLine("     ===");
                Console.WriteLine("\n GAME OVER!");
            }
        }
        private static int printWord(char[] guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            string str = new string(guessedLetters);
            //int i = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (str.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                        
                }
                else
                {
                    Console.Write("_ ");
               
                }
                counter += 1;
            }
                return rightLetters;
        }
        private static string ReturnRandomWord(int amountOfWords, string[] allWords)
        {
            Random random = new Random();
            int indexValue = random.Next(0, allWords.Length);

            string selectedWord = allWords[indexValue];
            return selectedWord;
        }
        private static string[] GetAllWords()
        {
            string[] allWords = { "hippopotamus", "elephant", "cougar", "giraffe",
                    "octupus", "badger", "alligator", "armadillo", "kangaroo", "salamander"  };
            return allWords;    
        }
    }
}


