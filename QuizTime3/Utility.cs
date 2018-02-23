using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizTime3
{
    class Utility
    {
        public static bool isNumber(string input)
        {
            return input.All(Char.IsDigit);
        }

        public static bool isWithinRange(string input, List<string> list)
        {
            return int.Parse(input) < 0 || int.Parse(input) > list.Count ? false : true;

        }

        public static bool isWithinRange(string input, List<Answer> answers)
        {
            return int.Parse(input) < 0 || int.Parse(input) > answers.Count ? false : true;

        }

        public static bool isValidSelection(string input, List<string> list)
        {
            return isNumber(input) ? isWithinRange(input, list) ? true : false : false;

        }

        public static bool isValidSelection(string input, List<Answer> answers)
        {
            return isNumber(input) ? isWithinRange(input, answers) ? true : false : false;

        }

        public static void PrintQuestionOut(string prompt, List<string> questionTypes)
        {
            Console.WriteLine(prompt);
            string stringResult = "";
            int i = 0;
            questionTypes.ForEach(items => stringResult += string.Format("{0}. {1}\n", (++i).ToString(), items));
            Console.WriteLine(stringResult);
        }

        public static void PrintQuestionOut(string prompt, List<Answer> answers)
        {
            Console.WriteLine(prompt);
            string stringResult = "";
            answers.ForEach(answer => {
                stringResult += string.Format("{0}. {1}", answer.ID+1, answer.Name);
            });
        }

        public static string GetChoice()
        {
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!isNumber(input));
            return input;
        }

        public static string GetChoice(List<string> questionType)
        {
            string answer;

            do
            {
                Console.Write("Choice: ");
                answer = Console.ReadLine();
            } while (!isValidSelection(answer, questionType));
            return answer;
        }

        public static string GetChoice(List<Answer> answers)
        {
            string answer;

            do
            {
                Console.Write("Choice: ");
                answer = Console.ReadLine();
            } while (!isValidSelection(answer, answers));
            return answer;
        }
    }
}
