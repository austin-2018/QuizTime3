using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    abstract class Question
    {
        private static int nextID = 0;
        private int ID { get; set; }
        internal string Name { get; set; }
        private int NumberOfPossibleAnswers { get; set; }

        public List<Answer> Answers { get; set; }

        internal Question()
        {
            ID = nextID++;
            Name = MakeQuestionName();
        }

        internal Question(int numberOfPossibleAnswers)
        {
            ID = nextID++;
            Answers = new List<Answer>();
            Name = MakeQuestionName();
            MakePossibleAnswers(numberOfPossibleAnswers);
        }

        protected string MakeQuestionName()
        {
            Console.Clear();
            return Utility.GetAnswer("Please enter the question: ");
        }

        protected virtual void MakePossibleAnswers(int numberOfPossibleAnswers)
        {
            Console.Clear();
            Utility.PrintSlow(string.Format("Enter {0} possible answers\n", numberOfPossibleAnswers));
            for (int i = 0; i < numberOfPossibleAnswers; i++)
            {
                Console.Write("{0}: ", i + 1);
                Answers.Add(new Answer(i + 1, Console.ReadLine()));
            }
        }

        protected virtual void SetCorrectAnswer()
        {
            
            int answer = int.Parse(Utility.GetAnswer(string.Format("Question: {0}\n\nChoose which of the following answers are correct: ", Name), Answers));
            Answer correctAnswer = (Answers.Find(individualAnswer => individualAnswer.ID.Equals(answer)));
            correctAnswer.IsCorrectAnswer = true;
            ////Testing for correct answer being chosen
            //foreach (Answer singleAnswer in Answers)
            //{
            //    Console.WriteLine("Correct? => {0}", singleAnswer.IsCorrectAnswer);
            //}
            //Console.Write("To continue, press ENTER");
            //Console.Read();
        }
    }
}
