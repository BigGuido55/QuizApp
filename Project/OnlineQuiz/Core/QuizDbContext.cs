using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace OnlineQuiz.Core
{
    public class QuizDbContext : DbContext
    {
        public IDbSet<SampleQuiz> SampleQuizes { get; set; }
        public IDbSet<SolvingQuiz> SolvedQuizes { get; set; }
        public IDbSet<SampleQuestion> SampleQuestions { get; set; }
        public IDbSet<SolvedQuestion> SolvedQuestions { get; set; }
        public IDbSet<User> Users { get; set; }

        public QuizDbContext(string cnnstr) : base(cnnstr)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(s => s.Id);
            modelBuilder.Entity<User>().Property(s => s.NickName).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.NumOfSolvedQuizes).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.TotalPoints).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.TotalPercentage).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.IsUpdated).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.UserPhoto).IsOptional();
            modelBuilder.Entity<User>().HasMany(s => s.SolvedQuizes).WithRequired(m => m.Solver);
            modelBuilder.Entity<User>().HasMany(s => s.SampleQuizes).WithMany(m => m.Users);
            

            modelBuilder.Entity<SampleQuiz>().HasKey(s => s.Id);
            modelBuilder.Entity<SampleQuiz>().Property(s => s.QuizName).IsRequired();
            modelBuilder.Entity<SampleQuiz>().Property(s => s.DateCreated).IsRequired();
            modelBuilder.Entity<SampleQuiz>().Property(s => s.DateExpiring).IsRequired();
            modelBuilder.Entity<SampleQuiz>().HasMany(s => s.Questions).WithRequired(m => m.OwningQuiz);
            
            modelBuilder.Entity<SolvingQuiz>().HasKey(s => s.Id);
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.QuizName).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.QuizGenre).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.DateSolved).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.PercentageCorrect).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.NumberOfQuestions).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().Property(s => s.CorrectQuestions).IsRequired();
            modelBuilder.Entity<SolvingQuiz>().HasMany(s => s.Questions).WithRequired(m => m.OwningQuiz);

            modelBuilder.Entity<SampleQuestion>().HasKey(s => s.QuestionId);
            modelBuilder.Entity<SampleQuestion>().Property(s => s.QuestionText).IsRequired();           
            modelBuilder.Entity<SampleQuestion>().Property(s => s.CorrectAnswer).IsRequired();
            modelBuilder.Entity<SampleQuestion>().Property(s => s.WrongAnswer1).IsRequired();
            modelBuilder.Entity<SampleQuestion>().Property(s => s.WrongAnswer2).IsRequired();                 
            modelBuilder.Entity<SampleQuestion>().Property(s => s.WrongAnswer3).IsRequired();

            modelBuilder.Entity<SolvedQuestion>().HasKey(s => s.QuestionId);
            modelBuilder.Entity<SolvedQuestion>().Property(s => s.QuestionText).IsRequired();
            modelBuilder.Entity<SolvedQuestion>().Property(s => s.CorrectAnswer).IsRequired();
            modelBuilder.Entity<SolvedQuestion>().Property(s => s.UserAnswer).IsRequired();
            modelBuilder.Entity<SolvedQuestion>().Property(s => s.IsCorrect).IsRequired();                  
        }
    }
}
