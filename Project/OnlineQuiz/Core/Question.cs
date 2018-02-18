using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineQuiz.Core
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public String QuestionText { get; set; }
        public String CorrectAnswer { get; set; }
        public String WrongAnswer1 { get; set; }
        public String WrongAnswer2 { get; set; }
        public String WrongAnswer3 { get; set; }        
        public String UserAnswer { get; set; }
        public Boolean IsCorrect { get; private set; }
        public SampleQuiz OwningQuiz { get; set; }

        public Question(String QuestionText, String CAnswer, String WAnswer1, String WAnswer2, String WAnswer3)
        {
            QuestionId = Guid.NewGuid();
            this.QuestionText = QuestionText;
            CorrectAnswer = CAnswer;
            WrongAnswer1 = WAnswer1;
            WrongAnswer2 = WAnswer2;
            WrongAnswer3 = WAnswer3;
            IsCorrect = false;
            UserAnswer = "";
        }

        

        public void AnswerQuestion(String Answer)
        {
            UserAnswer = Answer;
            CheckIfCorrect();
        }

        private void CheckIfCorrect()
        {
            if (UserAnswer == null) IsCorrect = false;
            else if (CorrectAnswer.Equals(UserAnswer)) IsCorrect = true;
            else IsCorrect = false;
        }



    }

}
