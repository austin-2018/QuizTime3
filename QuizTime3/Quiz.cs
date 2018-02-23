using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime3
{
    class Quiz
    {
        public string Name { get; set; }
        private static List<Question> Questions { get; set; }
        private static List<string> QuestionTypesStringVersion = new List<string>
        {
            "Multiple Choice",
            "True and False",
            "Check Box - Multiple Choice"
        };
        private static List<Answer> Answers { get; set; }

        public Quiz()
        {
            Console.Write("Enter name for this Quiz: ");
            Name = Console.ReadLine();
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }

        public void Play()
        {
            SetUpQuestions();
            StartQuiz();
            Console.WriteLine(GradeQuiz());
        }

        public void SetUpQuestions()
        {
            int questionAmount = DetermineQuestionAmount();
            for (int i = 0; i < questionAmount; i++)
            {
                Console.Clear();
                Utility.PrintQuestionOut("What kind of question do you want this question to be: ", QuestionTypesStringVersion);
                Questions.Add(DetermineQuestionType());
            }
        }

        public void StartQuiz()
        {
            foreach (Question question in Questions)
            {
                Utility.PrintQuestionOut(question.Name, question.Answers);
                int choice = int.Parse(Utility.GetChoice(question.Answers));
                Answers.Add(question.Answers.Single(answer => answer.ID.Equals(choice)));
            }
        }

        public string GradeQuiz()
        {
            Console.Clear();
            List<Answer> correct = Answers.FindAll(answer => answer.IsCorrectAnswer);
            double result = (double) correct.Count / (double) Answers.Count;
            return string.Format("{0} out of {1} correct: {2:P}", correct.Count, Answers.Count, result);
        }

        public int DetermineQuestionAmount()
        {
            Console.Clear();
            Console.Write("How many questions are there going to be: ");
            return int.Parse(Utility.GetChoice());
        }



        public Question DetermineQuestionType()
        {
           return MakeQuestionType(Utility.GetChoice(QuestionTypesStringVersion));
        }

        public static Question MakeQuestionType(string key)
        {
            return key.Equals("1") ? new MultipleChoice(4) as Question: key.Equals("2") ? new TrueFalse() as Question: new CheckBox(5) as Question;
        }
    }
}
