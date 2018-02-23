using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    abstract class Question
    {
        private static int nextID = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfPossibleAnswers { get; set; }
        public int MyProperty { get; set; }

        List<Answer> Answers { get; set; }

        public Question(int numberOfPossibleAnswers)
        {
            ID = nextID++;
            Answers = new List<Answer>();
            Name = MakeQuestionName();
            //MakePossibleAnswers();
        }

        protected string MakeQuestionName()
        {
            Console.Write("Please enter the question: ");
            return Console.ReadLine();
        }

        //protected void MakePossibleAnswers()
        //{
        //    Console.WriteLine("Enter {0} possible answers", NumberOfPossibleAnswers);
        //    for (int i = 0; i < NumberOfPossibleAnswers; i++)
        //    {
        //        Console.Write("{0} ", i + 1);
        //        Answers.Add(new Answer(i, Console.ReadLine()));
        //    }
        //}

        protected void SetCorrectAnswer()
        {
            Utility.PrintQuestionOut("Choose which of the following answers are correct: ", Answers);
            Answers.Find(correctAnswer => correctAnswer.ID.Equals(int.Parse(Utility.GetChoice(Answers)) - 1)).IsCorrectAnswer = true;
        }
    }
}
