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
            Quiz quiz = new Quiz();
            quiz.Play();
        }
    }
}
