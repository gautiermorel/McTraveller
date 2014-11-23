using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacdonaldsHackathon2014
{
    public class Answer
    {
        public string Content { get; set; }
        public bool IsRight { get; set; }

        public Answer(string content, bool right)
        {
            this.Content = content;
            this.IsRight = right;
        }
    }
}
