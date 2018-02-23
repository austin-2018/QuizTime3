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
            MakePossibleAnswers(numberOfPossibleAnswers);
        }

        protected string MakeQuestionName()
        {
            Console.Clear();
            Console.Write("Please enter the question: ");
            return Console.ReadLine();
        }

        protected void MakePossibleAnswers(int numberOfPossibleAnswers)
        {
            Console.Clear();
            Console.WriteLine("Enter {0} possible answers", numberOfPossibleAnswers);
            for (int i = 0; i < numberOfPossibleAnswers; i++)
            {
                Console.Write("{0}: ", i + 1);
                Answers.Add(new Answer(i + 1, Console.ReadLine()));
            }
            SetCorrectAnswer();

            // Testing for correct answer being chosen
            //foreach (Answer answer in Answers)
            //{
            //    Console.WriteLine("Correct? => {0}", answer.IsCorrectAnswer);
            //}
        }

        protected void SetCorrectAnswer()
        {
            Console.Clear();
            Utility.PrintQuestionOut("Choose which of the following answers are correct: ", Answers);
            int answer = int.Parse(Utility.GetChoice(Answers));
            Answer correctAnswer = (Answers.Find(individualAnswer => individualAnswer.ID.Equals(answer)));
            correctAnswer.IsCorrectAnswer = true;
        }
    }
}
