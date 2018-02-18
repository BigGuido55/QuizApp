using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineQuiz.Core;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class ProfileModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public int NumOfQuiz { get; set; }
        public int Total { get; set; }
        public int TotalPercentage { get; set; }
        public List<SolvingQuiz> Quizes { get; set; }

        public ProfileModel()
        {

        }
        public ProfileModel(User user)
        {
            UserID = user.Id;
            UserName = user.NickName;
            NumOfQuiz = user.NumOfSolvedQuizes;
            Total = user.TotalPoints;
            TotalPercentage = user.TotalPercentage;
            Quizes = user.SolvedQuizes;
        }
    }
}
