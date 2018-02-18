using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineQuiz.Core;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class RankingsModel
    {
        public List<User> Users { get; set; }
        public String UserId { get; set; }

        public RankingsModel()
        {
            Users = new List<User>();
            UserId = "";
        }
    }
}
