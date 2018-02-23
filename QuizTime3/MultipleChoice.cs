using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class MultipleChoice : Question
    {
        public MultipleChoice(int numberOfPossibleAnswers = 4) : base(numberOfPossibleAnswers)
        {
        }
    }
}
