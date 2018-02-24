using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuizTime3
{
    class GameHelpers
    {
        public static bool IsNumber(string input)
        {
            return input.All(Char.IsDigit);
        }

        public static bool IsWithinRange(string input, List<string> list)
        {
            return int.Parse(input) > 0 && int.Parse(input) < list.Count + 1;

        }

        public static bool IsWithinRange(string input, List<Answer> answers)
        {
            return int.Parse(input) > 0 && int.Parse(input) < answers.Count + 1;

        }

        public static bool IsWithinRange(string input, List<Option> options)
        {
            return int.Parse(input) > 0 && int.Parse(input) < options.Count + 1;

        }

        public static bool IsValidSelection(string input, List<string> list)
        {
            return IsNumber(input) && IsWithinRange(input, list);

        }

        public static bool IsValidSelection(string input, List<Answer> answers)
        {
            return IsNumber(input) && IsWithinRange(input, answers);

        }

        public static bool IsValidSelection(string input, List<Option> options)
        {
            return IsNumber(input) && IsWithinRange(input, options);

        }

        public static void PrintQuestionOut(string prompt, List<string> questionTypes)
        {
            Console.Clear();
            PrintSlow(prompt + "\n\n");
            string stringResult = "";
            int i = 0;
            questionTypes.ForEach(items => stringResult += string.Format("{0}. {1}\n", (++i).ToString(), items));
            PrintSlow(stringResult, 5);
        }

        public static void PrintQuestionOut(string prompt, List<Answer> answers)
        {
            Console.Clear();
            PrintSlow(prompt + "\n\n");
            string stringResult = "";
            answers.ForEach(answer => {
                stringResult += string.Format("{0}. {1}\n", (answer.ID).ToString(), answer.Name);
            });
            PrintSlow(stringResult);
        }

        public static void PrintQuestionOut(string prompt, List<Option> options)
        {
            Console.Clear();
            PrintSlow(prompt + "\n\n");
            string stringResult = "";
            options.ForEach(answer => {
                stringResult += string.Format("{0}. {1}\n", (answer.ID).ToString(), answer.Name);
            });
            PrintSlow(stringResult);
        }

        public static string GetQuestionAmount()
        {
            string input;
            do
            {
                PrintSlow("How many questions are there going to be: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !IsNumber(input))
                {
                    PrintSlow(string.Format(
                        "Expected: integer\n" +
                        "Received: {0} " +
                        "\nRe-prompting", input));

                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(input) || !IsNumber(input));
            return input;
        }

        public static string GetAnswer(string prompt)
        {
            string answer;
            bool isValid = false;

            do
            {
                PrintSlow(prompt);
                answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintSlow("You did not enter what was expected: \nRe-prompting");
                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                } else
                {
                    isValid = true;
                }
            } while (!isValid);
            return answer;
        }

        public static string GetAnswer(string prompt, Question question)
        {
            string answer;
            bool isValid = false;

            do
            {
                PrintQuestionOut(prompt + question.Name, question.Answers);
                PrintSlow("\nChoice: ");
                answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintSlow("You did not enter what was expected: \nRe-prompting");
                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);
            return answer;
        }

        public static string GetAnswer(string prompt, List<string> questionType)
        {
            string answer;

            do
            {
                PrintQuestionOut(prompt, questionType);
                Console.Write("\nChoice: ");
                answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintSlow("You did not enter what was expected: \nRe-prompting");
                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(answer) || !IsValidSelection(answer, questionType));
            return answer;
        }

        public static string GetAnswer(string prompt, List<Answer> answers)
        {
            string answer;

            do
            {
                GameHelpers.PrintQuestionOut(prompt, answers);
                Console.Write("\nAnswer Key: ");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintSlow("You did not enter what was expected: \nRe-prompting");
                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(answer) || !IsValidSelection(answer, answers));
            return answer;
        }

        public static string GetAnswer(string prompt, Game game)
        {
            string answer;

            do
            {
                GameHelpers.PrintQuestionOut(prompt, game.Options);
                Console.Write("\nChoice: ");
                answer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(answer))
                {
                    PrintSlow("You did not enter what was expected: \nRe-prompting");
                    PrintSlow(" . . . . .", 75);
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(answer) || !IsValidSelection(answer, game.Options));
            return answer;
        }

        public static void PrintSlow(string prompt)
        {
            foreach (char character in prompt)
            {
                Console.Write(character);
                Thread.Sleep(3);
            }
        }

        public static void PrintSlow(string prompt, int speedInMillisecond)
        {
            foreach (char character in prompt)
            {
                Console.Write(character);
                Thread.Sleep(speedInMillisecond);
            }
        }
    }
}
