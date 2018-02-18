using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public interface IQuizRepository
    {
        Task AddSampleQuiz(SampleQuiz quiz);
        Task AddQuestionToSample(SampleQuestion question, Guid quizId);
        //Task AddSolvingQuiz(SolvingQuiz quiz, string userId);
        Task AddQuizesToUser(SolvingQuiz quiz, SampleQuiz sample, string userId);
        Task CalculateStats(SolvingQuiz quiz);

        Task<SampleQuiz> GetSampleQuiz(Guid quizId);
        Task<SolvingQuiz> GetSolvingQuiz(Guid quizId);
        SampleQuestion GetSampleQuestion(Guid quizId, String Text);
        SolvedQuestion GetFirtsSolvedQuestion(Guid quizId);
        void StoreUserAnswer(String Answer, SolvedQuestion question);

        void AddUser(User user);
        Task<User> GetUser(string Id);
        Task<List<User>> GetAllUsers();
        Task EditUser(User user);

        Task<List<SampleQuiz>> GetAvailable(string userId);          //STVORI KLASU USER (al ovdje mozes i koristit od ApplicationUser Id)
        Task<List<SampleQuiz>> GetByGenre(Genre genre, string userId);
        Task<List<SampleQuiz>> GetAll();

        Task Remove();
        Task RemoveSampleQuiz(Guid quizId);
        Task UpdateUserStats(User user);

    }
}
