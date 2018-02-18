using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    class QuizSqlRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizSqlRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task AddSampleQuiz(SampleQuiz quiz)
        {
            _context.SampleQuizes.Add(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task AddQuestionToSample(SampleQuestion question, Guid quizId)
        {
            SampleQuiz quiz = await _context.SampleQuizes.FirstAsync(s => s.Id.Equals(quizId));
            quiz.Questions.Add(question);    
            await _context.SaveChangesAsync();
        }

        /*public async Task AddSolvingQuiz(SolvingQuiz quiz, string UserId)
        {
            User user = await _context.Users.FirstAsync(s => s.Id.Equals(UserId));
            user.SolvedQuizes.Add(quiz);
            user.IsUpdated = true;
            await _context.SaveChangesAsync();
        }*/

        public async Task AddQuizesToUser(SolvingQuiz quiz, SampleQuiz sample, string UserId)
        {
            User user = await _context.Users.FirstAsync(s => s.Id.Equals(UserId));
            user.SolvedQuizes.Add(quiz);
            user.SampleQuizes.Add(sample);
            user.IsUpdated = true;
            await _context.SaveChangesAsync();
        }

        public async Task CalculateStats(SolvingQuiz quiz)
        {
            _context.Entry(quiz).State = EntityState.Modified;
            quiz.CalculateStats();
            await _context.SaveChangesAsync();
        }


        public async Task<SampleQuiz> GetSampleQuiz(Guid quizId)
        {
            return await _context.SampleQuizes.Include(s => s.Questions).FirstAsync(s => s.Id.Equals(quizId));
        }

        public async Task<SolvingQuiz> GetSolvingQuiz(Guid quizId)
        {
            return await _context.SolvedQuizes.Include(s => s.Questions).FirstAsync(s => s.Id.Equals(quizId));
        }

        public SampleQuestion GetSampleQuestion(Guid quizId, String Text) {
            return _context.SampleQuizes.First(s => s.Id.Equals(quizId)).Questions.Find(s => s.QuestionText.Equals(Text));
        }
        public SolvedQuestion GetFirtsSolvedQuestion(Guid quizId) {
            return _context.SolvedQuizes.First(s => s.Id.Equals(quizId)).Questions.First();
        }

        public void StoreUserAnswer(String Answer, SolvedQuestion question)
        {
            question.AnswerQuestion(Answer);
            _context.Entry(question).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task EditUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string Id)
        {
            return await _context.Users.Include(s => s.SolvedQuizes).FirstAsync(s => s.Id.Equals(Id));
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.OrderByDescending(s => s.TotalPoints).ThenByDescending(s => s.TotalPercentage).ThenBy(s => s.NumOfSolvedQuizes).ToListAsync();
        }


        public async Task<List<SampleQuiz>> GetAll()
        {
            return await _context.SampleQuizes.OrderBy(s => s.DateExpiring).ToListAsync();
        }

        public async Task<List<SampleQuiz>> GetAvailable(string userId)
        {
            List<SampleQuiz> quizes = await _context.SampleQuizes.Include(s => s.Users).Where(s => s.DateExpiring > DateTime.Now).OrderBy(s => s.DateExpiring).ToListAsync();
            List<SampleQuiz> availableQuizes = new List<SampleQuiz>();
            foreach(SampleQuiz quiz in quizes)
            {
                if (!(quiz.Users.Exists(s => s.Id.Equals(userId)))) availableQuizes.Add(quiz);
            }
            return availableQuizes;
        }

        public async Task<List<SampleQuiz>> GetByGenre(Genre genre, string userId)
        {
            List<SampleQuiz> quizes = await _context.SampleQuizes.Include(s => s.Users).Where(s => s.QuizGenre == genre && s.DateExpiring > DateTime.Now).OrderBy(s => s.DateExpiring).ToListAsync();
            List<SampleQuiz> availableQuizes = new List<SampleQuiz>();
            foreach (SampleQuiz quiz in quizes)
            {
                if (!(quiz.Users.Exists(s => s.Id.Equals(userId)))) availableQuizes.Add(quiz);
            }
            return availableQuizes;
        }

        public async Task Remove()
        {
            List<SampleQuiz> removables = _context.SampleQuizes.Where(s => s.DateExpiring < DateTime.Now).ToList();
            foreach (SampleQuiz quiz in removables) _context.SampleQuizes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSampleQuiz(Guid quizId)
        {
            SampleQuiz quiz = await _context.SampleQuizes.FirstAsync(s => s.Id.Equals(quizId));
            _context.SampleQuizes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserStats(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            user.CalculateStatistics();
            await _context.SaveChangesAsync();
        }
    }
}
