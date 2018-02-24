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
            "True and False"
          //  "Check Box - Multiple Choice (under construction)"
        };
        private List<Answer> UserChoices { get; set; }

        private static double Correct { get; set; }

        public Quiz()
        {
            Console.Write("Enter name for this Quiz: ");
            Name = Console.ReadLine();
            Questions = new List<Question>();
            UserChoices = new List<Answer>();
            Correct = 0.00;
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
                string choice = Utility.GetChoice();
                UserChoices.Add(question.Answers.Find(answer => answer.ID.Equals(int.Parse(choice))));
                //UNDER CONSTRUCTION 
                //IList<char> choices = ChooseAnswer(question;
                //var query = choices.SelectMany(
                //    choice => question.Answers.Where(
                //        answer => answer.ID.Equals(int.Parse(choice.ToString()))));
            }   
        }

        public List<char> ChooseAnswer(Question question)
        {
            List<char> choices;
            Console.Write("Enter your choice or choice(s) [if more than one just group it i.e. 123]: ");
            do
            {
                string input = Console.ReadLine();
                choices = input.ToList();
            } while (choices.Contains(',') || choices.Contains(' ') || !(choices.TrueForAll(key => char.IsDigit(key) ? !(int.Parse(key.ToString()) < 1 || int.Parse(key.ToString()) > question.Answers.Count) : false )));

            return choices;
        }

        public string GradeQuiz()
        {
            Console.Clear();
            IList<Answer> correct = UserChoices.FindAll(answer => answer.IsCorrectAnswer);
            double result = (double) correct.Count / (double) UserChoices.Count;
            return string.Format("{0} out of {1} correct: {2:P}", correct.Count, UserChoices.Count, result);
        }

        public int DetermineQuestionAmount()
        {
            Console.Clear();
            Console.Write("How many questions are there going to be: ");
            return int.Parse(Utility.GetChoice());
        }



        public static Question DetermineQuestionType()
        {
           return MakeQuestionType(Utility.GetAnswerKey(QuestionTypesStringVersion));
        }

        public static Question MakeQuestionType(string key)
        {
         //   return key.Equals("1") ? new MultipleChoice(4) as Question : key.Equals("2") ? new TrueFalse() as Question;: new CheckBox(5) as Question;
            return key.Equals("1") ? new MultipleChoice(4) as Question : new TrueFalse() as Question; //: new CheckBox(5) as Question;
        }
    }
}
