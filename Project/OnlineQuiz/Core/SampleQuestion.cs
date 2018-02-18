using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public class SampleQuestion
    {
        public Guid QuestionId { get; set; }
        public String QuestionText { get; set; }
        public String CorrectAnswer { get; set; }
        public String WrongAnswer1 { get; set; }
        public String WrongAnswer2 { get; set; }
        public String WrongAnswer3 { get; set; }
        public SampleQuiz OwningQuiz { get; set; }

        public SampleQuestion(String QuestionText, String CAnswer, String WAnswer1, String WAnswer2, String WAnswer3)
        {
            QuestionId = Guid.NewGuid();
            this.QuestionText = QuestionText;
            CorrectAnswer = CAnswer;
            WrongAnswer1 = WAnswer1;
            WrongAnswer2 = WAnswer2;
            WrongAnswer3 = WAnswer3;
        }
        public SampleQuestion()
        {
        }
    }
}
