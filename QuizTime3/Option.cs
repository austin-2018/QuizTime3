using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime3
{
    class Option
    {
        private static int nextID = 0; 
        public int ID { get; set; }
        public string Name { get; set; }

        public Option(string name)
        {
            ID = ++nextID;
            Name = name;
        }
    }
}
