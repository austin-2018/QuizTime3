using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class Answer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public Answer(int id, string name)
        {
            ID = id;
            Name = name;
            IsCorrectAnswer = false;
        }
        
    }
}
