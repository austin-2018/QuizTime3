using System;
using System.Threading;

namespace QuizTime3
{
    class Program
    {
        static void Main(string[] args)
        {
            Prettify.DisplayOpening();
            Game game = new Game();
            Quiz quiz;
            while (game.IsRunning)
            {
                quiz = new Quiz();
                quiz.Play();
                PlayAgain(game);
            }
            Prettify.DisplayEnding();
        }


        private static void PlayAgain(Game game)
        {
            string choice = GameHelpers.GetAnswer("Do you want to play again ?", game);
            Option pickedOption = game.Options.Find(option => option.ID.Equals(int.Parse(choice)));
            game.IsRunning = pickedOption.Name.Equals("Yes");
            Console.Clear();
        }
    }
}
