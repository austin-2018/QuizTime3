using System;

namespace QuizTime3
{
    class Program
    {
        static void Main(string[] args)
        {
            SetUp();
            Console.ReadLine();
        }

        static void SetUp()
        {
            Console.WriteLine("Enter a name for this quiz");
            Quiz quiz = new Quiz(Console.ReadLine());
            quiz.Play();
        }
    }
}
