using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime3
{
    class CheckBox : Question
    {
        public static List<char> MultipleAnswers { get; set; }

        public CheckBox(int numberOfPossibleAnswer) : base(numberOfPossibleAnswer)
        {
            MultipleAnswers = new List<char>();
        }

        protected override void SetCorrectAnswer()
        {
            Console.Clear();
            Utility.PrintQuestionOut("Choose which of the following answers are correct: ", Answers);
            GetChoices();
            foreach (char character in MultipleAnswers)
            {
                Answer correctanswer = (Answers.Single(individualAnswer => individualAnswer.ID.Equals(int.Parse(character.ToString()))));
                correctanswer.IsCorrectAnswer = true;
            }
        }

        private void GetChoices()
        {
            string input;
            do
            {
                Console.Write("Choice [separate by spaces]: ");
                input = Console.ReadLine();
            } while (!IsValidSelection(input, Answers));

            foreach (char character in input)
            {
                if(!(character.Equals(' ')))
                {
                    MultipleAnswers.Add(character);
                }
            }
        }

        private bool IsValidSelection(string input, List<Answer> answers)
        {
            bool result = true;
            string[] inputSplit = input.Split(' ');
            if (result)
            {
                if (!(inputSplit.Length > answers.Count))
                {
                    for (int i = 0; i < inputSplit.Length; i++)
                    {
                        result = true && (int.Parse(inputSplit[i]) > 0 || int.Parse(inputSplit[i]) < answers.Count) ? true : false;
                    }
                }
            }

            return result;
        }
    }
}
