using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Core
{
    public class User
    {
        public String Id { get; set; }
        public String NickName { get; set; }
        public List<SolvingQuiz> SolvedQuizes { get; set; }
        public List<SampleQuiz> SampleQuizes { get; set; }
        public int NumOfSolvedQuizes { get; set; }
        public int TotalPoints { get; set; }
        public int TotalPercentage { get; set; }
        public Boolean IsUpdated { get; set; }  
        public byte[] UserPhoto { get; set; }

        public User(String userId, String Name)
        {
            Id = userId;
            NickName = Name;
            SolvedQuizes = new List<SolvingQuiz>();
            SampleQuizes = new List<SampleQuiz>();
            NumOfSolvedQuizes = 0;
            TotalPoints = 0;
            TotalPercentage = 0;
            IsUpdated = false;
        }

        public User()
        {
            SolvedQuizes = new List<SolvingQuiz>();
            SampleQuizes = new List<SampleQuiz>();
        }

        public void CalculateStatistics()
        {
            TotalPoints = 0;
            NumOfSolvedQuizes = SolvedQuizes.Count;
            int AvailablePoints = 0;
            foreach (SolvingQuiz quiz in SolvedQuizes)
            {
                AvailablePoints += quiz.NumberOfQuestions;
                TotalPoints += quiz.CorrectQuestions;
            }
            TotalPercentage = (int)(100.0 * TotalPoints / AvailablePoints);
        }
    }
}
