using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuizTime3
{
    class Quiz
    {
        private string Name { get; set; }
        private static List<Question> Questions { get; set; }
        private static List<string> QuestionTypesStringVersion = new List<string>
        {
            "Multiple Choice",
            "True and False"
          //  "Check Box - Multiple Choice (under construction)"
        };
        private List<Answer> UserChoices { get; set; }

        private double Correct { get; set; }

        internal Quiz()
        {
            Name = GameLogic.GetAnswer("Enter name for this Quiz: ");
            Questions = new List<Question>();
            UserChoices = new List<Answer>();
            Correct = 0.00;
        }

        internal void Play()
        {
            SetUpQuestions();
            StartQuiz();
            GameLogic.PrintSlow(GradeQuiz());
            GameLogic.PrintSlow("\n\nGame is about to end");
            GameLogic.PrintSlow(" . . . . . . . .", 100);
            
        }

        private void SetUpQuestions()
        {
            int questionAmount = DetermineQuestionAmount();
            for (int i = 0; i < questionAmount; i++)
            {
                Console.Clear();
                // Utility.PrintQuestionOut();
                Questions.Add(DetermineQuestionType());
            }
        }

        private void StartQuiz()
        {
            foreach (Question question in Questions)
            {
                string choice = GameLogic.GetAnswer("Question: ", question);
                UserChoices.Add(question.Answers.Find(answer => answer.ID.Equals(int.Parse(choice))));
                //UNDER CONSTRUCTION 
                //IList<char> choices = ChooseAnswer(question;
                //var query = choices.SelectMany(
                //    choice => question.Answers.Where(
                //        answer => answer.ID.Equals(int.Parse(choice.ToString()))));
            }
        }

        // do not use, must refactor for use with CheckBoxes
        //public List<char> ChooseAnswer(Question question)
        //{
        //    List<char> choices;
        //    Console.Write("Enter your choice or choice(s) [if more than one just group it i.e. 123]: ");
        //    do
        //    {
        //        string input = Console.ReadLine();
        //        choices = input.ToList();
        //    } while (choices.Contains(',') || choices.Contains(' ') || !(choices.TrueForAll(key => char.IsDigit(key) ? !(int.Parse(key.ToString()) < 1 || int.Parse(key.ToString()) > question.Answers.Count) : false )));

        //    return choices;
        //}

        private string GradeQuiz()
        {
            Console.Clear();
            IList<Answer> correct = UserChoices.FindAll(answer => answer.IsCorrectAnswer);
            Correct = QuizGrader((double)correct.Count, (double)UserChoices.Count);

            GameLogic.PrintSlow("Grading quiz");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(250);
                Console.Write(" .");
            }
            GameLogic.PrintSlow(" Done!\nNow for the moment of truth, see results below\n");

            string result = string.Format("Result: {0} out of {1} correct: {2:P}", correct.Count, UserChoices.Count, Correct);

            return result;
        }

        private double QuizGrader(double correct, double choices)
        {
            return correct / choices;
        }

        private int DetermineQuestionAmount()
        {
            Console.Clear();
            return int.Parse(GameLogic.GetQuestionAmount());
        }

        private Question DetermineQuestionType()
        {
            return MakeQuestionType(GameLogic.GetAnswer("What kind of question do you want this question to be:", QuestionTypesStringVersion));
        }
            public static Question MakeQuestionType(string key)
        {
            //   return key.Equals("1") ? new MultipleChoice(4) as Question : key.Equals("2") ? new TrueFalse() as Question;: new CheckBox(5) as Question;
            return key.Equals("1") ? new MultipleChoice(4) as Question : new TrueFalse() as Question; //: new CheckBox(5) as Question;
        }
    }
}

