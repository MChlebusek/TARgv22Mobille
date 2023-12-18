using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace TARgv22
{
    public partial class Wordle : ContentPage
    {
        private string secretWord;
        private int attemptsLeft;

        public Wordle()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            secretWord = WordLibrary.GetRandomWord();
            attemptsLeft = 6;
            ResultLabel.Text = string.Empty;
        }

        private void OnSubmitGuessClicked(object sender, EventArgs e)
        {
            string guess = GuessEntry.Text.Trim().ToLower();

            if (guess.Length != 5)
            {
                ResultLabel.Text = "Please enter a 5-letter word.";
                return;
            }

            attemptsLeft--;

            string feedback = GetFeedback(guess);

            if (feedback.Equals("Congratulations! You guessed the word."))
            {
                ResultLabel.Text = feedback;
            }
            else
            {
                ResultLabel.Text = $"{feedback}\nAttempts Left: {attemptsLeft}";

                if (attemptsLeft == 0)
                {
                    ResultLabel.Text += $"\nThe correct word was: {secretWord}";
                }
            }
        }

        private string GetFeedback(string guess)
        {
            bool[] correctPosition = new bool[5];
            bool[] guessedLetters = new bool[26];

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (guess[i] == secretWord[i])
                {
                    correctPosition[i] = true;
                }
                else
                {
                    guessedLetters[secretWord[i] - 'a'] = true;
                }
            }

            StringBuilder feedback = new StringBuilder();

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (correctPosition[i])
                {
                    feedback.Append("+"); // Угадана буква на своем месте
                }
                else if (guessedLetters[guess[i] - 'a'])
                {
                    feedback.Append("-"); // Угадана буква, но не на своем месте
                }
                else
                {
                    feedback.Append("."); // Нет угаданной буквы
                }
            }
            

            if (feedback.ToString() == "+++++")
            {
                return "Congratulations! You guessed the word.";
            }

            return feedback.ToString();


        }


        private void OnStartOverClicked(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}