using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class QuestionModel
    {
        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        public String QuestionText { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public String Correct { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public String Wrong1 { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public String Wrong2 { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public String Wrong3 { get; set; }

        public int Number { get; set; }
        public Guid QuizId { get; set; }
        public Boolean IsFinished { get; set; }

        public QuestionModel()
        {
            Number = 1;
            IsFinished = false;
        }

        public void setFinished()
        {
            IsFinished = true;
        }
    }
}
