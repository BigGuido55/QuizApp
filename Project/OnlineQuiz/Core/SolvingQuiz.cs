using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public class SolvingQuiz
    {
        public Guid Id { get; set; }
        public String QuizName { get; set; }
        public List<SolvedQuestion> Questions { get; set; }
        public int PercentageCorrect { get; private set; }
        public int NumberOfQuestions { get; private set; }
        public int CorrectQuestions { get; private set; }
        public DateTime DateSolved { get; set; }
        public Genre QuizGenre { get; set; }
        public User Solver { get; set; }

        public SolvingQuiz()
        {
            Questions = new List<SolvedQuestion>();                                           //trebat ce dodat jos
        }

        public SolvingQuiz(SampleQuiz quiz)
        {
            Id = Guid.NewGuid();
            QuizName = quiz.QuizName;
            Questions = new List<SolvedQuestion>();
            DateSolved = DateTime.Now;
            NumberOfQuestions = quiz.Questions.Count;                           //mozda bi trebao na 0 stavit pa dodavat za jedno naknadno hmm
            CorrectQuestions = 0;
            QuizGenre = quiz.QuizGenre;
        }

        public void CalculateStats()
        {
            CorrectQuestions = 0;
            foreach (SolvedQuestion question in Questions)
            {
                if (question.IsCorrect) CorrectQuestions++;
            }
            PercentageCorrect = (int)(100.0 * CorrectQuestions / NumberOfQuestions);
        }

        public static SolvingQuiz CreateFromSample(SampleQuiz sample)
        {
            SolvingQuiz quiz = new SolvingQuiz(sample);
            Random rand = new Random();
            foreach(SampleQuestion questionSample in sample.Questions)
            {
                SolvedQuestion question = new SolvedQuestion(questionSample.QuestionText, questionSample.CorrectAnswer);
                quiz.Questions.Add(question);
                if (rand.Next() % 2 == 1) quiz.Questions.Reverse();
            }
            return quiz;
        }
    }

    public enum Genre { History, Geography, Sport, Art, Science, Film, Mithology, Others }
}
