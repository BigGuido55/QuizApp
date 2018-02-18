using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineQuiz.Core;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class MainPageModel
    {
        public List<SampleQuiz> Quizes { get; set; }
        public Boolean AreRemovable { get; set; }

        public MainPageModel()
        {
            Quizes = new List<SampleQuiz>();
            AreRemovable = false;
        }
    }
}
