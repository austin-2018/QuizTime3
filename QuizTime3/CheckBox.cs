using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime3
{
    class CheckBox : Question
    {

        internal CheckBox(int numberOfPossibleAnswer) {
            Console.WriteLine("Check box class is under construction");
        }
        //public List<char> MultipleAnswers { get; set; }
        //public CheckBox(int numberOfPossibleAnswer) : base()
        //{
        //    Answers = new List<Answer>();
        //    MultipleAnswers = new List<char>();
        //    MakePossibleAnswers(numberOfPossibleAnswer);

        //}

        //protected override void MakePossibleAnswers(int numberOfPossibleAnswers)
        //{
        //    base.MakePossibleAnswers(numberOfPossibleAnswers);
        //    SetCorrectAnswer();
        //}

        //protected override void SetCorrectAnswer()
        //{
        //    Console.Clear();
        //    Utility.PrintQuestionOut("Choose which of the following answers are correct: ", Answers);
        //    GetAnswerKey();
        //    foreach (char character in MultipleAnswers)
        //    {
        //        Answer correctanswer = (Answers.Single(individualAnswer => individualAnswer.ID.Equals(int.Parse(character.ToString()))));
        //        correctanswer.IsCorrectAnswer = true;
        //    }
        //}

        //private void GetAnswerKey()
        //{
        //    string input;
        //    do
        //    {
        //        Console.Write("Answer Key [separate by spaces]: ");
        //        input = Console.ReadLine();
        //    } while (!IsValidSelection(input, Answers));

        //    foreach (char character in input)
        //    {
        //        if(!(character.Equals(' ')))
        //        {
        //            MultipleAnswers.Add(character);
        //        }
        //    }
        //}

        //private bool IsValidSelection(string input, List<Answer> answers)
        //{
        //    bool result = true;
        //    string[] inputSplit = input.Split(' ');
        //    if (result)
        //    {
        //        if (!(inputSplit.Length > answers.Count))
        //        {
        //            for (int i = 0; i < inputSplit.Length; i++)
        //            {
        //                result = true && (int.Parse(inputSplit[i]) > 0 || int.Parse(inputSplit[i]) < answers.Count) ? true : false;
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}
