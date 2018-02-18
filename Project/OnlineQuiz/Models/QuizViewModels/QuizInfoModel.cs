using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineQuiz.Core;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class QuizInfoModel
    {
        [Required]
        [MaxLength(50)]
        public String QuizName { get; set; }

        [Required]
        public DateTime DateExpiring { get; set; }

        [Required]
        public Genre QuizGenre { get; set; }

        public QuizInfoModel()
        {

        }
    }
}
