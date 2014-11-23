using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacdonaldsHackathon2014
{
    public class Question
    {
        public string QuestionContent { get; set; }
        public Answer Answer1 { get; set; }
        public Answer Answer2 { get; set; }
        public Answer Answer3 { get; set; }
        public Answer Answer4 { get; set; }
        public string Tips { get; set; }
        public bool IsNotAnswered { get; set; }

        public Question(string content, Answer a1, Answer a2, Answer a3, Answer a4, string tips)
        {
            this.QuestionContent = content;
            this.Answer1 = a1;
            this.Answer2 = a2;
            this.Answer3 = a3;
            this.Answer4 = a4;
            this.Tips = tips;

            this.IsNotAnswered = true;
        }
    }
}
