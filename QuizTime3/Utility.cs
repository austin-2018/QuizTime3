using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime3
{
    class Utility
    {
        public static bool IsNumber(string input)
        {
            return input.All(Char.IsDigit);
        }

        public static bool IsWithinRange(string input, List<string> list)
        {
            return int.Parse(input) < 1 || int.Parse(input) > list.Count ? false : true;

        }

        public static bool  IsWithinRange(string input, List<Answer> answers)
        {
            return int.Parse(input) < 1 || int.Parse(input) > answers.Count ? false : true;

        }

        public static bool IsValidSelection(string input, List<string> list)
        {
            return IsNumber(input) ? IsWithinRange(input, list) ? true : false : false;

        }

        public static bool IsValidSelection(string input, List<Answer> answers)
        {
            return IsNumber(input) ? IsWithinRange(input, answers) ? true : false : false;

        }

        public static void PrintQuestionOut(string prompt, List<string> questionTypes)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            string stringResult = "";
            int i = 0;
            questionTypes.ForEach(items => stringResult += string.Format("{0}. {1}\n", (++i).ToString(), items));
            Console.WriteLine(stringResult);
        }

        public static void PrintQuestionOut(string prompt, List<Answer> answers)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            string stringResult = "";
            answers.ForEach(answer => {
                stringResult += string.Format("{0}. {1}\n", (answer.ID).ToString(), answer.Name);
            });
            Console.WriteLine(stringResult);
        }

        public static string GetChoice()
        {
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!IsNumber(input));
            return input;
        }

        public static string GetAnswerKey(List<string> questionType)
        {
            string answer;

            do
            {
                Console.Write("Answer Key: ");
                answer = Console.ReadLine();
            } while (!IsValidSelection(answer, questionType));
            return answer;
        }

        public static string GetAnswerKey(List<Answer> answers)
        {
            string answer;

            do
            {
                Console.Write("Answer Key: ");
                answer = Console.ReadLine();
            } while (!IsValidSelection(answer, answers));
            return answer;
        }
    }
}
