using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class Game
    {
        public bool IsRunning { get; set; }
        public List<Option> Options { get; set; }

        public Game()
        {
            IsRunning = true;
            Options = new List<Option>
            {
                new Option("Yes"),
                new Option("No")
            };
        }
    }
}
