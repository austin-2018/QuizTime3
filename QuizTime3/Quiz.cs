using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class Quiz
    {
        public string Name { get; set; }
        private  List<Question> Questions { get; set; }
        private static List<string> QuestionTypesStringVersion = new List<string>
        {
            "Multiple Choice",
            "True and False",
            "Check Box - Multiple Choice"
        };
        public Dictionary<string, Question> QuestionTypes = new Dictionary<string, Question>
        {
            {"1", new MultipleChoice() },
            {"2", new TrueFalse() },
            {"3", new CheckBox() }
        };

        public Quiz(string name)
        {
            Name = Console.ReadLine();
            Questions = new List<Question>();
        }

        public void Play()
        {
            int questionAmount = DetermineQuestionAmount();
            for (int i = 0; i < questionAmount; i++)
            {
                SetUpQuestion();
            }
        }

        public void SetUpQuestion()
        {
            Utility.PrintQuestionOut("What kind of question do you want this question to be: ", QuestionTypesStringVersion);
            Questions.Add(DetermineQuestionType());
        }

        public int DetermineQuestionAmount()
        {
            Console.Write("How many questions are there going to be: ");
            return int.Parse(Utility.GetChoice());
        }



        public Question DetermineQuestionType()
        {
           return QuestionTypes[(int.Parse(Utility.GetChoice(QuestionTypesStringVersion))).ToString()];
        }
    }
}
