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

        public Quiz()
        {
            Console.Write("Enter name for this Quiz: ");
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
            Console.Clear();
            Utility.PrintQuestionOut("What kind of question do you want this question to be: ", QuestionTypesStringVersion);
            Questions.Add(DetermineQuestionType());
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
            return key.Equals("1") ? new MultipleChoice(4) as Question: key.Equals("2") ? new TrueFalse(2) as Question: new CheckBox(5) as Question;
        }
    }
}
