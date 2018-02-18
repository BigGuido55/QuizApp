using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineQuiz.Core;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class SolvingQuestionModel
    {
        public Guid SampleQuizId { get; set; }
        public Guid SolvingQuizId { get; set; }
        public String QuestionText { get; set; }
        public String[] Answers {get;set;}
        public String UserAnswer { get; set; }
        public int QuestionNumber { get; set; }

        public SolvingQuestionModel()
        {
            Answers = new String[4];
        }

        public SolvingQuestionModel(SampleQuestion question, SolvedQuestion solved)
        {
            SampleQuizId = question.OwningQuiz.Id;
            SolvingQuizId = solved.OwningQuiz.Id;
            QuestionNumber = 1;

            QuestionText = question.QuestionText;
            Answers = new String[4];
            StoreAndShuffle(question.CorrectAnswer, question.WrongAnswer1, question.WrongAnswer2, question.WrongAnswer3);
        }      

        public void nextQuestion(List<SampleQuestion> samples, SolvedQuestion question)
        {
            SampleQuestion sample = samples.Find(s => s.QuestionText.Equals(question.QuestionText));
            QuestionNumber++;
            QuestionText = sample.QuestionText;
            StoreAndShuffle(sample.CorrectAnswer, sample.WrongAnswer1, sample.WrongAnswer2, sample.WrongAnswer3);
        }

        private void StoreAndShuffle(String CAnswer, String WAnswer1, String WAnswer2, String WAnswer3)
        {
            Answers[0] = CAnswer;
            Answers[1] = WAnswer1;
            Answers[2] = WAnswer2;
            Answers[3] = WAnswer3;

            Random rand = new Random();
            for (int i = 3; i > 0; i--)
            {
                int j = rand.Next() % (i + 1);
                if (i != j)
                {
                    String help = Answers[i];
                    Answers[i] = Answers[j];
                    Answers[j] = help;
                }
            }
        }
    }
}
