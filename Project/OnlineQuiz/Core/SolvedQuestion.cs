using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public class SolvedQuestion
    {
        public Guid QuestionId { get; set; }
        public String QuestionText { get; set; }
        public String CorrectAnswer { get; set; }
        public String UserAnswer { get; set; }
        public Boolean IsCorrect { get; private set; }
        public SolvingQuiz OwningQuiz { get; set; }

        public SolvedQuestion()
        {

        }

        public SolvedQuestion(String QuestionText, String CAnswer)
        {
            QuestionId = Guid.NewGuid();
            this.QuestionText = QuestionText;
            CorrectAnswer = CAnswer;
            IsCorrect = false;
            UserAnswer = "";
        }

        public void AnswerQuestion(String Answer)
        {
            UserAnswer = Answer;
            if (UserAnswer.Equals(CorrectAnswer)) IsCorrect = true;
            else IsCorrect = false;
        }
    }
}
