using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public class SampleQuiz
    {
        public Guid Id { get; set; }
        public String QuizName { get; set; }
        public List<SampleQuestion> Questions { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpiring { get; set; }
        public Genre QuizGenre { get; set; }
        public List<User> Users { get; set; }

        public SampleQuiz()
        {
            Questions = new List<SampleQuestion>();
            Users = new List<User>();
        }

        public SampleQuiz(String Name, DateTime Expiring, Genre genre)
        {
            Questions = new List<SampleQuestion>();
            Users = new List<User>();
            Id = Guid.NewGuid();
            QuizName = Name;
            DateCreated = DateTime.Now;
            DateExpiring = Expiring;
            QuizGenre = genre;
        }
    }
}
