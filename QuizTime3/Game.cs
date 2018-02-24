using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class Game
    {
        internal bool IsRunning { get; set; }
        internal List<Option> Options { get; set; }

        internal Game()
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
