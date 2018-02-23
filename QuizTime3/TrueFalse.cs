using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class TrueFalse : Question
    {
        public TrueFalse() : base()
        {
            int nextAnswerId = 1;
            Answers = new List<Answer>
            {
                new Answer(nextAnswerId++, "true"),
                new Answer(nextAnswerId, "false")
            };
            SetCorrectAnswer();
        }
    }
}
